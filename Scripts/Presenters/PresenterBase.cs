using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 모든 Presenter의 기본 클래스.
    /// </summary>
    public abstract class PresenterBase
    {
        /// <summary>
        /// Presenter에서 사용하는 리소스 정리.
        /// </summary>
        public virtual void Clear()
        {

        }
    }

    /// <summary>
    /// 모델과 뷰를 포함하는 Presenter 기본 클래스.
    /// </summary>
    /// <typeparam name="TModel">모델 타입.</typeparam>
    /// <typeparam name="TView">뷰 타입.</typeparam>
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

    /// <summary>
    /// 리소스 관리가 필요한 Presenter의 기본 클래스.
    /// </summary>
    public abstract class ResourceDependentPresenterBase : PresenterBase
    {
        protected static IStringMap _stringMap;
        protected static IResourceMap _resourceMap;

        /// <summary>
        /// 리소스 의존성 초기화.
        /// </summary>
        public static void Initialize(IStringMap stringMap, IResourceMap resourceMap)
        {
            _stringMap = stringMap;
            _resourceMap = resourceMap;
        }

        /// <summary>
        /// 키에 해당하는 문자열 반환.
        /// </summary>
        public static string GetString(string key)
        {
            return _stringMap.GetString(key);
        }

        /// <summary>
        /// 키에 해당하는 리소스 반환.
        /// </summary>
        public static T GetResource<T>(string key) where T : Object
        {
            return _resourceMap.LoadResource<T>(key);
        }
    }

    /// <summary>
    /// 리소스 관리를 포함하는 Presenter의 기본 클래스.
    /// </summary>
    /// <typeparam name="TModel">모델 타입.</typeparam>
    /// <typeparam name="TView">뷰 타입.</typeparam>
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