using GamePlay.Hubs;
using GamePlay.Modules;

namespace GamePlay.Factories
{
    /// <summary>
    /// InteractableObject�� �����ϰ� �ʱ�ȭ�ϴ� ���丮 Ŭ����.
    /// </summary>
    public class InteractableObjectFactory : FactoryBase<InteractableObject, InteractableObjectModel>
    {
        IInteractorMappable _interactorMappable;

        /// <summary>
        /// InteractableObjectFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="poolManager">Ǯ ������.</param>
        /// <param name="interactorMappable">Interactor ���� ��ü.</param>
        public InteractableObjectFactory(PoolManager poolManager, IInteractorMappable interactorMappable) : base(poolManager)
        {
            _interactorMappable = interactorMappable;
        }

        /// <summary>
        /// �־��� InteractableObjectModel�� ������� InteractableObject�� �����մϴ�.
        /// </summary>
        /// <param name="model">InteractableObjectModel ��ü.</param>
        /// <returns>������ InteractableObject ��ü.</returns>
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


