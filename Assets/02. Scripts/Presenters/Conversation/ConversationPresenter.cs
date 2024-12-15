using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    public class ConversationPresenter : ResourceDependentPresenterBase<IConversationModel, ConversationView>
    {
        int _curIndex = 0;

        public bool IsPlaying { get; private set; } = false;

        public event Action OnCompleted;

        public ConversationPresenter(IConversationModel model, ConversationView view) : base(model, view)
        {
            StartConversation(model);
            _view.OnPanelButtonClicked += ExecuteNext;
        }

        public void StartConversation(IConversationModel model)
        {
            IsPlaying = true;
            _view.gameObject.SetActive(true);

            _model = model;
            _curIndex = 0;

            _view.SetLetterWait(_model.Config.LetterSpan);
            ExecuteNext();
        }
        public void StopConversation()
        {
            _view.gameObject.SetActive(false);
            IsPlaying = false;
        }

        public void ExecuteNext()
        {
            if (IsPlaying == false) return;

            if (_view.IsPlaying == true)
                _view.ShowFullDialogue();
            else
            {
                if (_curIndex >= _model.Dialogues.Count)
                {
                    StopConversation();
                    OnCompleted?.Invoke();
                    return;
                }
                _view.PlayDialogue(_model.Dialogues[_curIndex]);
                _curIndex++;
            }
                
        }

        public override void Clear()
        {
            base.Clear();

            OnCompleted = null;
            _view.OnPanelButtonClicked -= ExecuteNext;
        }
    }
}