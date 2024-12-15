using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
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

        public bool IsPlaying { get; private set; } = false;
        public event Action OnPanelButtonClicked;

        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<Button>(typeof(ButtonKey));

            _dialogueText = GetTMP((int)TMPKey.DialogueText);

            GetButton((int)ButtonKey.PanelButton).onClick.AddListener(() => { OnPanelButtonClicked?.Invoke(); });
        }
        public void SetLetterWait(float letterSpan)
        {
            _letterWait = new WaitForSeconds(letterSpan);
        }

        public void PlayDialogue(string text)
        {
            _curDialogue = text;
            if (_dialougeAnim != null)
                StopCoroutine(_dialougeAnim);
            _dialougeAnim = StartCoroutine(PlayDialogueAnim(_curDialogue));
        }
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