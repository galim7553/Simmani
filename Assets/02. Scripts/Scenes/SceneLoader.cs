using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Presenters;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace GamePlay.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] GameObject _newGameLoadingPanel;
        [SerializeField] TownLoadingView _townLoadingView;
        [SerializeField] Texture[] _mountainLoadingTextures;
        [SerializeField] GameObject _mountainLoadingPanel;
        [SerializeField] RawImage _mountainLoadingRawImage;

        WorldModel _worldModel;
        TownLoadingPresenter _townLoadingPresenter;

        public enum SceneKey
        {
            Menu,
            Town,
            Mountain,
        }

        bool _isLoading = false;
        bool _hasSkipped = false;

        public void Initialize(WorldModel worldModel)
        {
            _worldModel = worldModel;
            _townLoadingPresenter = new TownLoadingPresenter(_worldModel.StageModel, _worldModel.TimeCycleModel, _townLoadingView);
            SetAllPanelUnactive();
        }

        public void LoadScene(SceneKey sceneKey)
        {
            if(_isLoading) return;
            StartCoroutine(LoadSceneCo(sceneKey));
        }
        public void SetHasSkipped()
        {
            if(_isLoading == true)
                _hasSkipped = true;
        }
        void SetAllPanelUnactive()
        {
            _newGameLoadingPanel.SetActive(false);
            _mountainLoadingPanel.SetActive(false);
            _townLoadingPresenter.Display(false);
        }

        IEnumerator LoadSceneCo(SceneKey sceneKey)
        {
            _isLoading = true;
            _hasSkipped = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            SetAllPanelUnactive();
            switch (sceneKey)
            {
                case SceneKey.Town:
                    _newGameLoadingPanel.SetActive(!_worldModel.HasOpeningPlayed);
                    _worldModel.SetHasOpeningPlayed(true);
                    _townLoadingPresenter.Display(true);
                    break;
                case SceneKey.Menu:
                    _hasSkipped = true;
                    break;
                case SceneKey.Mountain:
                    _mountainLoadingRawImage.texture = _mountainLoadingTextures.Choose();
                    _mountainLoadingPanel.SetActive(true);
                    _hasSkipped = true;
                    break;
            }

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneKey, LoadSceneMode.Single);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                //Debug.Log("Loading progress: " + (progress * 100) + "%");

                // 로딩이 90% 이상 완료되면 대기
                if (asyncOperation.progress >= 0.9f)
                {
                    if (_hasSkipped)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }
                yield return null;
            }

            SetAllPanelUnactive();

            _isLoading = false;
            _hasSkipped = false;
        }
    }

}