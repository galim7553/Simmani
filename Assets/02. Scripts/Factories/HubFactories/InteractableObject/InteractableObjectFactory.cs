using GamePlay.Hubs;
using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class InteractableObjectFactory : FactoryBase<InteractableObject, InteractableObjectModel>
    {
        IInteractorMappable _interactorMappable;

        public InteractableObjectFactory(PoolManager poolManager, IInteractorMappable interactorMappable) : base(poolManager)
        {
            _interactorMappable = interactorMappable;
        }

        public override InteractableObject Create(InteractableObjectModel model)
        {
            InteractableObject interactableObject = _poolManager.GetFromPool(model.PrefabPath).GetOrAddComponent<InteractableObject>();

            interactableObject.SetModel(model);

            interactableObject.Modules.Set<IInteractor>(new Interactor(model.InteractorModel, interactableObject.Components.Collider, _interactorMappable));

            interactableObject.Modules.Initialize();
            interactableObject.Initialize();

            return interactableObject;
        }
    }
}


