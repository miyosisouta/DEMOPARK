using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody2D; // Rigidbody2D���`

    [SerializeField] GameObject m_groundCheckObject;
    GroundCheck m_groundCheckScript;

    public const float m_moveSpeed = 5.0f; //�v���C���[�̈ړ����x

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
        m_groundCheckScript = m_groundCheckObject.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[�{�[�h���͂̎擾
        float horizontal = Input.GetAxis("Horizontal");
        float vetrical = Input.GetAxis("Vertical");

        //�L�����N�^�[�̈ړ�
        Vector3 movement = new Vector3(horizontal, vetrical, 0f);
        transform.position += movement * m_moveSpeed * Time.deltaTime;

        //�L�����N�^�[�̃W�����v
        if (Input.GetKeyDown("space")) //�W�����v�L�[��������
        {
            if (m_groundCheckScript.GetIsGround())//player���n�ʂɂ���ꍇ
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        //�W�����v�̏���
        rbody2D.AddForce(Vector2.up * 600);
    }
}
