using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// ��� Presenter�� �⺻ Ŭ����.
    /// </summary>
    public abstract class PresenterBase
    {
        /// <summary>
        /// Presenter���� ����ϴ� ���ҽ� ����.
        /// </summary>
        public virtual void Clear()
        {

        }
    }

    /// <summary>
    /// �𵨰� �並 �����ϴ� Presenter �⺻ Ŭ����.
    /// </summary>
    /// <typeparam name="TModel">�� Ÿ��.</typeparam>
    /// <typeparam name="TView">�� Ÿ��.</typeparam>
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
    /// ���ҽ� ������ �ʿ��� Presenter�� �⺻ Ŭ����.
    /// </summary>
    public abstract class ResourceDependentPresenterBase : PresenterBase
    {
        protected static IStringMap _stringMap;
        protected static IResourceMap _resourceMap;

        /// <summary>
        /// ���ҽ� ������ �ʱ�ȭ.
        /// </summary>
        public static void Initialize(IStringMap stringMap, IResourceMap resourceMap)
        {
            _stringMap = stringMap;
            _resourceMap = resourceMap;
        }

        /// <summary>
        /// Ű�� �ش��ϴ� ���ڿ� ��ȯ.
        /// </summary>
        public static string GetString(string key)
        {
            return _stringMap.GetString(key);
        }

        /// <summary>
        /// Ű�� �ش��ϴ� ���ҽ� ��ȯ.
        /// </summary>
        public static T GetResource<T>(string key) where T : Object
        {
            return _resourceMap.LoadResource<T>(key);
        }
    }

    /// <summary>
    /// ���ҽ� ������ �����ϴ� Presenter�� �⺻ Ŭ����.
    /// </summary>
    /// <typeparam name="TModel">�� Ÿ��.</typeparam>
    /// <typeparam name="TView">�� Ÿ��.</typeparam>
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