using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGround : MonoBehaviour
{
   // �����ړ������ǂ����̃t���O
    public bool m_isMoving = false;

    //waypoints�͏����ǂ��܂ňړ����邩
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    // ���̈ړ����x
    [SerializeField] private float speed = 2.0f;

    private float startPosY; // ���̏����ʒuY���W

    //���̏㑤�̃R���C�_�[�̒��ɓ������Ƃ��Ɏ��s
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Փ˂����I�u�W�F�N�g����"Player"�̏ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            currentWaypointIndex = 0;

            m_isMoving = true; // ���̈ړ����J�n
            //���̎q�I�u�W�F�N�g�ɂ���
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //���̏㑤�̃R���C�_�[���痣�ꂽ���Ɏ��s
    private void OnCollisionExit2D(Collision2D collision)
    {
        currentWaypointIndex = 1;
    }

    private void Start()
    {
        // ���̏����ʒuY���W��ۑ�
        startPosY = transform.position.y;
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
        //if (transform.position.y <= startPosY)
        //{
        //    return;
        //}

        var waypointPos = waypoints[currentWaypointIndex].transform.position;
        var maxDistanceDelta = Time.deltaTime * speed;

        transform.position = Vector2.MoveTowards(
            transform.position,
            waypointPos,
            maxDistanceDelta
        );
    }

}
