using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 子オブジェクトのフィールド
    /// </summary>
    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;
    
    /// <summary>
    /// 自身のフィールド
    /// </summary>
    Rigidbody2D rbody2D; // Rigidbody2Dを定義
 
    public const float m_moveSpeed = 5.0f; //プレイヤーの移動速度

    private Animator m_anim;
    private bool m_jump = false;

    private float directionX;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード入力の取得
        float horizontal = Input.GetAxis("Horizontal");
        float vetrical = 0.0f;//Input.GetAxis("Vertical");

        //キャラクターの移動
        Vector3 movement = new Vector2(horizontal, vetrical);
        transform.position += movement * m_moveSpeed * Time.deltaTime;

        if(horizontal != 0.0f)
        {
            directionX = horizontal;
        }

        if (directionX >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

            //アニメーションの切り替え
            //第1引数：アニメーションの変数
            //第2引数：true or false
            m_anim.SetBool("Run", horizontal != 0.0f && !m_jump);
 
        //playerが地面にいる場合
        if (m_groundCheckScript.GetIsGround())
        {
            m_jump = false;
            //ジャンプの再生を止める
            m_anim.SetBool("Jump", m_jump);

            //ジャンプキーを押したら
            if (Input.GetKeyDown("space"))
            {
                Jump();
                //アニメーションの切り替え
                m_anim.SetBool("Jump", m_jump);
            }
        }
    }

    void Jump()
    {
        //ジャンプの処理
        rbody2D.AddForce(Vector2.up * 600);
        m_jump = true;
    }
}
