using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGround : MonoBehaviour
{
   // 床が移動中かどうかのフラグ
    public bool m_isMoving = false;

    //waypointsは床がどこまで移動するか
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    // 床の移動速度
    [SerializeField] private float speed = 2.0f;

    private float startPosY; // 床の初期位置Y座標

    //床の上側のコライダーの中に入ったときに実行
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクト名が"Player"の場合
        if (collision.gameObject.CompareTag("Player"))
        {
            currentWaypointIndex = 0;

            m_isMoving = true; // 床の移動を開始
            //床の子オブジェクトにする
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //床の上側のコライダーから離れた時に実行
    private void OnCollisionExit2D(Collision2D collision)
    {
        currentWaypointIndex = 1;
    }

    private void Start()
    {
        // 床の初期位置Y座標を保存
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
