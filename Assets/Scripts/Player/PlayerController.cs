using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// �q�I�u�W�F�N�g�̃t�B�[���h
    /// </summary>
    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;
    
    /// <summary>
    /// ���g�̃t�B�[���h
    /// </summary>
    Rigidbody2D rbody2D; // Rigidbody2D���`
 
    public const float m_moveSpeed = 5.0f; //�v���C���[�̈ړ����x

    private Animator m_anim;
    private bool m_jump = false;

    private float directionX;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[�{�[�h���͂̎擾
        float horizontal = Input.GetAxis("Horizontal");
        float vetrical = 0.0f;//Input.GetAxis("Vertical");

        //�L�����N�^�[�̈ړ�
        Vector3 movement = new Vector2(horizontal, vetrical);
        transform.position += movement * m_moveSpeed * Time.deltaTime;

        if(horizontal != 0.0f)
        {
            directionX = horizontal;
        }

        if (directionX >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

            //�A�j���[�V�����̐؂�ւ�
            //��1�����F�A�j���[�V�����̕ϐ�
            //��2�����Ftrue or false
            m_anim.SetBool("Run", horizontal != 0.0f && !m_jump);
 
        //player���n�ʂɂ���ꍇ
        if (m_groundCheckScript.GetIsGround())
        {
            m_jump = false;
            //�W�����v�̍Đ����~�߂�
            m_anim.SetBool("Jump", m_jump);

            //�W�����v�L�[����������
            if (Input.GetKeyDown("space"))
            {
                Jump();
                //�A�j���[�V�����̐؂�ւ�
                m_anim.SetBool("Jump", m_jump);
            }
        }
    }

    void Jump()
    {
        //�W�����v�̏���
        rbody2D.AddForce(Vector2.up * 600);
        m_jump = true;
    }
}
