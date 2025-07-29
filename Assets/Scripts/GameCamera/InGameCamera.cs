using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameCamera : MonoBehaviour
{

    List<GameObject> m_playerGameObjects = new List<GameObject>();
    List<PlayerController> m_playerControllers = new List<PlayerController>();

    private PlayerController m_playerController; // �v���C���[�R���g���[���[�̎Q��

    private Vector3 m_initPos;

    public float cameraMinX = 0f;      // �J�����ړ��̍ŏ�X�i���[�j
    public float cameraMaxX = 100f;    // �J�����ړ��̍ő�X�i�E�[�j
    public float cameraMinY = 0f;      // �J�����ړ��̍ŏ�Y�i���[�j
    public float cameraMaxY = 100f;    // �J�����ړ��̍ő�Y�i��[�j
    public float smoothTime = 0.2f;    // �J�����ړ��̂Ȃ߂炩��

    //�v���C���[��X���W���擾���邽�߂̕ϐ�
    private Vector3 m_playerPos ;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        


       
    }

    // Update is called once per frame
    void Update()
    {
        //���X�g���̃Q�[���I�u�W�F�N�g�̒��ɂ���Player�����ׂČ�����
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // ������Player�̒��ɂ���PlayerController�����X�g�̒��ɓ����
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }

        // �v���C���[�̈ʒu���擾
        if (m_playerControllers.Count > 0)
        {
            m_playerController = m_playerControllers[0]; // �ŏ��̃v���C���[���擾
            m_playerPos = m_playerController.transform.position;
        }
        else
        {
            return; // �v���C���[�����Ȃ��ꍇ�͉������Ȃ�
        }

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (m_playerControllers.Count == 0 || m_playerControllers[0] == null) return;

        // �v���C���[�̈ʒu���擾
        float x = m_playerControllers[0].transform.position.x;
        float y = m_playerControllers[0].transform.position.y;

        // �͈͐���
        x = Mathf.Clamp(x, cameraMinX, cameraMaxX);
        y = Mathf.Clamp(y, cameraMinY, cameraMaxY);

        // ���݂�Z���ێ������܂ܒǏ]�ʒu��ݒ�
        Vector3 targetPosition = new Vector3(x, y, transform.position.z);

        // �X���[�Y�ɒǏ]
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);




    }

   
}
