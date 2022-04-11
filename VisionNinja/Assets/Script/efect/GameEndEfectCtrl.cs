using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndEfectCtrl : MonoBehaviour
{
    public GameObject gameEndEffect;
    public GameObject player; // タイマー
    private bool breakLoop;
    private float resultMoveCnt;


    // Start is called before the first frame update
    void Start()
    {
        breakLoop = false;
        resultMoveCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool isFade = player.GetComponent<playerCtrl>().isFade;
        if (isFade && !breakLoop)
        {        
            Instantiate(gameEndEffect, this.transform.position, Quaternion.identity); //Effectを表示
            breakLoop = true;
            resultMoveCnt++;
            if (resultMoveCnt >= 90f)FadeManager.Instance.LoadScene("ResultGame", 1.0f);

        }

    }
}
