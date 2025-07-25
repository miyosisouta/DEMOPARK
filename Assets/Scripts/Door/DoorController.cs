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

    public GameObject m_targetObject; // OpenDoor�̃A�N�e�B�u�̐؂�ւ�
    public GameObject m_playerStop; //  player�̃A�N�e�B�u�̐؂�ւ�
    public GameObject m_canvasPlay; // Canvas�̂̃A�N�e�B�u�̐؂�ւ�

    public bool m_isClear = false;

    /// <summary>
    /// �X�^�[�g����
    /// </summary>
    void Start()
    {
        m_playerScript = m_playerObject.GetComponent<PlayerController>();
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
                m_playerStop.SetActive(false);�@//player���~
                m_canvasPlay.SetActive(true); //clearText���ғ�
                //�����ŃV�[����ԕύX
            }
        }
    }
}
