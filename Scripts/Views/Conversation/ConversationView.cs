using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 대화 내용을 시각적으로 표시하는 뷰.
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

        /// <summary>현재 대화가 재생 중인지 여부.</summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>패널 버튼이 클릭되었을 때 발생하는 이벤트.</summary>
        public event Action OnPanelButtonClicked;

        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<Button>(typeof(ButtonKey));

            _dialogueText = GetTMP((int)TMPKey.DialogueText);

            GetButton((int)ButtonKey.PanelButton).onClick.AddListener(() => { OnPanelButtonClicked?.Invoke(); });
        }

        /// <summary>
        /// 글자 재생 속도를 설정합니다.
        /// </summary>
        /// <param name="letterSpan">글자 간격(초).</param>
        public void SetLetterWait(float letterSpan)
        {
            _letterWait = new WaitForSeconds(letterSpan);
        }

        /// <summary>
        /// 대화를 재생합니다.
        /// </summary>
        /// <param name="text">대화 내용.</param>
        public void PlayDialogue(string text)
        {
            _curDialogue = text;
            if (_dialougeAnim != null)
                StopCoroutine(_dialougeAnim);
            _dialougeAnim = StartCoroutine(PlayDialogueAnim(_curDialogue));
        }

        /// <summary>
        /// 전체 대화를 즉시 표시합니다.
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