using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeySprite : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float speed = 2.0f; // 追従速度
    [SerializeField] private Vector3 offset; // ターゲットからのオフセット

    //鍵を取得したかどうかのフラグ
    bool isGetKey = false;

    [SerializeField] GameObject playerObject; // プレイヤーオブジェクト
    PlayerController playerController; // プレイヤーコントローラー

    private void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetKey == true)
        {
            //鍵がプレイヤーを追従する
            KeyMove();
            // プレイヤーの移動方向に応じて鍵の位置を調整
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
            //鍵を取得した
            isGetKey = true;
        }
    }

    private void PlayerAxis()
    {
        if (playerController != null)
        {
            // プレイヤーの移動方向に応じて鍵の位置を調整
            if (playerController.m_isMovingLeft)
            {
                offset.x = 0.7f; // 左に移動中は左側にオフセット
            }
            else if (playerController.m_isMovingRight)
            {
                offset.x = -0.5f; // 右に移動中は右側にオフセット
            }
            else
            {
                offset.x = -0.5f; // 停止中はオフセットなし
            }
        }
    }
}
