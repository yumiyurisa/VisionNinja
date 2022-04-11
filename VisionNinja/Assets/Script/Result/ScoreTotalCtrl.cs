using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotalCtrl : MonoBehaviour
{
    public Text result_Text;

    private int resultscore;
    private int cntScore;
    public bool isResult;
    private bool isRanking;

    // Start is called before the first frame update
    void Start()
    {
        resultscore = scoreCtrl.score;
        result_Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (cntScore != resultscore) cntScore++;
        else isResult = true;
        result_Text.text = "" + cntScore;
        if (Input.GetMouseButtonDown(0) && !isResult)
        {
            cntScore = resultscore;

        }
    }
    public void ToTitle()
    {
        if (isResult)
        {
            FadeManager.Instance.LoadScene("TitleGame", 1.0f);
        }
    }
    public void ToRetry()
    {
        if (isResult)
        {
            FadeManager.Instance.LoadScene("MaineGames", 1.0f);
        }
    }
    public void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(resultscore);
    }
}
