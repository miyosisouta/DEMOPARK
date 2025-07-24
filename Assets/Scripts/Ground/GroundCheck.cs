using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // 接地しているかを格納する変数
    bool m_isGround = false;

    /// <summary>
    /// スタート
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        
    }
    /// <summary>
    /// 地面に触れているかを返す関数
    /// </summary>
    public bool GetIsGround()
    {
        return m_isGround;
    }

    /// <summary>
    /// 毎フレーム最初に接地判定をリセットする
    /// </summary>
    private void FixedUpdate()
    {
        m_isGround = false;
    }

    /// <summary>
    /// 地面のタグが付いたオブジェクトに衝突しているか判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }
}
