using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject m_targetObject; // OpenDoor�̃A�N�e�B�u�̐؂�ւ�
    public GameObject m_canvasPlay; // Canvas�̂̃A�N�e�B�u�̐؂�ւ�

    public bool m_isClear = false;
    public bool m_onTitle = true;
    public int m_clearedPlayerCount = 0;

    private DEMOPARK_2025 m_inputActions;
    private bool m_openDoorActive;
    private bool m_closeDoorActive;

    /// <summary>
    /// �X�^�[�g����
    /// </summary>
    void Start()
    {
        //�C���v�b�g�A�N�V�������g�p�\�ɂ���
        m_inputActions = new DEMOPARK_2025();
        m_inputActions.Enable();

        m_playerControllerScript = m_playerControllerObject.GetComponent<PlayerController>();
        m_doorInteractionZoneCheckScript = m_doorInteractionZoneCheckObject.GetComponent<DoorInteractionZoneCheck>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {
        //�v���C���[���𑝂₵���Ƃ�
        if (m_inputActions.Player.PlayerSpawner.triggered)
        {
            FindPlayer();
        }

        //�o�^����Ă���v���C���[����l���m�F����
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            //�h�A�̑O��player������Ƃ�
            if (m_doorInteractionZoneCheckScript.GetIsDoor()||m_isClear)
            { 
                //�h�A���܂��Ă���Ƃ�
                if (IsCloseDoorActive())
                {
                    //InDoor����������
                    if (m_inputActions.Player.InDoor.triggered)
                    {
                        gameObject.SetActive(false); //closeTheDoor���~
                        m_targetObject.SetActive(true); //openTheDoor���ғ�������
                    }
                }

                // �h�A���J���Ă���Ƃ�
                if (IsOpenDoorActive())
                {
                    m_isClear = true;
                    // �N���A�t���O�������Ă���ꍇ
                    if (m_isClear)
                    {
                        //InDoor����������
                        if (m_inputActions.Player.InDoor.triggered)
                        {
                            playerGameObject.SetActive(false);
                            if (!m_onTitle) // todo test
                            {
                                //�Q�[���ɐڑ������v���C���[���S�����ɓ�������Q�[���N���A
                                CheckClear();
                            }
                            //m_clearedPlayerCount++;
                        }

                        ////OutDoor����������
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
    /// �Q�[���N���A
    /// </summary>
    public void CheckClear()
    {
        m_canvasPlay.SetActive(true); //clearText���ғ�
                                      //�����ŃV�[����ԕύX
    }
    /// <summary>
    /// �ڑ����Ă���v���C���[�����ׂČ�����
    /// </summary>
    public void FindPlayer()
    {
        //���X�g���̃Q�[���I�u�W�F�N�g�̒��ɂ���Player�����ׂČ�����
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // ������Player�̒��ɂ���PlayerController�����X�g�̒��ɓ����
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }
    }
    /// <summary>
    /// �󂢂Ă���h�A���A�N�e�B�u��Ԃ��̏�Ԃ̊m�F
    /// </summary>
    bool IsOpenDoorActive()
    {
        m_openDoorActive = m_targetObject.activeSelf; //openTheDoor�I�u�W�F�N�g
        return m_openDoorActive;
    }

    bool IsCloseDoorActive()
    {
        m_closeDoorActive = gameObject.activeSelf; //closeDoor�I�u�W�F�N�g
        return m_closeDoorActive;
    }
}
