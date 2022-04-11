using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gaugeCtrl : MonoBehaviour
{
    public GameObject Player;


    public float gageCollect;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().fillAmount = 0.5f;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gaugeUpdate();


    }
    private void gaugeUpdate()
    {

        float gageCnt = Player.GetComponent<playerCtrl>().gageCnt;

        if (GetComponent<Image>().fillAmount <= 0.0f)
        {
            GetComponent<Image>().fillAmount = 0.0f;
            playerCtrl.isSoulDash = false;
        }
        if (GetComponent<Image>().fillAmount >= 1.0f)
        {
            GetComponent<Image>().fillAmount = 1.0f;
        }
        gageCollect = gageCnt;
        GetComponent<Image>().fillAmount = gageCollect;
        
    }
}
