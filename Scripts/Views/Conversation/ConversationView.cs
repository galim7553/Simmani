using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// ��ȭ ������ �ð������� ǥ���ϴ� ��.
    /// </summary>
    public class ConversationView : ViewBase
    {
        public enum TMPKey
        {
            DialogueText,
            EndGuideText,
        }
        public enum ButtonKey
        {
            PanelButton,
        }

        TextMeshProUGUI _dialogueText;
        WaitForSeconds _letterWait = new WaitForSeconds(0.1f);
        string _curDialogue;
        Coroutine _dialougeAnim;

        /// <summary>���� ��ȭ�� ��� ������ ����.</summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>�г� ��ư�� Ŭ���Ǿ��� �� �߻��ϴ� �̺�Ʈ.</summary>
        public event Action OnPanelButtonClicked;

        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<Button>(typeof(ButtonKey));

            _dialogueText = GetTMP((int)TMPKey.DialogueText);

            GetButton((int)ButtonKey.PanelButton).onClick.AddListener(() => { OnPanelButtonClicked?.Invoke(); });
        }

        /// <summary>
        /// ���� ��� �ӵ��� �����մϴ�.
        /// </summary>
        /// <param name="letterSpan">���� ����(��).</param>
        public void SetLetterWait(float letterSpan)
        {
            _letterWait = new WaitForSeconds(letterSpan);
        }

        /// <summary>
        /// ��ȭ�� ����մϴ�.
        /// </summary>
        /// <param name="text">��ȭ ����.</param>
        public void PlayDialogue(string text)
        {
            _curDialogue = text;
            if (_dialougeAnim != null)
                StopCoroutine(_dialougeAnim);
            _dialougeAnim = StartCoroutine(PlayDialogueAnim(_curDialogue));
        }

        /// <summary>
        /// ��ü ��ȭ�� ��� ǥ���մϴ�.
        /// </summary>
        public void ShowFullDialogue()
        {
            if (_dialougeAnim != null)
                StopCoroutine(_dialougeAnim);
            IsPlaying = false;
            _dialogueText.text = _curDialogue;
        }

        IEnumerator PlayDialogueAnim(string text)
        {
            IsPlaying = true;
            int count = 1;
            while(count <= text.Length)
            {
                _dialogueText.text = text.Substring(0, count);
                count++;
                yield return _letterWait;
            }
            IsPlaying = false;
        }

        public override void Clear()
        {
            base.Clear();

            OnPanelButtonClicked = null;
        }
    }
}