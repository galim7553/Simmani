using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IModule
    {
        void SetActive(bool isActive);
        void Clear();
    }


}


