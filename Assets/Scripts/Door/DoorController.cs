using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject m_playerObject;
    PlayerController m_playerScript;
    [SerializeField] GameObject m_doorInteractionZoneCheckObject;
    DoorInteractionZoneCheck m_doorInteractionZoneCheckScript;
    //[SerializeField] GameObject m_clearTextObject;
    //ClearText m_clearTextScript;

    public GameObject m_targetObject;

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
                bool closeDoorActive = gameObject.activeSelf; //closeDoor�I�u�W�F�N�g
                bool playerActive = m_playerObject.activeSelf; //player�I�u�W�F�N�g
                //bool clearTextActive = m_clearTextObject.activeSelf; //�N���A�I�u�W�F�N�g

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
                m_playerObject.SetActive(false);�@//player���~
                //m_clearTextObject.SetActive(true); //clearText���ғ�
                //�����ŃV�[����ԕύX
            }
        }
    }
}
