using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public interface IModelDependent<T>
    {
        void SetModel(T model);
    }
}
