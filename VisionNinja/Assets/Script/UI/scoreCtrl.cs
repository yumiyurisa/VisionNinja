using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreCtrl : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public GameObject Player = null; // Playerオブジェクト
    public static int score = 0; // スコア変数
    private Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        // スコアのロード
        score = PlayerPrefs.GetInt("", 0);
        DontDestroyOnLoad(this);

    }
    void OnDestroy()
    {
        // スコアを保存
        PlayerPrefs.SetInt("", score);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        scoreUpdate();


    }
    void scoreUpdate()
    {
        // オブジェクトからTextコンポーネントを取得
        score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "" + score;
        int scoreCnt = Player.GetComponent<playerCtrl>().scoreCnt;
        score = scoreCnt;

    }

}
