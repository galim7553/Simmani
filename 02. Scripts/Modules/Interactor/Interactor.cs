using System;
using UnityEngine;

namespace GamePlay.Modules
{

    /// <summary>
    /// ��ȣ�ۿ���(Interactor)�� �⺻ ���� Ŭ����.
    /// </summary>
    public class Interactor : ModuleBase, IInteractor
    {
        public IInteractorModel Model { get; private set; }
        public Collider Collider { get; private set; }

        public event Action OnInteractionBegan;
        public event Action OnInteractionEnded;


        /// <summary>
        /// Interactor ������.
        /// </summary>
        /// <param name="model">Interactor ��.</param>
        /// <param name="collider">��ȣ�ۿ� ���� �ݶ��̴�.</param>
        /// <param name="interactorMappable">Interactor�� ������ ����.</param>
        public Interactor(IInteractorModel model, Collider collider, IInteractorMappable interactorMappable)
        {
            Model = model;
            Collider = collider;
            interactorMappable.AddInteractor(this);
        }

        public void BeginInteraction()
        {
            OnInteractionBegan?.Invoke();
        }

        public void EndInteraction()
        {
            OnInteractionEnded?.Invoke();
        }
    }
}


