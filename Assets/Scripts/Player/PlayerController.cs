using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody2D; // Rigidbody2Dを定義

    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;

    public const float m_moveSpeed = 5.0f; //プレイヤーの移動速度

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード入力の取得
        float horizontal = Input.GetAxis("Horizontal");
        float vetrical = Input.GetAxis("Vertical");

        //キャラクターの移動
        Vector3 movement = new Vector3(horizontal, vetrical, 0f);
        transform.position += movement * m_moveSpeed * Time.deltaTime;

        //キャラクターのジャンプ
        if (Input.GetKeyDown("space")) //ジャンプキーを押した
        {
            if (m_groundCheckScript.GetIsGround())//playerが地面にいる場合
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        //ジャンプの処理
        rbody2D.AddForce(Vector2.up * 600);
    }
}
