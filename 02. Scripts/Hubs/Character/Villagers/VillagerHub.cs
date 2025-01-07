using UnityEngine;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 마을 주민 구현.
    /// </summary>
    public class VillagerHub : ObjectHub
    {
        public class VillagerComponents
        {
            public Collider Collider { get; private set; }
            public VillagerComponents(Collider collider)
            {
                Collider = collider;
            }
        }

        public VillagerModel Model { get; private set; }
        public VillagerComponents Components { get; private set; }

        private void Awake()
        {
            Components = new VillagerComponents(GetComponent<Collider>());
        }

        public void SetModel(VillagerModel model)
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
        }
    }
}


