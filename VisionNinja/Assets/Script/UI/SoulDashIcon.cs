using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDashIcon : MonoBehaviour
{
    private Animator anim; // AnimatorComponent（アニメーション）

    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerCtrl.isSoulDash) anim.SetBool("isSoulDash", true);
        else anim.SetBool("isSoulDash", false);
    }
}
