using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveGround : MonoBehaviour
{
    // �����ǂ��܂ňړ����邩
    [SerializeField] private GameObject[] waypoints;

    public bool m_isMoving = false;
    private int currentWaypointIndex = 0;

    // ���̈ړ����x
    [SerializeField] private float speed = 2.0f;

    //���̏㑤�̃R���C�_�[�̒��ɓ������Ƃ��Ɏ��s
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g����"Player"�̏ꍇ
        if (collision.gameObject.name == "Player")
        {
            //���̎q�I�u�W�F�N�g�ɂ���
            collision.gameObject.transform.SetParent(transform);
        }
    }

        //���̏㑤�̃R���C�_�[���痣�ꂽ���Ɏ��s
        private void OnTriggerExit2D(Collider2D collision)
    {
        //�Փ˂����I�u�W�F�N�g����"Player"�̏ꍇ
        if (collision.gameObject.name == "Player")
        {
            //���̎q�I�u�W�F�N�g����O��
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void Update()
    {
        if (m_isMoving == true)
        {
            Move();
        }
    }


    public void Move()
    {
        //���݂̏��̈ʒu����A�ړI�n�Ɍ������Ĉړ�����
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

}
