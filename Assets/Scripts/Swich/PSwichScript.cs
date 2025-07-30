using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSwichScript : MonoBehaviour
{
    [SerializeField] GameObject PGround;

    [SerializeField] private Renderer m_rendererSwitch; // PGround��Renderer���Q��

    public bool m_isPush = false; // �X�C�b�`�������ꂽ���ǂ����̃t���O
    public bool m_isCalledOnece = false; // PGround����x�����������邽�߂̃t���O

    public float m_showTime = 5.0f; // ���̕\������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Փ˂����I�u�W�F�N�g�̖��O��"Player"�̏ꍇ
        if (collision.gameObject.name == "Player")
        {
            //��\����PGround��\���ɂ���
            PGround.SetActive(true);

            // �X�C�b�`�������ꂽ�t���O�𗧂Ă�
            m_isPush = true;

            //���݂̃I�u�W�F�N�g���\���ɂ���
            //gameObject.SetActive(false);
            m_rendererSwitch.enabled = false; // �X�C�b�`��Renderer���\���ɂ���
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �N���[�����\���ɂ���
        PGround.SetActive(false);
    }

    void Update()
    {

        // PSwichScript��m_isPush��true�̏ꍇ�APGround�𐶐�
        if (m_isPush == true && m_isCalledOnece == false)
        {
            m_isCalledOnece = true; // ��x�����������邽�߂̃t���O�𗧂Ă�

            // PGround�𐶐�����ʒu���v�Z
            Vector3 spawnPosition = new Vector2(42.5f, -3.1f); // ��Ƃ��ČŒ�ʒu���g�p

            // PGround�𐶐�
            //GameObject clonePGround = Instantiate(PGround);
            PGround.SetActive(true); // �N���[����\���ɂ���

            Debug.Log("seisei kiteru");
        }

        SetTime();
    }

    public void SetTime()
    {
        // �X�C�b�`�������ꂽ�ꍇ�APGround�̕\�����Ԃ��Ǘ�
        if (m_isPush && PGround != null)
        {
            // PGround�̕\�����Ԃ��J�E���g�_�E��
            m_showTime -= Time.deltaTime;
            // �\�����Ԃ�0�ȉ��ɂȂ�����PGround���폜
            if (m_showTime <= 0f)
            {
                //GameObject clonePGround = Instantiate(PGround);
                PGround.SetActive(false); // �N���[�����\���ɂ���

                // �X�C�b�`�̃t���O�����Z�b�g
                m_isPush = false;

                // �X�C�b�`��Renderer��\���ɂ���
                m_rendererSwitch.enabled = true;

                // ��x�����������邽�߂̃t���O�𗧂Ă�
                m_isCalledOnece = false;

                // �\�����Ԃ����Z�b�g
                m_showTime = 6.0f; // �K�v�ɉ����ď����l��ݒ�

                //�����ɂ� log
                Debug.Log("osareta kiteru");
            }
        }
    }
}
