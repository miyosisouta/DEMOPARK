using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�X�e�[�^�X�p�񋓌^�̒�`
enum GameStatus
{
    INIT,        //�����iPrees A Button�j
    HEADCOUNT,   //�l���I��
    INDOOR�@�@�@ //�v���C���[����
}

public class TitleManager : MonoBehaviour
{
    //�Q�[���̃X�e�[�^�X
    GameStatus m_GameStatus = GameStatus.INIT;

    //�v���C���[
    [SerializeField] GameObject m_player; //�v���C���[
    //[SerializeField] Transform[] m_transforms; //�v���C���[�̐����ʒu
    //private List<PlayerController> m_players = new List<PlayerController>(); //�v���C���[�̃��X�g
    //private int m_playerCount = 1; //�v���C���[�̐l��

    ////UI�e�L�X�g
    //[SerializeField] Text m_pressAText; //"PRESS A BUTTON" �\���p�e�L�X�g
    //[SerializeField] Text m_playerCountText; //�l���I��p�e�L�X�g
    //[SerializeField] Text m_doorStatusText; //�h�A�̏�ԕ\���p�e�L�X�g

    //private int m_doorEnterCount = 0; //�h�A�ɓ������l���J�E���g

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
        //        // A�L�[����������l���I����
        //        if (Input.GetKeyDown("J"))
        //        {
        //            m_pressAText.gameObject.SetActive(false); // "PRESS A BUTTON"���\��
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

    //�X�e�[�^�X�Ǘ��p�֐�
    void ChangeGameStatus(GameStatus status)
    {
        //m_GameStatus = status;
        //switch (m_GameStatus)
        //{
        //    case GameStatus.INIT:
        //        //Init();
        //        break;
        //    case GameStatus.HEADCOUNT:
        //        // �l���I������
        //        HeadCount();
        //        break;
        //    case GameStatus.INDOOR:
        //        // �v���C���[���쏈��
        //        Indoor();
        //        break;
        //}
    }

    void Init()
    {
        //�v���C���[�폜
        //foreach (var player in m_players)
        //{
        //    Destroy(player.gameObject);
        //}
        //m_players.Clear(); // �v���C���[���X�g���N���A
        //m_playerCount = 1; // �v���C���[�l�������Z�b�g
        //m_doorEnterCount = 0;

        //m_pressAText.gameObject.SetActive(true); // "PRESS A BUTTON"��\��
        //m_playerCountText.gameObject.SetActive(false); // �l���I��p�e�L�X�g���\�� 
        //m_doorStatusText.text = ""; // �h�A�̏�ԕ\�����N���A

    }

    // �l���I������
    void HeadCount()
    {
        //m_playerCountText.gameObject.SetActive(true); // �l���I��p�e�L�X�g��\��
        
    }

    //�l���I�����̓��͏���
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

    // �v���C���[���쏈��
    void Indoor()
    {
        // �����Ƀv���C���[����̃��W�b�N������
        // �Ⴆ�΁A�Q�[���̃��C�����[�v�Ȃ�
    }

}
