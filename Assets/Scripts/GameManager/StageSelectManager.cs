using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    private int m_StageStatus = 0; // ステージの状態を管理する変数

    private int m_StageCount = 1;

    [SerializeField] GameObject m_stage1Player; // ステージ選択用のplayerのスプライト
    [SerializeField] GameObject m_stage2Player; // ステージ選択用のplayerのスプライト
    [SerializeField] GameObject m_stage3Player; // ステージ選択用のplayerのスプライト

    private DEMOPARK_2025 m_inputActions;
    
   

    // Start is called before the first frame update
    void Start()
    {
        //m_playerのPositionをm_stage1Posに設定
        //インプットアクションを使用可能にする
        m_inputActions = new DEMOPARK_2025();
        m_inputActions.Enable();


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove(); 
        StageSelect();
    }

    void PlayerMove ()
    {
        
        //コントローラーの十字ボタンの右を押したとき
        if (m_inputActions.StageSelect.ThreeStage.triggered)
        {
            
            m_StageCount += 1;

            if (m_StageCount == 1)
            {
                m_stage1Player.SetActive(true);
                m_stage2Player.SetActive(false);
                m_stage3Player.SetActive(false);
            }
            else if (m_StageCount == 2)
            {
                m_stage1Player.SetActive(false);
                m_stage2Player.SetActive(true);
                m_stage3Player.SetActive(false);
            }
            else if (m_StageCount == 3)
            {
                m_stage1Player.SetActive(false);
                m_stage2Player.SetActive(false);
                m_stage3Player.SetActive(true);
            }

            if (m_StageCount > 3)
            {
                m_StageCount = 1; // ステージ数を1に戻す
            }
        }

        //コントローラーの十字ボタンの左を押したとき
        if (m_inputActions.StageSelect.OneStage.triggered)
        {

            m_StageCount -= 1;

            if (m_StageCount == 1)
            {
                m_stage1Player.SetActive(true);
                m_stage2Player.SetActive(false);
                m_stage3Player.SetActive(false);
            }
            else if (m_StageCount == 2)
            {
                m_stage1Player.SetActive(false);
                m_stage2Player.SetActive(true);
                m_stage3Player.SetActive(false);
            }
            else if (m_StageCount == 3)
            {
                m_stage1Player.SetActive(false);
                m_stage2Player.SetActive(false);
                m_stage3Player.SetActive(true);
            }

            if (m_StageCount < 0)
            {
                m_StageCount = 3; // ステージ数を1に戻す
            }
        }
    }

    void StageSelect()
    {
        if (m_inputActions.StageSelect.AButton.triggered)
        {
            if(m_StageCount == 1)
            {
                // ステージ1-1を選択
                SceneManager.LoadScene("1-1LoadScene");
            }
            else if (m_StageCount == 2)
            {
                // ステージ1-2を選択
                SceneManager.LoadScene("1-2LoadScene");
            }
            else if (m_StageCount == 3)
            {
                // ステージ1-3を選択
                SceneManager.LoadScene("1-3LoadScene");
            }
        }
    }
}
