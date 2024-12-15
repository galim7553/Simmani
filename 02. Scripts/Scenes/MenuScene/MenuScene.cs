using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GamePlay.Scene
{
    public class MenuScene : MonoBehaviour
    {
        [SerializeField] Button _singlePlayButton;

        private void Awake()
        {
            _singlePlayButton.onClick.AddListener(OnSinglePlayButtonClicked);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void OnSinglePlayButtonClicked()
        {
            GameManager.Inst.SceneLoader.LoadScene(SceneLoader.SceneKey.Town);
        }
    }
}