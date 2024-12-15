using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs
{
    public class InteractableObject : ObjectHub, IModelDependent<InteractableObjectModel>
    {
        public class InteractableObjectComponents
        {
            public Collider Collider { get; private set; }
            public InteractableObjectComponents(Collider collider)
            {
                Collider = collider;
            }
        }

        public InteractableObjectModel Model { get; private set; }
        public InteractableObjectComponents Components { get; private set; }


        private void Awake()
        {
            Components = new InteractableObjectComponents(GetComponent<Collider>());
        }
        public void SetModel(InteractableObjectModel model)
        {
            Model = model;
        }

        public override void Initialize()
        {
            if (Modules.HasInitialized == false)
            {
                LogUninitializedModuleError();
                return;
            }

            IInteractor interactor = Modules.Get<IInteractor>();
            interactor.OnInteractionEnded += DestroyOrReturnToPool;
        }

    }
}