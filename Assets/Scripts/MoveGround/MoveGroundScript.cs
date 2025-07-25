using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveGround : MonoBehaviour
{
    // 床がどこまで移動するか
    [SerializeField] private GameObject[] waypoints;

    public bool m_isMoving = false;
    private int currentWaypointIndex = 0;

    

    // 床の移動速度
    [SerializeField] private float speed = 2.0f;

    //床の上側のコライダーの中に入ったときに実行
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突したオブジェクト名が"Player"の場合
        if (collision.gameObject.name == "Player")
        {
            //床の子オブジェクトにする
            collision.gameObject.transform.SetParent(transform);
        }
    }

        //床の上側のコライダーから離れた時に実行
        private void OnTriggerExit2D(Collider2D collision)
    {
        //衝突したオブジェクト名が"Player"の場合
        if (collision.gameObject.name == "Player")
        {
            //床の子オブジェクトから外す
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
        //現在の床の位置から、目的地に向かって移動する
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        //
        float distance = transform.position.magnitude - waypoints[currentWaypointIndex].transform.position.magnitude; // 現在の床の位置と目的地の距離を計算
        float destroyDistance = -1.7f; // 目的地のオブジェクトを削除する距離

        if (distance <= destroyDistance)
        {
            Destroy(waypoints[currentWaypointIndex]); // 目的地のオブジェクトを削除
            waypoints[currentWaypointIndex] = null; // 配列から削除
            m_isMoving = false; // 床の移動を停止
        }
       
    }

    
}
