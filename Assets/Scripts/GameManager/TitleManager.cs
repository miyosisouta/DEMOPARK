using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ステータス用列挙型の定義
enum GameStatus
{
    INIT,        //初期（Prees A Button）
    HEADCOUNT,   //人数選択
    INDOOR　　　 //プレイヤー操作
}

public class TitleManager : MonoBehaviour
{
    //ゲームのステータス
    GameStatus m_GameStatus = GameStatus.INIT;

    //プレイヤー
    [SerializeField] GameObject m_player; //プレイヤー
    //[SerializeField] Transform[] m_transforms; //プレイヤーの生成位置
    //private List<PlayerController> m_players = new List<PlayerController>(); //プレイヤーのリスト
    //private int m_playerCount = 1; //プレイヤーの人数

    ////UIテキスト
    //[SerializeField] Text m_pressAText; //"PRESS A BUTTON" 表示用テキスト
    //[SerializeField] Text m_playerCountText; //人数選択用テキスト
    //[SerializeField] Text m_doorStatusText; //ドアの状態表示用テキスト

    //private int m_doorEnterCount = 0; //ドアに入った人数カウント

    // Start is called before the first frame update
    void Start()
    {
        //Init();

    }

    // Update is called once per frame
    void Update()
    {
        //switch (m_GameStatus)
        //{
        //    case GameStatus.INIT:
        //        // Aキーを押したら人数選択へ
        //        if (Input.GetKeyDown("J"))
        //        {
        //            m_pressAText.gameObject.SetActive(false); // "PRESS A BUTTON"を非表示
        //            ChangeGameStatus(GameStatus.HEADCOUNT);
        //        }
        //        break;

        //    case GameStatus.HEADCOUNT:

        //        break;

        //    case GameStatus.INDOOR:

        //        break;
        //}

        //if (m_player == null || !m_player.activeInHierarchy)
        //{
        //    SceneManager.LoadScene("SelectScene");
        //}

    }

    //ステータス管理用関数
    void ChangeGameStatus(GameStatus status)
    {
        //m_GameStatus = status;
        //switch (m_GameStatus)
        //{
        //    case GameStatus.INIT:
        //        //Init();
        //        break;
        //    case GameStatus.HEADCOUNT:
        //        // 人数選択処理
        //        HeadCount();
        //        break;
        //    case GameStatus.INDOOR:
        //        // プレイヤー操作処理
        //        Indoor();
        //        break;
        //}
    }

    void Init()
    {
        //プレイヤー削除
        //foreach (var player in m_players)
        //{
        //    Destroy(player.gameObject);
        //}
        //m_players.Clear(); // プレイヤーリストをクリア
        //m_playerCount = 1; // プレイヤー人数をリセット
        //m_doorEnterCount = 0;

        //m_pressAText.gameObject.SetActive(true); // "PRESS A BUTTON"を表示
        //m_playerCountText.gameObject.SetActive(false); // 人数選択用テキストを非表示 
        //m_doorStatusText.text = ""; // ドアの状態表示をクリア

    }

    // 人数選択処理
    void HeadCount()
    {
        //m_playerCountText.gameObject.SetActive(true); // 人数選択用テキストを表示
        
    }

    //人数選択時の入力処理
    void HandleHeadCountInput()
    {
        
    }

    void UpdatePlayerCountText()
    {
        //m_playerCountText.text = $"{m_playerCount} PLAYERS GAME";
    }

    void SpawnPlayers(int count)
    {

    }

    // プレイヤー操作処理
    void Indoor()
    {
        // ここにプレイヤー操作のロジックを実装
        // 例えば、ゲームのメインループなど
    }

}
