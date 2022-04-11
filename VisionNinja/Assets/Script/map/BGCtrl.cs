using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCtrl : MonoBehaviour
{
    [SerializeField] private float speed;
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
        BGMove();
        StageWorldSwitch();

    }    
    private void BGMove()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0);            
        if (transform.position.x <= -23.8f)
        {
            transform.position = new Vector3(23.8f, -0.64f);
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
