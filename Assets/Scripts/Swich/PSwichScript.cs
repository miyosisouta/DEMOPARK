using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSwichScript : MonoBehaviour
{
    [SerializeField] GameObject PGround;

    [SerializeField] private Renderer m_rendererSwitch; // PGroundのRendererを参照

    public bool m_isPush = false; // スイッチが押されたかどうかのフラグ
    public bool m_isCalledOnece = false; // PGroundを一度だけ生成するためのフラグ

    public float m_showTime = 5.0f; // 床の表示時間

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクトの名前が"Player"の場合
        if (collision.gameObject.name == "Player")
        {
            //非表示のPGroundを表示にする
            PGround.SetActive(true);

            // スイッチが押されたフラグを立てる
            m_isPush = true;

            //現在のオブジェクトを非表示にする
            //gameObject.SetActive(false);
            m_rendererSwitch.enabled = false; // スイッチのRendererを非表示にする
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // クローンを非表示にする
        PGround.SetActive(false);
    }

    void Update()
    {

        // PSwichScriptのm_isPushがtrueの場合、PGroundを生成
        if (m_isPush == true && m_isCalledOnece == false)
        {
            m_isCalledOnece = true; // 一度だけ生成するためのフラグを立てる

            // PGroundを生成する位置を計算
            Vector3 spawnPosition = new Vector2(42.5f, -3.1f); // 例として固定位置を使用

            // PGroundを生成
            //GameObject clonePGround = Instantiate(PGround);
            PGround.SetActive(true); // クローンを表示にする

            Debug.Log("seisei kiteru");
        }

        SetTime();
    }

    public void SetTime()
    {
        // スイッチが押された場合、PGroundの表示時間を管理
        if (m_isPush && PGround != null)
        {
            // PGroundの表示時間をカウントダウン
            m_showTime -= Time.deltaTime;
            // 表示時間が0以下になったらPGroundを削除
            if (m_showTime <= 0f)
            {
                //GameObject clonePGround = Instantiate(PGround);
                PGround.SetActive(false); // クローンを非表示にする

                // スイッチのフラグをリセット
                m_isPush = false;

                // スイッチのRendererを表示にする
                m_rendererSwitch.enabled = true;

                // 一度だけ生成するためのフラグを立てる
                m_isCalledOnece = false;

                // 表示時間をリセット
                m_showTime = 6.0f; // 必要に応じて初期値を設定

                //かくにん log
                Debug.Log("osareta kiteru");
            }
        }
    }
}
