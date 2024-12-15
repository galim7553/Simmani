using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Scene
{
    public class InteractionController
    {
        IInteractorDetector _interactorDetector;
        IInteractionPlayer _interactionPlayer;
        Transform _interactionMark;
        Camera _mainCamera;

        IInteractor _detectedInteractor;

        public InteractionController(IInteractorDetector interactorDetector,
            IInteractionPlayer interactionPlayer,
            Transform interactionMark)
        {
            _interactorDetector = interactorDetector;
            _interactionPlayer = interactionPlayer;
            _interactionMark = interactionMark;
            _mainCamera = Camera.main;

            _interactorDetector.OnInteractorDetected += OnInteractorDetected;
            _interactorDetector.OnInteractorMissed += OnInteractorMissed;
        }

        void OnInteractorDetected(IInteractor interactor)
        {
            _detectedInteractor = interactor;
            SetInteractionMarkPosition(interactor.Collider.transform);
            SetInteractionMarkActive(true);
        }
        void OnInteractorMissed()
        {
            _detectedInteractor = null;
            SetInteractionMarkActive(false);
        }

        void SetInteractionMarkActive(bool isActive)
        {
            _interactionMark.gameObject.SetActive(isActive);
        }
        void SetInteractionMarkPosition(Transform target)
        {
            _interactionMark.position = _mainCamera.WorldToScreenPoint(target.position);
        }

        public void ExecuteInteraction()
        {
            if(_detectedInteractor != null)
            {
                _interactionPlayer.ExecuteInteraction(_detectedInteractor);
            }
                
        }

        public void Clear()
        {
            _interactorDetector.Clear();
            _interactionPlayer.Clear();
        }
    }
}


