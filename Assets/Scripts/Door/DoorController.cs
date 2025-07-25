using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject m_playerObject;
    PlayerController m_playerScript;
    [SerializeField] GameObject m_doorInteractionZoneCheckObject;
    DoorInteractionZoneCheck m_doorInteractionZoneCheckScript;
    //[SerializeField] GameObject m_clearTextObject;
    //ClearText m_clearTextScript;

    public GameObject m_targetObject;

    public bool m_isClear = false;
    /// <summary>
    /// スタート処理
    /// </summary>
    void Start()
    {
        m_playerScript = m_playerObject.GetComponent<PlayerController>();
        m_doorInteractionZoneCheckScript = m_doorInteractionZoneCheckObject.GetComponent<DoorInteractionZoneCheck>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        //ドアの前にplayerがいるとき
        if (m_doorInteractionZoneCheckScript.GetIsDoor())
        {
            //wキーを押したら
            if (Input.GetKeyDown("w"))
            {
                //アクティブ状態かの状態の確認
                bool openDoorActive = m_targetObject.activeSelf; //openTheDoorオブジェクト
                bool closeDoorActive = gameObject.activeSelf; //closeDoorオブジェクト
                bool playerActive = m_playerObject.activeSelf; //playerオブジェクト
                //bool clearTextActive = m_clearTextObject.activeSelf; //クリアオブジェクト

                if (!openDoorActive) //openTheDoorオブジェクトが稼働していないなら
                {
                    gameObject.SetActive(false); //closeTheDoorを停止
                    m_targetObject.SetActive(true); //openTheDoorを稼働させる
                    m_isClear =true;
                }
                else
                {
                    return;
                }
            }

            if(m_isClear && Input.GetKeyDown("w"))
            {
                m_playerObject.SetActive(false);　//playerを停止
                //m_clearTextObject.SetActive(true); //clearTextを稼働
                //ここでシーン状態変更
            }
        }
    }
}
