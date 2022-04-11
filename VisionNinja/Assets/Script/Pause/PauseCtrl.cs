using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCtrl : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject pauseText;
    [SerializeField]
    private GameObject reStartButton;
    [SerializeField]
    private GameObject reTitle;
    [SerializeField]
    private GameObject Panel;

    public GameObject[] Script;

    void Start()
    {
        Panel.SetActive(false);
        reStartButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseText.SetActive(false);
        reTitle.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
        reStartButton.SetActive(true);
        pauseButton.SetActive(true);
        pauseText.SetActive(true);
        reTitle.SetActive(true);
        Script[0].GetComponent<gaugeCtrl>().enabled = false;

    }
    public void ReStartGame()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
        reStartButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseText.SetActive(false);
        reTitle.SetActive(false);
        Script[0].GetComponent<gaugeCtrl>().enabled = true;

    }
    public void ReTitleGame()
    {
        Time.timeScale = 1f;
        FadeManager.Instance.LoadScene("TitleGame", 1.0f);

    }

}