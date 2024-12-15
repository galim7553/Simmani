using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public interface IModelMap<TModel>
    {
        TModel GetModel(string key);
    }

}

