using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;
    [SerializeField] GameObject m_playerManagerObject;

    Rigidbody2D rbody2D; // Rigidbody2Dを定義
    private Animator m_anim; //アニメーター

    public int m_playerIndex = 0; //プレイヤー接続数

    // SerializeFieldをつけることでUnity上で値を変えることが可能
    [SerializeField]private Vector2 m_move = Vector2.zero; //プレイヤーの移動速度
    [SerializeField]private const float m_setGravity = -9.0f; // 重力
    private bool m_jumpAnimation = false; //ジャンプアニメーションが再生されているか
    private bool m_isJumping = true; //ジャンプできるかどうか
    private float m_jumpPower; //ジャンプの強さ
    private float directionX; //プレイヤーの向き
    private float m_horizontal; //X軸の移動量
    private float m_vetrical; //Y軸の移動量

    // プレイヤーが右に移動しているかどうかのフラグ
    public bool m_isMovingRight = false;
    // プレイヤーが左に移動しているかどうかのフラグ   
    public bool m_isMovingLeft = false;

    public const int m_playerIndexMax = 3; //最大プレイヤー接続数
    public int m_playerIndexCount = 1;
    /// <summary>
    /// スタート処理
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rbody2D = GetComponent<Rigidbody2D>();

        //地面についているかを判定するスクリプト
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();

        //アニメーション
        m_anim = GetComponent<Animator>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //接続したコントローラーに番号を入れる
        m_playerIndex = gameObject.GetComponent<PlayerInput>().playerIndex;

        //コントローラーの番号ログ
        Debug.Log(m_playerIndex);

        //プレイヤーの接続人数を更新
        if (m_playerIndex > m_playerIndexCount)
        {
            m_playerIndexCount = m_playerIndex;
        }
        for (int i = 0; i < 4; i++)
        {
            if (m_playerIndex == i)
            {
                var val = m_move * Time.deltaTime * 10.0f;
                transform.Translate(val.x, 0.0f, 0.0f);
                m_horizontal = val.x;
            }

            //移動している場合、移動量を代入
            if (m_horizontal != 0.0f)
            {
                directionX = m_horizontal;
            }

            //プレイヤーが右に向かうとき
            if (directionX >= 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); // 画像をそのまま表示
                m_isMovingRight = true;
                m_isMovingLeft = false;
            }

            //プレイヤーが左に向かうとき
            else
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); // 画像を反転
                m_isMovingLeft = true;
                m_isMovingRight = false;
            }

            //アニメーションの切り替え
            //第1引数：アニメーションの変数
            //第2引数：true or false
            m_anim.SetBool("Run", m_horizontal != 0.0f && !m_jumpAnimation);

            //playerが地面にいる場合
            if (m_groundCheckScript.GetIsGround() == true)
            {
                m_jumpAnimation = false;
                m_isJumping = true;
                //ジャンプの再生を止める
                m_anim.SetBool("Jump", m_jumpAnimation);
                //ジャンプ力があるなら
                if (m_jumpPower > 0)
                {
                    float val = Mathf.Sqrt(m_jumpPower * -2.0f * m_setGravity);
                    transform.Translate(0.0f, val * Time.deltaTime, 0.0f);
                    m_isJumping = false;
                }
            }
            //playerが地面にいない場合
            else if (m_groundCheckScript.GetIsGround() == false)
            {
                m_jumpAnimation = true;
                //アニメーションの切り替え
                m_anim.SetBool("Jump", m_jumpAnimation);
            }


        }
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        m_move = context.ReadValue<Vector2>().normalized;
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    /// <param name="context"></param>
    public void OnJump(InputAction.CallbackContext context)
    {
        //m_jumpPower = context.ReadValue<float>();
        if (context.performed && m_isJumping)
        {
            m_jumpPower = 20.0f;
            
        }
        else
        {
            m_jumpPower = 0.0f;
        }
    }
}