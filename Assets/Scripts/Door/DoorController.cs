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

    public GameObject m_targetObject; // OpenDoor�̃A�N�e�B�u�̐؂�ւ�
    public GameObject m_canvasPlay; // Canvas�̂̃A�N�e�B�u�̐؂�ւ�

    public bool m_isClear = false;

    /// <summary>
    /// �X�^�[�g����
    /// </summary>
    void Start()
    {
        //���X�g���̃Q�[���I�u�W�F�N�g�̒��ɂ���Player�����ׂČ�����
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // ������Player�̒��ɂ���PlayerController�����X�g�̒��ɓ����
        foreach(GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }

        m_doorInteractionZoneCheckScript = m_doorInteractionZoneCheckObject.GetComponent<DoorInteractionZoneCheck>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {
        //�h�A�̑O��player������Ƃ�
        if (m_doorInteractionZoneCheckScript.GetIsDoor())
        {
            //w�L�[����������
            if (Input.GetKeyDown("w"))
            {
                //�A�N�e�B�u��Ԃ��̏�Ԃ̊m�F
                bool openDoorActive = m_targetObject.activeSelf; //openTheDoor�I�u�W�F�N�g

                if (!openDoorActive) //openTheDoor�I�u�W�F�N�g���ғ����Ă��Ȃ��Ȃ�
                {
                    gameObject.SetActive(false); //closeTheDoor���~
                    m_targetObject.SetActive(true); //openTheDoor���ғ�������
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
                m_canvasPlay.SetActive(true); //clearText���ғ�
                //�����ŃV�[����ԕύX
            }
        }
    }
}
