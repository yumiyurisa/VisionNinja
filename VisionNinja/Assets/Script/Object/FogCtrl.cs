using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCtrl : MonoBehaviour
{
    [SerializeField]
    private float SoulDashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動とソウルダッシュ
        bool isSoulDash = playerCtrl.isSoulDash;
        transform.position -= new Vector3(Time.deltaTime * SoulDashSpeed, 0);

        // 削除
        if (transform.position.x <= -10.0)
        {
            Destroy(this.gameObject);
        }


    }
}
