using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //アイテムプレハブ
    public GameObject EnemyPrefab;

    //生成時間間隔
    private float interval;

    //経過時間
    private float time = 0f;

    // アイテム＆出現ナンバー
    private float randItemCase;
    private int generatorNo;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(5.0f, 10.0f);


    }

    // Update is called once per frame
    void Update()
    {
        EnemyGeneratorCase();


    }
    private void EnemyGeneratorCase()
    {
        //時間計測
        time += Time.deltaTime;
        // アイテム生成パターンを決める
        if (time > interval && !playerCtrl.isWorldSwitch)
        {
            randItemCase = Random.Range(0.0f, 1.0f);
                if (randItemCase <= 1.0f) generatorNo = 1;
                switch (generatorNo)
                {
                    case 1:
                    //Enemyをインスタンス化する(生成する)
                    GameObject Enemy = Instantiate(EnemyPrefab);
                    //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
                    Enemy.transform.position = new Vector3(10, -3.0f, 0);
                    break;

                }
            time = 0f;
        }



    }
}
