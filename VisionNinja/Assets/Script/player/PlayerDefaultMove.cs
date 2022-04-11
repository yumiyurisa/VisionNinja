using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDefaultMove : MonoBehaviour
{
    private Rigidbody2D rd2d; // Rigidbody2DComponent（物理演算）
    private Animator anim; // AnimatorComponent（アニメーション）
    [SerializeField]
    private float jumpForce = 5.0f; // ジャンプ量
    private bool isGround; // 地面に着地判定 true：着地、false：空中
    public LayerMask groundLeyer; // 着地判定参照
    static public float speed; // 移動量

    // Start is called before the first frame update
    void Start()
    {
        this.rd2d = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 地面とキャラとの距離を計算
        Vector2 groudpos =
            new Vector2(
                this.transform.position.x,
                this.transform.position.y
                );
        Vector2 groudArea = new Vector2(0.5f, 0.5f);
//        Debug.DrawLine(groudpos + groudArea, groudpos - groudArea, Color.red);

        // キャラの中心の角とその対角にある角の座標を決め、四角領域に地面があるか判定
        isGround =
            Physics2D.OverlapArea(
                groudpos + groudArea,
                groudpos - groudArea,
                groundLeyer
                );
        if (!isGround) {
            anim.SetBool("isJump", true);
            rd2d.gravityScale = 3;
        } 
        else {
            rd2d.gravityScale = 1;
            anim.SetBool("isJump", false);
        }

        float velx = rd2d.velocity.x;
        float vely = rd2d.velocity.y;
        if (vely > 5.0f) 
        // 斜め移動量制御
        if (Mathf.Abs(velx) > 5)
        {
            if (velx > 5.0f) rd2d.velocity = new Vector2(5.0f, vely);
            if (velx < -5.0f) rd2d.velocity = new Vector2(-5.0f, vely);
        }

        // 通常横移動
        rd2d.AddForce(Vector2.right * speed);

        // ボタンが押されてるなら以下処理しない
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
#else 
    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
        return;
    }
#endif        
        if (PlayerStatusCtr.playerStatus == 1)
        {
            // キャラジャンプ 地面に着地しているかの確認
            if (Input.GetMouseButtonDown(0) && isGround)
            {
                rd2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }
}
