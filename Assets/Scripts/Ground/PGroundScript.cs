using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PGroundScript : MonoBehaviour
{ 
//
//    GameObject PGround; // PGroundの変数

//    //床の表示時間
//    public float m_showTime = 5.0f; // 床の表示時間

//    [SerializeField] GameObject PSwich;
//    PSwichScript m_swichScript; // PSwichScriptの参照

//    // Start is called before the first frame update
//    void Start()
//    {
//        //最初はPGroundを非表示にする
//        PGround.SetActive(false);

//        // PSwichScriptのコンポーネントを取得
//      //  m_swichScript = PSwich.GetComponent<PSwichScript>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // PSwichScriptのm_isPushがtrueの場合、PGroundを生成
//        if (m_swichScript.m_isPush == true)
//        {
//            // PGroundを生成する位置を計算
//            Vector3 spawnPosition = new Vector2(42.5f, -3.1f); // 例として固定位置を使用

//            // PGroundを生成
//            Instantiate(PGround, spawnPosition, Quaternion.identity);
//        }

//        SetTime();
//    }

//    public void SetTime()
//    {
//        // スイッチが押された場合、PGroundの表示時間を管理
//        if (m_swichScript.m_isPush && PGround != null)
//        {
//            // PGroundの表示時間をカウントダウン
//            m_showTime -= Time.deltaTime;
//            // 表示時間が0以下になったらPGroundを削除
//            if (m_showTime <= 0f)
//            {
//                PGround.SetActive(false);
//                m_swichScript.m_isPush = false; // スイッチのフラグをリセット
//            }
//        }
//    }
}
    

