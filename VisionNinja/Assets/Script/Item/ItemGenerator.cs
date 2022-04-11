using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //アイテムプレハブ
    public GameObject ItmePrefab;
    public GameObject[] StageUPPrefab;

    //生成時間間隔
    public float interval;
    public float Soulinterval;

    //経過時間
    private float time = 0f;
    public float posy;

    // アイテム＆出現ナンバー
    private float randItemCase;
    private int generatorNo;

    // アイテム最大数
    private int itemMax = 10;
    private float bonusItemMax = 50;

    // Start is called before the first frame update
    void Start()
    {


    }
    private void Update()
    {
        ItemGeneratorCase();

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
    }
    private void ItemGeneratorCase()
    {
        // 時間計測
        time += Time.deltaTime;
        // アイテム生成パターンを決める
        if (time > interval && !playerCtrl.isSoulDash || time > Soulinterval && playerCtrl.isSoulDash)
        {
            randItemCase = Random.Range(0.0f, 1.0f);
            for (int i = 0; i <= itemMax; i++)
            {
                if (randItemCase <= 0.1f) generatorNo = 1;
                if (randItemCase > 0.1f && randItemCase <= 0.2f) generatorNo = 2;
                if (randItemCase > 0.2f && randItemCase <= 0.3f) generatorNo = 3;
                if (randItemCase > 0.3f && randItemCase <= 0.4f) generatorNo = 4;
                if (randItemCase > 0.4f && randItemCase <= 0.5f) generatorNo = 5;
                if (randItemCase > 0.6f && randItemCase <= 0.7f) generatorNo = 6;
                if (randItemCase > 0.7f && randItemCase <= 0.8f) generatorNo = 7;
                if (randItemCase > 0.8f && randItemCase <= 0.9f) generatorNo = 8;
                if (randItemCase > 0.9f && randItemCase <= 1) generatorNo = 9;

                switch (generatorNo)
                {
                    case 1:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo1 = Instantiate(ItmePrefab);
                        //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
                        ItemNo1.transform.position = new Vector3(10 + (2 * i), posy, 0);
                        break;

                    case 2:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo2 = Instantiate(ItmePrefab);
                        ItemNo2.transform.position = new Vector3(10 + (1 * i), posy + (0.5f * i), 0);
                        break;

                    case 3:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo3 = Instantiate(ItmePrefab);
                        ItemNo3.transform.position = new Vector3(10 + (1 * i), (posy + 5) - (0.5f * i), 0);

                        break;
                    case 4:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo4 = Instantiate(ItmePrefab);
                        // 足場をインスタンス化する(生成する)
                        GameObject stage = Instantiate(StageUPPrefab[0]);
                        ItemNo4.transform.position = new Vector3(10 + (2 * i), (posy + 3), 0);
                        stage.transform.position = new Vector3(10 + (2 * i), (posy + 1.5f), 0);
                        break;

                    case 5:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo5_1 = Instantiate(ItmePrefab);
                        GameObject ItemNo5_2 = Instantiate(ItmePrefab);
                        ItemNo5_1.transform.position = new Vector3(10 + (1 * i), (posy + 5) - (0.5f * i), 0);
                        ItemNo5_2.transform.position = new Vector3(20 + (1 * i), posy + (0.5f * i), 0);
                        break;
                    case 6:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo6_1 = Instantiate(ItmePrefab);
                        GameObject ItemNo6_2 = Instantiate(ItmePrefab);
                        ItemNo6_1.transform.position = new Vector3(10 + (1 * i), posy, 0);
                        ItemNo6_2.transform.position = new Vector3(20 + (1 * i), posy + 1.5f, 0);
                        break;
                    case 7:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo7_1 = Instantiate(ItmePrefab);
                        GameObject ItemNo7_2 = Instantiate(ItmePrefab);
                        //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
                        ItemNo7_1.transform.position = new Vector3(10 + (1 * i), posy+ 1.5f, 0);
                        ItemNo7_2.transform.position = new Vector3(20 + (1 * i), posy, 0);
                        break;
                    case 8:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo8_1 = Instantiate(ItmePrefab);
                        GameObject ItemNo8_2 = Instantiate(ItmePrefab);
                        ItemNo8_1.transform.position = new Vector3(20 + (1 * i), (posy + 5) - (0.5f * i), 0);
                        ItemNo8_2.transform.position = new Vector3(10 + (1 * i), posy + (0.5f * i), 0);
                        break;
                    case 9:
                        // Itemをインスタンス化する(生成する)
                        GameObject ItemNo9_1 = Instantiate(ItmePrefab);
                        GameObject ItemNo9_2 = Instantiate(ItmePrefab);
                        ItemNo9_1.transform.position = new Vector3(10 + (1 * i), posy, 0);
                        ItemNo9_2.transform.position = new Vector3(10 + (1 * i), posy + 1f, 0);
                        break;
                    case 10:
                        for (int n = 0;n <= bonusItemMax; n++)
                        {
                            if (n < 10)
                            {
                                // Itemをインスタンス化する(生成する)                     
                                GameObject Item = Instantiate(ItmePrefab);
                                // 生成したアイテムの座標を決定する                    
                                Item.transform.position = new Vector3(10 + (1 * n), posy, 0);
                            }
                            if (n >= 10 && n < 20)
                            {
                                // Itemをインスタンス化する(生成する)                     
                                GameObject Item = Instantiate(ItmePrefab);
                                // 生成したアイテムの座標を決定する                    
                                Item.transform.position = new Vector3(10 + (1 * (n - 10)), posy + 1, 0);
                            }
                            if (n >= 20 && n < 30)
                            {
                                // Itemをインスタンス化する(生成する)                     
                                GameObject Item = Instantiate(ItmePrefab);
                                // 生成したアイテムの座標を決定する                    
                                Item.transform.position = new Vector3(10 + (1 * (n - 20)), posy + 2, 0);
                            }
                            if (n >= 30 && n < 40)
                            {
                                // Itemをインスタンス化する(生成する)                     
                                GameObject Item = Instantiate(ItmePrefab);
                                // 生成したアイテムの座標を決定する                    
                                Item.transform.position = new Vector3(10 + (1 * (n - 30)), posy + 3, 0);
                            }
                            if (n >= 40 && n < 50)
                            {
                                // Itemをインスタンス化する(生成する)                     
                                GameObject Item = Instantiate(ItmePrefab);
                                // 生成したアイテムの座標を決定する                    
                                Item.transform.position = new Vector3(10 + (1 * (n - 40)), posy + 4, 0);
                            }
                        }
                        break;
                }
            }
            time = 0f;
        }
    }
}
