using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject m_playerObject;
    PlayerController m_playerScript;
    [SerializeField] GameObject m_doorInteractionZoneCheckObject;
    DoorInteractionZoneCheck m_doorInteractionZoneCheckScript;
    [SerializeField] GameObject m_clearTextObject;
    ClearText m_clearTextScript;

    public GameObject m_targetObject; // OpenDoorのアクティブの切り替え
    public GameObject m_playerStop; //  playerのアクティブの切り替え
    public GameObject m_canvasPlay; // Canvasののアクティブの切り替え

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
                m_playerStop.SetActive(false);　//playerを停止
                m_canvasPlay.SetActive(true); //clearTextを稼働
                //ここでシーン状態変更
            }
        }
    }
}
