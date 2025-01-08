using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ���(Interactor) �������̽�.
    /// </summary>
    public interface IInteractor : IModule
    {
        /// <summary>Interactor�� ������ ��.</summary>
        IInteractorModel Model { get; }

        /// <summary>��ȣ�ۿ��� ���۵� �� ȣ��Ǵ� �̺�Ʈ.</summary>
        event Action OnInteractionBegan;

        /// <summary>��ȣ�ۿ��� ����� �� ȣ��Ǵ� �̺�Ʈ.</summary>
        event Action OnInteractionEnded;

        /// <summary>��ȣ�ۿ� ������ ��Ÿ���� �ݶ��̴�.</summary>
        Collider Collider { get; }

        /// <summary>��ȣ�ۿ��� �����մϴ�.</summary>
        void BeginInteraction();

        /// <summary>��ȣ�ۿ��� �����մϴ�.</summary>
        void EndInteraction();
    }
}