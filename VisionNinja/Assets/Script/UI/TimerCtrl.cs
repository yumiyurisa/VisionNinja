using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{
    public GameObject Player;

    public Text timerText;

    public float totalTime;
    private int seconds;
    public bool isGameEnd;
    public bool isStart;
    private float stopTime;

    // Start is called before the first frame update
    void Start()
    {
        stopTime = 5f;


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        TimerCountdown();
        TimerGameEnd();
    }
    private void TimerCountdown()
    {
        // 敵を倒して5秒間停止する
        if (playerCtrl.isTimerStop)　stopTime -= Time.deltaTime;
        else totalTime -= Time.deltaTime;
        if (stopTime <= 0)
        {
            stopTime = 5f;
            playerCtrl.isTimerStop = false;
        }
        // ダメージを受けたら5秒間マイナスする
        if (playerCtrl.isDamage)
        {
            totalTime -= 5f;
            playerCtrl.isDamage = false;

        }
        seconds = (int)totalTime;
        if (totalTime <= 60)
        {
            timerText.text = seconds.ToString();
            isStart = true;
        }
        else timerText.text = "60";
    }
    public void TimerGameEnd()
    {
        if (totalTime <= 0f)
        {
            isGameEnd = true;
            totalTime = 0f;
        }
        else isGameEnd = false;
    }
}
