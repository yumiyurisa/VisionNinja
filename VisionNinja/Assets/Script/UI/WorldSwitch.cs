using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
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
        if (playerCtrl.isWorldSwitch) anim.SetBool("isWorldSwitch", true);
        else anim.SetBool("isWorldSwitch", false);


    }
}
