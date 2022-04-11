using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrl : MonoBehaviour
{
    [SerializeField]
    private float speed, SoulDashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineMove();
    }
    public void LineMove()
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

}
