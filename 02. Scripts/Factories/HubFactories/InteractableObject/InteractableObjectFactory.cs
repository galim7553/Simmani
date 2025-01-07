using GamePlay.Hubs;
using GamePlay.Modules;

namespace GamePlay.Factories
{
    /// <summary>
    /// InteractableObject를 생성하고 초기화하는 팩토리 클래스.
    /// </summary>
    public class InteractableObjectFactory : FactoryBase<InteractableObject, InteractableObjectModel>
    {
        IInteractorMappable _interactorMappable;

        /// <summary>
        /// InteractableObjectFactory를 초기화합니다.
        /// </summary>
        /// <param name="poolManager">풀 관리자.</param>
        /// <param name="interactorMappable">Interactor 매핑 객체.</param>
        public InteractableObjectFactory(PoolManager poolManager, IInteractorMappable interactorMappable) : base(poolManager)
        {
            _interactorMappable = interactorMappable;
        }

        /// <summary>
        /// 주어진 InteractableObjectModel을 기반으로 InteractableObject를 생성합니다.
        /// </summary>
        /// <param name="model">InteractableObjectModel 객체.</param>
        /// <returns>생성된 InteractableObject 객체.</returns>
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


