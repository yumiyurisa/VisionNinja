using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    [SerializeField]
    private float speed,SoulDashSpeed;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
        anim.SetBool("isWorldSwitch", false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ItemMove();
        StageUPWorldSwitch();

    }
    public void ItemMove()
    {

        // 移動とソウルダッシュ
        bool isSoulDash = playerCtrl.isSoulDash;
        if (!isSoulDash)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0);

        }
        if (isSoulDash)
        {
            transform.position -= new Vector3(Time.deltaTime * SoulDashSpeed, 0);

        }
        // 削除
        if (transform.position.x <= -10.0)
        {
            Destroy(this.gameObject);
        }
    }
    private void StageUPWorldSwitch()
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