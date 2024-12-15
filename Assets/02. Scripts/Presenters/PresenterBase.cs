using System.Collections;
using System.Collections.Generic;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    public abstract class PresenterBase
    {
        public virtual void Clear()
        {

        }
    }

    public abstract class PresenterBase<TModel, TView> : PresenterBase where TView : ViewBase
    {
        protected TModel _model;
        protected TView _view;

        public PresenterBase(TModel model, TView view)
        {
            _model = model;
            _view = view;
        }
    }

    public abstract class ResourceDependentPresenterBase : PresenterBase
    {
        protected static IStringMap _stringMap;
        protected static IResourceMap _resourceMap;

        public static void Initialize(IStringMap stringMap, IResourceMap resourceMap)
        {
            _stringMap = stringMap;
            _resourceMap = resourceMap;
        }

        public static string GetString(string key)
        {
            return _stringMap.GetString(key);
        }
        public static T GetResource<T>(string key) where T : Object
        {
            return _resourceMap.LoadResource<T>(key);
        }
    }

    public abstract class ResourceDependentPresenterBase<TModel, TView> : ResourceDependentPresenterBase where TView : ViewBase
    {
        protected TModel _model;
        protected TView _view;

        protected ResourceDependentPresenterBase(TModel model, TView view)
        {
            _model = model;
            _view = view;
        }
    }
}