using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    private int m_StageStatus = 0; // �X�e�[�W�̏�Ԃ��Ǘ�����ϐ�

    private int m_StageCount = 1;

    [SerializeField] GameObject m_stage1Player; // �X�e�[�W�I��p��player�̃X�v���C�g
    [SerializeField] GameObject m_stage2Player; // �X�e�[�W�I��p��player�̃X�v���C�g
    [SerializeField] GameObject m_stage3Player; // �X�e�[�W�I��p��player�̃X�v���C�g

    private DEMOPARK_2025 m_inputActions;
    
   

    // Start is called before the first frame update
    void Start()
    {
        //m_player��Position��m_stage1Pos�ɐݒ�
        //�C���v�b�g�A�N�V�������g�p�\�ɂ���
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
        
        //�R���g���[���[�̏\���{�^���̉E���������Ƃ�
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
                m_StageCount = 1; // �X�e�[�W����1�ɖ߂�
            }
        }

        //�R���g���[���[�̏\���{�^���̍����������Ƃ�
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
                m_StageCount = 3; // �X�e�[�W����1�ɖ߂�
            }
        }
    }

    void StageSelect()
    {
        if (m_inputActions.StageSelect.AButton.triggered)
        {
            if(m_StageCount == 1)
            {
                // �X�e�[�W1-1��I��
                SceneManager.LoadScene("1-1LoadScene");
            }
            else if (m_StageCount == 2)
            {
                // �X�e�[�W1-2��I��
                SceneManager.LoadScene("1-2LoadScene");
            }
            else if (m_StageCount == 3)
            {
                // �X�e�[�W1-3��I��
                SceneManager.LoadScene("1-3LoadScene");
            }
        }
    }
}
