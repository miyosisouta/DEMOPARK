using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeySprite : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float speed = 2.0f; // �Ǐ]���x
    [SerializeField] private Vector3 offset; // �^�[�Q�b�g����̃I�t�Z�b�g

    //�����擾�������ǂ����̃t���O
    bool isGetKey = false;

    [SerializeField] GameObject playerObject; // �v���C���[�I�u�W�F�N�g
    PlayerController playerController; // �v���C���[�R���g���[���[

    private void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetKey == true)
        {
            //�����v���C���[��Ǐ]����
            KeyMove();
            // �v���C���[�̈ړ������ɉ����Č��̈ʒu�𒲐�
            PlayerAxis();
        }
    }

    private void KeyMove()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            target.transform.position + offset,
            speed* Time.deltaTime
            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //�����擾����
            isGetKey = true;
        }
    }

    private void PlayerAxis()
    {
        if (playerController != null)
        {
            // �v���C���[�̈ړ������ɉ����Č��̈ʒu�𒲐�
            if (playerController.m_isMovingLeft)
            {
                offset.x = 0.7f; // ���Ɉړ����͍����ɃI�t�Z�b�g
            }
            else if (playerController.m_isMovingRight)
            {
                offset.x = -0.5f; // �E�Ɉړ����͉E���ɃI�t�Z�b�g
            }
            else
            {
                offset.x = -0.5f; // ��~���̓I�t�Z�b�g�Ȃ�
            }
        }
    }
}
