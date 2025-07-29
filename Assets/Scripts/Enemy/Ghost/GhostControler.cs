using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum GhostState
{
    Hide, // ��~
    Move, // �ǐ�
}

public class GhostControler : MonoBehaviour
{
    [SerializeField] GameObject m_doorObject;
    DoorController m_doorControllerScript;

    Rigidbody2D rBody2D;

    public SpriteRenderer m_ghostSprite;
    public Sprite m_hideRender;
    public Sprite m_moveRender;

    private GhostState m_state = GhostState.Move;
    private GameObject m_rightMostPlayerObject = null;
    private GameObject m_leftMostPlayerObject = null;
    private GameObject m_minDistanceToPlayerObject = null;
    [SerializeField]private bool m_canNotMove;
    [SerializeField] private float m_moveSpeed = 1.0f;
    private bool m_canMove = false;
    private float m_rightMostPlayerDistance = float.MinValue;
    private float m_leftMostPlayerDistance = float.MaxValue;
    private float m_minDistanceToPlayer = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        m_doorControllerScript = m_doorObject.GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostTargetPlayers(); //�S�[�X�g�̃^�[�Q�b�g�̐ݒ�
        m_canNotMove = IsPlayerLookingAtGhost(); //�v���C���[���S�[�X�g�����Ă��邩�m�F
        SetGhostState(); // �X�e�[�g�Ɖ摜�̕ύX
    }

    /// <summary>
    /// �������Z�̍X�V����
    /// </summary>
    void FixedUpdate()
    {
        if (m_canMove)
        {
            switch (m_state)
            {
                case GhostState.Hide:
                    rBody2D.velocity = Vector3.zero;
                    break;
                case GhostState.Move:
                    Move();
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Ghost���E���ƍ����A�ł��߂��v���C���[��T���A����ۑ�����֐�
    /// </summary>
    void UpdateGhostTargetPlayers()
    {
        m_doorControllerScript.FindPlayer();
        //�ڑ����Ă���R���g���[���[�̐��J��Ԃ�
        // �S�v���C���[�ɑ΂���
        foreach (GameObject playerGameObject in m_doorControllerScript.m_playerGameObjects)
        {
            // �v���C���[�̈ʒu
            Vector2 playerPos = playerGameObject.transform.position;
            //�S�[�X�g�̈ʒu
            Vector2 ghostPos = this.transform.position;

            // �S�[�X�g����v���C���[�ւ̕����x�N�g��
            float directionToPlayer = playerPos.x - ghostPos.x;
            float distance = Vector2.Distance(playerPos, ghostPos);

            //�S�[�X�g���E���ɂ��邩��ԉ����ꍇ
            if (directionToPlayer >= 0 && m_rightMostPlayerDistance < directionToPlayer)
            {
                m_rightMostPlayerDistance = directionToPlayer;
                m_rightMostPlayerObject = playerGameObject;
            }

            //�S�[�X�g��荶���ɂ��邩��ԉ����ꍇ
            if (directionToPlayer <= 0 && m_leftMostPlayerDistance > directionToPlayer)
            {
                m_leftMostPlayerDistance = directionToPlayer;
                m_leftMostPlayerObject = playerGameObject;
            }

            //�S�[�X�g�����ԋ߂������̏ꍇ
            if (m_minDistanceToPlayer > distance)
            {
                m_minDistanceToPlayer = distance;
                m_minDistanceToPlayerObject = playerGameObject;
                m_canMove = true;
            }
            //Debug.Log(distance);
        }
    }

    /// <summary>
    /// �S�[�X�g�̉摜�Ə�Ԃ̕ύX
    /// </summary>
    void SetGhostState()
    {
        //�S�[�X�g�������Ȃ���Ԃ̏ꍇ
        if (m_canNotMove)
        {
            m_ghostSprite.sprite = m_hideRender;
            m_state = GhostState.Hide;
        }
        //�S�[�X�g��������ꍇ
        else if (!m_canNotMove)
        {
            m_ghostSprite.sprite = m_moveRender;
            m_state = GhostState.Move;
        }
    }

    /// <summary>
    /// �S�[�X�g�̒ǐՏ����B
    /// </summary>
    void Move()
    {
        // �S�[�X�g�ƃv���C���[�̈ʒu
        Vector2 ghostPos = transform.position;
        Vector2 playerPos = m_minDistanceToPlayerObject.transform.position;

        // �S�[�X�g �� �v���C���[�����̒P�ʃx�N�g��
        Vector2 direction = (playerPos - ghostPos).normalized;

        // �ړ�������
        rBody2D.velocity = direction * m_moveSpeed;
    }
    /// <summary>
    /// �v���C���[���S�[�X�g�̕������Ă��邩�ǂ���
    /// </summary>
    /// <returns></returns>
    bool IsPlayerLookingAtGhost()
    {
        //�S�[�X�g�̈ʒu
        Vector2 ghostPos = this.transform.position;

        foreach (GameObject playerObject in m_doorControllerScript.m_playerGameObjects)
        {
            // �v���C���[�̈ʒu
            Vector2 playerPos = playerObject.transform.position;
            //�v���C���[�������Ă������
            Vector3 direction = playerObject.transform.localScale;
            // �S�[�X�g����v���C���[�ւ̕����x�N�g��
            float directionToPlayer = ghostPos.x - playerPos.x;

            //�v���C���[�����������Ă��邩��
            //�v���C���[�̈ʒu���S�[�X�g���E���������ꍇ
            if (direction.x < 0.0f && directionToPlayer < 0.0f)
            {
                return true;
            }

            //�v���C���[���E�������Ă��邩��
            //�v���C���[�̈ʒu���S�[�X�g��荶���������ꍇ
            else if (direction.x > 0.0f && directionToPlayer > 0.0f)
            {
                return true;
            }
            //Debug.Log(direction.x);
            //Debug.Log(directionToPlayer);
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
