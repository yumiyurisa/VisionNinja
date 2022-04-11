using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MaineGames : MonoBehaviour
{

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        Screen.SetResolution(1280, 720, false, 60);
        FadeManager.Instance.LoadScene("MaineGames", 1.0f);
    }
    //　ゲーム終了ボタンを押したら実行する
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }
}