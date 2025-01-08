using UnityEngine;

namespace GamePlay.Modules
{
    public abstract class ModuleBase : IModule
    {
        public bool IsActive { get; private set; } = true;

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public virtual void Clear()
        {

        }

        //~ModuleBase()
        //{
        //    Debug.Log(this.GetType());
        //}
    }
}

