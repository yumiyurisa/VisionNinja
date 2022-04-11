using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    //プレハブ
    public GameObject CloudPrefab;
    //生成時間間隔
    public float interval;
    public float Soulinterval;

    //経過時間
    private float time = 0f;

    private int LineMax = 3;
    private float posx, posy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        time += Time.deltaTime;
        // 経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (!playerCtrl.isSoulDash) {
            if (time > interval)
            {
                for (int i = 0; i <= LineMax; i++)
                {
                    posx = Random.Range(10.0f, 30.0f);
                    posy = Random.Range(1.0f, 5.0f);
                    // Itemをインスタンス化する(生成する)                     
                    GameObject Cloud = Instantiate(CloudPrefab);
                    // 生成したアイテムの座標を決定する                    
                    Cloud.transform.position = new Vector3(posx, posy, 0);
                }
                time = 0f;
            }
        }
        else
        {
            if (time > Soulinterval)
            {
                for (int i = 0; i <= LineMax; i++)
                {
                    posx = Random.Range(10.0f, 30.0f);
                    posy = Random.Range(1.0f, 5.0f);
                    // Itemをインスタンス化する(生成する)                     
                    GameObject Cloud = Instantiate(CloudPrefab);
                    // 生成したアイテムの座標を決定する                    
                    Cloud.transform.position = new Vector3(posx, posy, 0);
                }
                time = 0f;
            }
        }

    }
}
