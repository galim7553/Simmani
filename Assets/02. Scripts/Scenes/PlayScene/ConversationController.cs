using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Commands;
using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Presenters;
using GamePlay.Views;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Scene
{
    public class ConversationController : IConversationPlayer
    {
        IModelMap<IConversationModel> _conversationModelMap;
        ConversationView _conversationView;
        
        ConversationPresenter _conversationPresenter;

        public bool IsPlaying => _conversationPresenter == null ? false : _conversationPresenter.IsPlaying;
        public event Action OnCompleted;

        public ConversationController(IModelMap<IConversationModel> conversationModelMap, ConversationView view)
        {
            _conversationModelMap = conversationModelMap;
            _conversationView = view;
        }

        public void ExecuteNext()
        {
            _conversationPresenter.ExecuteNext();
        }

        public void StartConversation(string conversationKey)
        {
            IConversationModel model = _conversationModelMap.GetModel(conversationKey);
            StartConversation(model);
        }
        void StartConversation(IConversationModel model)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (_conversationPresenter == null)
            {
                _conversationPresenter = new ConversationPresenter(model, _conversationView);
                _conversationPresenter.OnCompleted += OnConversationCompleted;
            }
                
            else
                _conversationPresenter.StartConversation(model);
        }
        void OnConversationCompleted()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            OnCompleted?.Invoke();
        }
        public void StopConversation()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _conversationPresenter.StopConversation();
        }


        public void Clear()
        {
            _conversationPresenter.Clear();
            OnCompleted = null;
        }
    }
}


