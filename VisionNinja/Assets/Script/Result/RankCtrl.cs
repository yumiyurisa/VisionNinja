using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RankCtrl : MonoBehaviour
{
    public Text result_Rank;
    public GameObject result = null;

    string resultRank;
    int resultscore;


    // Start is called before the first frame update
    void Start()
    {
        resultscore = scoreCtrl.score;
        result_Rank.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        bool resultFlg = result.GetComponent<ScoreTotalCtrl>().isResult;

        if (resultFlg) { 
        if (resultscore < 30000) resultRank = "C";
        if (resultscore < 40000 && resultscore >= 30000) resultRank = "B";
        if (resultscore < 55000 && resultscore >= 40000) resultRank = "A";
        if (resultscore >= 55000) resultRank = "S";
        }
        result_Rank.text = "" + resultRank;


    }
}
