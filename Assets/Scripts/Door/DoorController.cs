using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorController : MonoBehaviour
{
    List<GameObject> m_playerGameObjects = new List<GameObject>();
    List<PlayerController> m_playerControllers = new List<PlayerController>();

    [SerializeField] GameObject m_doorInteractionZoneCheckObject;
    DoorInteractionZoneCheck m_doorInteractionZoneCheckScript;
    [SerializeField] GameObject m_playerControllerObject;
    PlayerController m_playerControllerScript;
    [SerializeField] GameObject m_playerManagerObject;
    PlayerController m_playerManagerScript;
    [SerializeField] GameObject m_clearTextObject;
    ClearText m_clearTextScript;

    public GameObject m_targetObject; // OpenDoorのアクティブの切り替え
    public GameObject m_canvasPlay; // Canvasののアクティブの切り替え

    public bool m_isClear = false;
    public bool m_onTitle = true;
    public int m_clearedPlayerCount = 0;

    private DEMOPARK_2025 m_inputActions;
    private bool m_openDoorActive;
    private bool m_closeDoorActive;

    private float m_timer = 0.0f; // タイマー

    /// <summary>
    /// スタート処理
    /// </summary>
    void Start()
    {
        //SceneがTitleでない場合、m_titleをfalseにする
        if (SceneManager.GetActiveScene().name != "TitleScane")
        {
            m_onTitle = false;

        }
        //インプットアクションを使用可能にする
        m_inputActions = new DEMOPARK_2025();
        m_inputActions.Enable();

        m_playerControllerScript = m_playerControllerObject.GetComponent<PlayerController>();
        m_doorInteractionZoneCheckScript = m_doorInteractionZoneCheckObject.GetComponent<DoorInteractionZoneCheck>();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        //プレイヤー数を増やしたとき
        if (m_inputActions.Player.PlayerSpawner.triggered)
        {
            FindPlayer();
        }

        //登録されているプレイヤーを一人ずつ確認する
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            //ドアの前にplayerがいるとき
            if (m_doorInteractionZoneCheckScript.GetIsDoor()||m_isClear)
            { 
                //ドアが閉まっているとき
                if (IsCloseDoorActive())
                {
                    //InDoorを押したら
                    if (m_inputActions.Player.InDoor.triggered)
                    {
                        gameObject.SetActive(false); //closeTheDoorを停止
                        m_targetObject.SetActive(true); //openTheDoorを稼働させる
                        m_isClear = true;
                    }
                }

                // ドアが開いているとき
                if (IsOpenDoorActive())
                {
                   
                    // クリアフラグが立っている場合
                    if (m_isClear)
                    {
                        //InDoorを押したら
                        if (m_inputActions.Player.InDoor.triggered)
                        {
                            playerGameObject.SetActive(false);

                            if (!m_onTitle) // todo test
                            {
                                //ゲームに接続したプレイヤーが全員扉に入ったらゲームクリア
                                CheckClear();

                                while (true)
                                {
                                    // タイマーを更新
                                    m_timer += Time.deltaTime;
                                    // ロード時間を超えたらシーンをロード
                                    if (m_timer >= 10.0f)
                                    {
                                        // シーンをロード
                                        SceneManager.LoadScene("SelectScene");
                                        break; // ループを抜ける
                                    }
                                }
                            }
                            else if (m_onTitle) // タイトル画面にいる場合
                            {
                                SceneManager.LoadScene("SelectScene");
                            }
                            //m_clearedPlayerCount++;
                        }

                        ////OutDoorを押したら
                        //if (m_inputActions.Player.OutDoor.triggered)
                        //{
                        //    playerGameObject.SetActive(true);
                        //    m_clearedPlayerCount--;
                        //}
                    }
                }
            }
        }
    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void CheckClear()
    {
        m_canvasPlay.SetActive(true); //clearTextを稼働
                                      //ここでシーン状態変更
        
    }
    /// <summary>
    /// 接続しているプレイヤーをすべて見つける
    /// </summary>
    public void FindPlayer()
    {
        //リスト内のゲームオブジェクトの中にあるPlayerをすべて見つける
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // 見つけたPlayerの中にあるPlayerControllerをリストの中に入れる
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }
    }
    /// <summary>
    /// 空いているドアがアクティブ状態かの状態の確認
    /// </summary>
    bool IsOpenDoorActive()
    {
        m_openDoorActive = m_targetObject.activeSelf; //openTheDoorオブジェクト
        return m_openDoorActive;
    }

    bool IsCloseDoorActive()
    {
        m_closeDoorActive = gameObject.activeSelf; //closeDoorオブジェクト
        return m_closeDoorActive;
    }
}
