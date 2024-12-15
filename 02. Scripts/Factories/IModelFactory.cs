using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public interface IModelFactory<TModel>
    {
        TModel CreateModel(string key);
    }
    public interface IModelFactory<TModel, TData>
    {
        TModel CreateModel(TData data);
    }
}