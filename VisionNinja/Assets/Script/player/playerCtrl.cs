using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public GameObject breakEffect; //倒したときのエフェクト

    private Rigidbody2D rd2d; // Rigidbody2DComponent（物理演算）
    AudioSource audioSource;

    public int scoreCnt; // ゲームスコア
    public float gageCnt; // ゲームゲージ量
    public static bool isSoulDash; // ソウルダッシュ判定
    public static bool isWorldSwitch; // ソウルダッシュ判定
    public static bool isTimerStop;
    public static bool isDamage;
    private bool isDamageEfect;
    private int isDamageCnt;
    public bool isFade;

    public AudioClip sound1; // SE


    // Start is called before the first frame update
    void Start()
    {
        // component宣言
        audioSource = GetComponent<AudioSource>();
        isSoulDash = false;
        isWorldSwitch = false;
    }
    // Update is called once per frame
    void Update()
    {
        Damage();
        PlayerGage();
    }
    private void PlayerGage()
    {
        // ソウルダッシュ中ゲージはダウン
        if (isSoulDash) gageCnt -= 0.002f;
        else gageCnt -= 0f;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーとアイテムのあたり判定処理
        // アイテム削除、スコア獲得、ゲージ量上昇
        if (other.gameObject.tag == "Item" && !isWorldSwitch)
        {
            scoreCnt += 100;
            Destroy(other.gameObject);
            GenerateEffect();
        }

        if (other.gameObject.tag == "Item" &&isWorldSwitch)
        {
            if(gageCnt <= 1) gageCnt += 0.05f;
            if (gageCnt >= 1) gageCnt = 1.0f;
                Destroy(other.gameObject);
            GenerateEffect();
        }
        if (other.gameObject.tag == "Enemy"&& isSoulDash)
        {
            // タイムのカウントを5秒遅らせる
            isTimerStop = true;
            Destroy(other.gameObject);
            GenerateEffect();
        }
        if (other.gameObject.tag == "Enemy" && !isSoulDash)
        {
            // タイムのカウントを5秒遅らせる
            isDamage = true;
            isDamageEfect = true;
        }
    }
    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
        bool issound = OptionCtrl.isSound;
        // SE再生
        if (issound) audioSource.PlayOneShot(sound1);

    }
    public void SoulDash()
    {
        if (!isSoulDash) isSoulDash = true;
        else isSoulDash = false;
    }
    public void WorldSwitch()
    {
        if (!isWorldSwitch) isWorldSwitch = true;
        else isWorldSwitch = false;

    }
    private void Damage()
    {
        if (isDamageEfect && PlayerStatusCtr.playerStatus==1)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 20));
            gameObject.GetComponent<SpriteRenderer>().color =
                new Color(1f, 1f, 1f, level);
            isDamageCnt++;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color =
               new Color(1f, 1f, 1f, 1f);
        }
        if (isDamageCnt >= 60)
        {
            isDamageEfect = false;
            isDamageCnt = 0;
        }
    }
}
