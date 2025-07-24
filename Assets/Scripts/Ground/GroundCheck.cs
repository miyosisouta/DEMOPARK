using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // �ڒn���Ă��邩���i�[����ϐ�
    bool m_isGround = false;

    /// <summary>
    /// �X�^�[�g
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    void Update()
    {
        
    }
    /// <summary>
    /// �n�ʂɐG��Ă��邩��Ԃ��֐�
    /// </summary>
    public bool GetIsGround()
    {
        return m_isGround;
    }

    /// <summary>
    /// ���t���[���ŏ��ɐڒn��������Z�b�g����
    /// </summary>
    private void FixedUpdate()
    {
        m_isGround = false;
    }

    /// <summary>
    /// �n�ʂ̃^�O���t�����I�u�W�F�N�g�ɏՓ˂��Ă��邩����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }
}
