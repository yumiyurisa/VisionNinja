using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusCtr : MonoBehaviour
{
    public GameObject timer; // タイマー
    public GameObject[] Script; // 停止スクリプト
    public GameObject Player;
    static public int playerStatus;
    private bool isGameClearFade;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = 0;
        isGameClearFade = false;
    }
    // Update is called once per frame
    void Update()
    {
        StatusCtr();
    }
    private void StatusCtr()
    {
        bool isStart = timer.GetComponent<TimerCtrl>().isStart;
        bool isGameEnd = timer.GetComponent<TimerCtrl>().isGameEnd;

        if (!isStart && !isGameEnd) playerStatus = 0;
        if (isStart && !isGameEnd) playerStatus = 1;
        if (isStart && isGameEnd) playerStatus = 2;

        switch (playerStatus)
        {
            case 0:
                Script[0].GetComponent<gaugeCtrl>().enabled = true;
                Script[1].GetComponent<ItemGenerator>().enabled = false;
                Script[2].GetComponent<CloudGenerator>().enabled = true;
                Script[3].GetComponent<FogGenerator>().enabled = true;
                Script[4].GetComponent<EnemyGenerator>().enabled = false;
                PlayerDefaultMove.speed = 10.0f;
                if (this.transform.position.x >= -5f)
                {
                    Vector2 pos = this.gameObject.transform.position;
                    pos.x = -5f;
                    this.gameObject.transform.position = new Vector2(pos.x, pos.y);
                }
                break;
            case 1:
                Script[0].GetComponent<gaugeCtrl>().enabled = true;
                Script[1].GetComponent<ItemGenerator>().enabled = true;
                Script[2].GetComponent<CloudGenerator>().enabled = true;
                Script[3].GetComponent<FogGenerator>().enabled = true;
                Script[4].GetComponent<EnemyGenerator>().enabled = true;
                if (!playerCtrl.isSoulDash)
                {
                    PlayerDefaultMove.speed = 0.0f;
                    if (this.transform.position.x >= -5f)
                    {
                        Vector2 pos = this.gameObject.transform.position;
                        pos.x = -5f;
                        this.gameObject.transform.position = new Vector2(pos.x, pos.y);
                    }
                }
                else
                {
                    PlayerDefaultMove.speed = 10.0f;
                    if (this.transform.position.x >= -4f)
                    {
                        Vector2 pos = this.gameObject.transform.position;
                        pos.x = -4f;
                        this.gameObject.transform.position = new Vector2(pos.x, pos.y);
                    }
                }
                break;
            case 2:
                Script[0].GetComponent<gaugeCtrl>().enabled = false;
                Script[1].GetComponent<ItemGenerator>().enabled = false;
                Script[2].GetComponent<CloudGenerator>().enabled = false;
                Script[3].GetComponent<FogGenerator>().enabled = false;
                Script[4].GetComponent<EnemyGenerator>().enabled = false;
                PlayerDefaultMove.speed = 10.0f;
                if (this.transform.position.x >= 12f)
                {
                    Vector2 pos = this.gameObject.transform.position;
                    pos.x = 12f;
                    this.gameObject.transform.position = new Vector2(pos.x, pos.y);
                }
                if (transform.position.x >= 10.0f && !isGameClearFade)
                {
                    isGameClearFade = true;
                    FadeManager.Instance.LoadScene("ResultGame", 1.0f);
                }
                break;
        }
    }
}
