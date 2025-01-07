using System.Collections;
using GamePlay.Presenters;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GamePlay.Scene
{
    /// <summary>
    /// 씬 전환 및 로딩 화면을 관리하는 클래스.
    /// 다양한 씬으로의 전환 및 로딩 상태를 시각적으로 표현합니다.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] GameObject _newGameLoadingPanel; // 새 게임 로딩 패널
        [SerializeField] TownLoadingView _townLoadingView; // 마을 로딩 화면 뷰
        [SerializeField] Texture[] _mountainLoadingTextures; // 산 로딩 화면 텍스처 배열
        [SerializeField] GameObject _mountainLoadingPanel; // 산 로딩 패널
        [SerializeField] RawImage _mountainLoadingRawImage; // 산 로딩 패널의 이미지

        WorldModel _worldModel; // 월드 모델 참조
        TownLoadingPresenter _townLoadingPresenter; // 마을 로딩 화면의 프레젠터

        /// <summary>
        /// 씬 키를 나타내는 열거형. 다양한 씬을 구분합니다.
        /// </summary>
        public enum SceneKey
        {
            Menu,
            Town,
            Mountain,
        }

        bool _isLoading = false; // 현재 로딩 중인지 여부
        bool _hasSkipped = false; // 로딩 스킵 여부

        /// <summary>
        /// SceneLoader를 초기화합니다.
        /// </summary>
        /// <param name="worldModel">월드 모델 참조</param>
        public void Initialize(WorldModel worldModel)
        {
            _worldModel = worldModel;
            _townLoadingPresenter = new TownLoadingPresenter(_worldModel.StageModel, _worldModel.TimeCycleModel, _townLoadingView);
            SetAllPanelUnactive(); // 모든 로딩 패널 비활성화
        }

        /// <summary>
        /// 지정된 씬을 로드합니다.
        /// </summary>
        /// <param name="sceneKey">로드할 씬의 키</param>
        public void LoadScene(SceneKey sceneKey)
        {
            if (_isLoading) return; // 이미 로딩 중이면 무시
            StartCoroutine(LoadSceneCo(sceneKey));
        }

        /// <summary>
        /// 로딩 화면을 스킵하도록 설정합니다.
        /// </summary>
        public void SetHasSkipped()
        {
            if (_isLoading)
                _hasSkipped = true;
        }

        /// <summary>
        /// 모든 로딩 패널을 비활성화합니다.
        /// </summary>
        void SetAllPanelUnactive()
        {
            _newGameLoadingPanel.SetActive(false);
            _mountainLoadingPanel.SetActive(false);
            _townLoadingPresenter.Display(false);
        }

        /// <summary>
        /// 씬을 비동기로 로드합니다.
        /// </summary>
        /// <param name="sceneKey">로드할 씬의 키</param>
        /// <returns>코루틴</returns>
        IEnumerator LoadSceneCo(SceneKey sceneKey)
        {
            _isLoading = true;
            _hasSkipped = false;

            // 커서 상태 설정
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            SetAllPanelUnactive(); // 모든 패널 비활성화

            // 씬 키에 따른 로딩 화면 설정
            switch (sceneKey)
            {
                case SceneKey.Town:
                    _newGameLoadingPanel.SetActive(!_worldModel.HasOpeningPlayed);
                    _worldModel.SetHasOpeningPlayed(true);
                    _townLoadingPresenter.Display(true);
                    break;
                case SceneKey.Menu:
                    _hasSkipped = true; // 메뉴는 즉시 로드
                    break;
                case SceneKey.Mountain:
                    _mountainLoadingRawImage.texture = _mountainLoadingTextures.Choose(); // 랜덤 텍스처 선택
                    _mountainLoadingPanel.SetActive(true);
                    _hasSkipped = true;
                    break;
            }

            // 비동기 씬 로드 시작
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneKey, LoadSceneMode.Single);
            asyncOperation.allowSceneActivation = false; // 로딩 완료 전까지 씬 활성화 비활성

            // 로딩 진행률 확인
            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                // 로딩이 완료되었고 스킵이 설정되면 씬 활성화
                if (asyncOperation.progress >= 0.9f)
                {
                    if (_hasSkipped)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }
                yield return null;
            }

            // 로딩 완료 후 패널 비활성화
            SetAllPanelUnactive();

            _isLoading = false;
            _hasSkipped = false;
        }
    }
}