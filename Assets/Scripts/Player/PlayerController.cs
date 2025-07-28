using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;
    [SerializeField] GameObject m_playerManagerObject;

    Rigidbody2D rbody2D; // Rigidbody2D���`
    private Animator m_anim; //�A�j���[�^�[

    public int m_playerIndex = 0; //�v���C���[�ڑ���

    // SerializeField�����邱�Ƃ�Unity��Œl��ς��邱�Ƃ��\
    [SerializeField]private Vector2 m_move = Vector2.zero; //�v���C���[�̈ړ����x
    [SerializeField]private const float m_setGravity = -9.0f; // �d��
    private bool m_jumpAnimation = false; //�W�����v�A�j���[�V�������Đ�����Ă��邩
    private bool m_isJumping = true; //�W�����v�ł��邩�ǂ���
    private float m_jumpPower; //�W�����v�̋���
    private float directionX; //�v���C���[�̌���
    private float m_horizontal; //X���̈ړ���
    private float m_vetrical; //Y���̈ړ���

    // �v���C���[���E�Ɉړ����Ă��邩�ǂ����̃t���O
    public bool m_isMovingRight = false;
    // �v���C���[�����Ɉړ����Ă��邩�ǂ����̃t���O   
    public bool m_isMovingLeft = false;

    public const int m_playerIndexMax = 3; //�ő�v���C���[�ڑ���
    public int m_playerIndexCount = 1;
    /// <summary>
    /// �X�^�[�g����
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D�R���|�[�l���g���擾
        rbody2D = GetComponent<Rigidbody2D>();

        //�n�ʂɂ��Ă��邩�𔻒肷��X�N���v�g
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();

        //�A�j���[�V����
        m_anim = GetComponent<Animator>();
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //�ڑ������R���g���[���[�ɔԍ�������
        m_playerIndex = gameObject.GetComponent<PlayerInput>().playerIndex;

        //�R���g���[���[�̔ԍ����O
        Debug.Log(m_playerIndex);

        //�v���C���[�̐ڑ��l�����X�V
        if (m_playerIndex > m_playerIndexCount)
        {
            m_playerIndexCount = m_playerIndex;
        }
        for (int i = 0; i < 4; i++)
        {
            if (m_playerIndex == i)
            {
                var val = m_move * Time.deltaTime * 10.0f;
                transform.Translate(val.x, 0.0f, 0.0f);
                m_horizontal = val.x;
            }

            //�ړ����Ă���ꍇ�A�ړ��ʂ���
            if (m_horizontal != 0.0f)
            {
                directionX = m_horizontal;
            }

            //�v���C���[���E�Ɍ������Ƃ�
            if (directionX >= 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); // �摜�����̂܂ܕ\��
                m_isMovingRight = true;
                m_isMovingLeft = false;
            }

            //�v���C���[�����Ɍ������Ƃ�
            else
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); // �摜�𔽓]
                m_isMovingLeft = true;
                m_isMovingRight = false;
            }

            //�A�j���[�V�����̐؂�ւ�
            //��1�����F�A�j���[�V�����̕ϐ�
            //��2�����Ftrue or false
            m_anim.SetBool("Run", m_horizontal != 0.0f && !m_jumpAnimation);

            //player���n�ʂɂ���ꍇ
            if (m_groundCheckScript.GetIsGround() == true)
            {
                m_jumpAnimation = false;
                m_isJumping = true;
                //�W�����v�̍Đ����~�߂�
                m_anim.SetBool("Jump", m_jumpAnimation);
                //�W�����v�͂�����Ȃ�
                if (m_jumpPower > 0)
                {
                    float val = Mathf.Sqrt(m_jumpPower * -2.0f * m_setGravity);
                    transform.Translate(0.0f, val * Time.deltaTime, 0.0f);
                    m_isJumping = false;
                }
            }
            //player���n�ʂɂ��Ȃ��ꍇ
            else if (m_groundCheckScript.GetIsGround() == false)
            {
                m_jumpAnimation = true;
                //�A�j���[�V�����̐؂�ւ�
                m_anim.SetBool("Jump", m_jumpAnimation);
            }


        }
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        m_move = context.ReadValue<Vector2>().normalized;
    }

    /// <summary>
    /// �W�����v����
    /// </summary>
    /// <param name="context"></param>
    public void OnJump(InputAction.CallbackContext context)
    {
        //m_jumpPower = context.ReadValue<float>();
        if (context.performed && m_isJumping)
        {
            m_jumpPower = 20.0f;
            
        }
        else
        {
            m_jumpPower = 0.0f;
        }
    }
}