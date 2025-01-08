using System.Collections;
using GamePlay.Presenters;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GamePlay.Scene
{
    /// <summary>
    /// �� ��ȯ �� �ε� ȭ���� �����ϴ� Ŭ����.
    /// �پ��� �������� ��ȯ �� �ε� ���¸� �ð������� ǥ���մϴ�.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] GameObject _newGameLoadingPanel; // �� ���� �ε� �г�
        [SerializeField] TownLoadingView _townLoadingView; // ���� �ε� ȭ�� ��
        [SerializeField] Texture[] _mountainLoadingTextures; // �� �ε� ȭ�� �ؽ�ó �迭
        [SerializeField] GameObject _mountainLoadingPanel; // �� �ε� �г�
        [SerializeField] RawImage _mountainLoadingRawImage; // �� �ε� �г��� �̹���

        WorldModel _worldModel; // ���� �� ����
        TownLoadingPresenter _townLoadingPresenter; // ���� �ε� ȭ���� ��������

        /// <summary>
        /// �� Ű�� ��Ÿ���� ������. �پ��� ���� �����մϴ�.
        /// </summary>
        public enum SceneKey
        {
            Menu,
            Town,
            Mountain,
        }

        bool _isLoading = false; // ���� �ε� ������ ����
        bool _hasSkipped = false; // �ε� ��ŵ ����

        /// <summary>
        /// SceneLoader�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="worldModel">���� �� ����</param>
        public void Initialize(WorldModel worldModel)
        {
            _worldModel = worldModel;
            _townLoadingPresenter = new TownLoadingPresenter(_worldModel.StageModel, _worldModel.TimeCycleModel, _townLoadingView);
            SetAllPanelUnactive(); // ��� �ε� �г� ��Ȱ��ȭ
        }

        /// <summary>
        /// ������ ���� �ε��մϴ�.
        /// </summary>
        /// <param name="sceneKey">�ε��� ���� Ű</param>
        public void LoadScene(SceneKey sceneKey)
        {
            if (_isLoading) return; // �̹� �ε� ���̸� ����
            StartCoroutine(LoadSceneCo(sceneKey));
        }

        /// <summary>
        /// �ε� ȭ���� ��ŵ�ϵ��� �����մϴ�.
        /// </summary>
        public void SetHasSkipped()
        {
            if (_isLoading)
                _hasSkipped = true;
        }

        /// <summary>
        /// ��� �ε� �г��� ��Ȱ��ȭ�մϴ�.
        /// </summary>
        void SetAllPanelUnactive()
        {
            _newGameLoadingPanel.SetActive(false);
            _mountainLoadingPanel.SetActive(false);
            _townLoadingPresenter.Display(false);
        }

        /// <summary>
        /// ���� �񵿱�� �ε��մϴ�.
        /// </summary>
        /// <param name="sceneKey">�ε��� ���� Ű</param>
        /// <returns>�ڷ�ƾ</returns>
        IEnumerator LoadSceneCo(SceneKey sceneKey)
        {
            _isLoading = true;
            _hasSkipped = false;

            // Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            SetAllPanelUnactive(); // ��� �г� ��Ȱ��ȭ

            // �� Ű�� ���� �ε� ȭ�� ����
            switch (sceneKey)
            {
                case SceneKey.Town:
                    _newGameLoadingPanel.SetActive(!_worldModel.HasOpeningPlayed);
                    _worldModel.SetHasOpeningPlayed(true);
                    _townLoadingPresenter.Display(true);
                    break;
                case SceneKey.Menu:
                    _hasSkipped = true; // �޴��� ��� �ε�
                    break;
                case SceneKey.Mountain:
                    _mountainLoadingRawImage.texture = _mountainLoadingTextures.Choose(); // ���� �ؽ�ó ����
                    _mountainLoadingPanel.SetActive(true);
                    _hasSkipped = true;
                    break;
            }

            // �񵿱� �� �ε� ����
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneKey, LoadSceneMode.Single);
            asyncOperation.allowSceneActivation = false; // �ε� �Ϸ� ������ �� Ȱ��ȭ ��Ȱ��

            // �ε� ����� Ȯ��
            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                // �ε��� �Ϸ�Ǿ��� ��ŵ�� �����Ǹ� �� Ȱ��ȭ
                if (asyncOperation.progress >= 0.9f)
                {
                    if (_hasSkipped)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }
                yield return null;
            }

            // �ε� �Ϸ� �� �г� ��Ȱ��ȭ
            SetAllPanelUnactive();

            _isLoading = false;
            _hasSkipped = false;
        }
    }
}