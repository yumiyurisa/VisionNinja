using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageCtrl : MonoBehaviour
{
    [SerializeField] 
    private float speed,SoulDashSpeed;

    private Animator anim;

    private float reCreatePosY;
    private float reCreatePosX;

    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
        anim.SetBool("isWorldSwitch", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StageMove();
        StageWorldSwitch();

    }
    private void StageMove()
    {
        // ソウルダッシュ
        bool isSoulDash = playerCtrl.isSoulDash;
        if (!isSoulDash) transform.position -= new Vector3(Time.deltaTime * speed, 0);
        if(isSoulDash) transform.position -= new Vector3(Time.deltaTime * SoulDashSpeed, 0);


        // リセット
        if (transform.position.x <= -15f)
        {
            reCreatePosY = -4f;
            reCreatePosX = 7.5f;
            transform.position = new Vector3(reCreatePosX, reCreatePosY);
        }
    }
    private void StageWorldSwitch()
    {
        if (playerCtrl.isWorldSwitch)
        {
            anim.SetBool("isWorldSwitch", true);
        }
        else
        {
            anim.SetBool("isWorldSwitch", false);
        }

    }
}
