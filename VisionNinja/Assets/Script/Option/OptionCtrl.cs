using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject optionButton;
    [SerializeField]
    private GameObject option;

    [SerializeField]
    private GameObject credit;
    [SerializeField]
    private GameObject Help;

    [SerializeField]
    private GameObject notSound;
    [SerializeField]
    private GameObject notMusic;


    public static bool isMusic = true;
    public static bool isSound = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    public void OptionWake()
    {
        // オプションボタンが押されたとき
        Time.timeScale = 0f;
        optionButton.SetActive(true);

        option.SetActive(true);
        credit.SetActive(false);
        Help.SetActive(false);
        if (isSound) notSound.SetActive(false);
        else notSound.SetActive(true);
        if (isMusic) notMusic.SetActive(false);
        else notMusic.SetActive(true);
    }
    public void ReStart()
    {
        // オプション画面の戻るボタンが押されたとき
        Time.timeScale = 1f;
        optionButton.SetActive(true);

        option.SetActive(false);
        credit.SetActive(false);
        Help.SetActive(false);
        notMusic.SetActive(false);
        notSound.SetActive(false);

    }
    public void HelpWake()
    {
        // ヘルプボタンが押されたとき
        Time.timeScale = 0f;
        optionButton.SetActive(true);

        option.SetActive(true);
        credit.SetActive(false);
        Help.SetActive(true);
    }

    public void SoundWake() {

        // サウンドボタンが押されたとき
        if (isSound)
        {
            isSound = false;
            notSound.SetActive(true);
        }
        else
        {
            isSound = true;
            notSound.SetActive(false);
        }
    }
    public void MusicWake()
    {
        // ミュージックボタンが押されたとき
        if (isMusic)
        {
            isMusic = false;
            notMusic.SetActive(true);
        }
        else
        {
            isMusic = true;
            SoundBGM.isMusicS = false;
            notMusic.SetActive(false);
        }
    }
    public void CreditWake()
    {
        // クレジットボタンが押されたとき
        Time.timeScale = 0f;
        optionButton.SetActive(true);

        option.SetActive(true);
        credit.SetActive(true);
        Help.SetActive(false);
    }

    public void HelpCreditRestart()
    {
        // オプション画面の戻るボタンが押されたとき
        Time.timeScale = 0f;
        optionButton.SetActive(true);

        option.SetActive(true);
        credit.SetActive(false);
        Help.SetActive(false);
    }
}
