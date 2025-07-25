using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    List<GameObject> m_playerGameObjects = new List<GameObject>();
    List<PlayerController> m_playerControllers = new List<PlayerController>();

    [SerializeField] GameObject m_doorInteractionZoneCheckObject;
    DoorInteractionZoneCheck m_doorInteractionZoneCheckScript;
    [SerializeField] GameObject m_clearTextObject;
    ClearText m_clearTextScript;

    public GameObject m_targetObject; // OpenDoorのアクティブの切り替え
    public GameObject m_canvasPlay; // Canvasののアクティブの切り替え

    public bool m_isClear = false;

    /// <summary>
    /// スタート処理
    /// </summary>
    void Start()
    {
        //リスト内のゲームオブジェクトの中にあるPlayerをすべて見つける
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // 見つけたPlayerの中にあるPlayerControllerをリストの中に入れる
        foreach(GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }

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
                foreach(GameObject playerGameObject in m_playerGameObjects)
                {
                    playerGameObject.SetActive(false);
                }
                m_canvasPlay.SetActive(true); //clearTextを稼働
                //ここでシーン状態変更
            }
        }
    }
}
