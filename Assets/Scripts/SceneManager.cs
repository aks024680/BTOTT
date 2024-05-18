﻿
using UnityEngine;

namespace BTOTT
{
    /// <summary>
    /// 場景管理器:切換場景與退出遊戲
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [SerializeField, Range(0.3f, 3), Header("音效時間")]
        private float soundDuration = 2.2f;

        private string nameSceneToChange;
        public void ChangeScene(string nameScene)
        {
            print("切換場景");
            UnityEngine.SceneManagement.SceneManager.LoadScene("BeforeTOTT");
            nameSceneToChange = nameScene;
            Invoke("DelayChangeScene", soundDuration);

        }

        public void Quit()
        {
            print("退出遊戲");
            Application.Quit();
        }

        private void DelayChangeScene()
        {
            // print("切換場景");
            UnityEngine.SceneManagement.SceneManager.LoadScene(nameSceneToChange);
        }
    }
}

