using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum GhostState
{
    Hide, // 停止
    Move, // 追跡
}

public class GhostControler : MonoBehaviour
{
    [SerializeField] GameObject m_doorObject;
    DoorController m_doorControllerScript;

    Rigidbody2D rBody2D;

    public SpriteRenderer m_ghostSprite;
    public Sprite m_hideRender;
    public Sprite m_moveRender;

    private GhostState m_state = GhostState.Move;
    private GameObject m_rightMostPlayerObject = null;
    private GameObject m_leftMostPlayerObject = null;
    private GameObject m_minDistanceToPlayerObject = null;
    [SerializeField]private bool m_canNotMove;
    [SerializeField] private float m_moveSpeed = 1.0f;
    private bool m_canMove = false;
    private float m_rightMostPlayerDistance = float.MinValue;
    private float m_leftMostPlayerDistance = float.MaxValue;
    private float m_minDistanceToPlayer = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        m_doorControllerScript = m_doorObject.GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostTargetPlayers(); //ゴーストのターゲットの設定
        m_canNotMove = IsPlayerLookingAtGhost(); //プレイヤーがゴーストを見ているか確認
        SetGhostState(); // ステートと画像の変更
    }

    /// <summary>
    /// 物理演算の更新処理
    /// </summary>
    void FixedUpdate()
    {
        if (m_canMove)
        {
            switch (m_state)
            {
                case GhostState.Hide:
                    rBody2D.velocity = Vector3.zero;
                    break;
                case GhostState.Move:
                    Move();
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Ghostより右側と左側、最も近いプレイヤーを探し、情報を保存する関数
    /// </summary>
    void UpdateGhostTargetPlayers()
    {
        m_doorControllerScript.FindPlayer();
        //接続しているコントローラーの数繰り返す
        // 全プレイヤーに対して
        foreach (GameObject playerGameObject in m_doorControllerScript.m_playerGameObjects)
        {
            // プレイヤーの位置
            Vector2 playerPos = playerGameObject.transform.position;
            //ゴーストの位置
            Vector2 ghostPos = this.transform.position;

            // ゴーストからプレイヤーへの方向ベクトル
            float directionToPlayer = playerPos.x - ghostPos.x;
            float distance = Vector2.Distance(playerPos, ghostPos);

            //ゴーストより右側にいるかつ一番遠い場合
            if (directionToPlayer >= 0 && m_rightMostPlayerDistance < directionToPlayer)
            {
                m_rightMostPlayerDistance = directionToPlayer;
                m_rightMostPlayerObject = playerGameObject;
            }

            //ゴーストより左側にいるかつ一番遠い場合
            if (directionToPlayer <= 0 && m_leftMostPlayerDistance > directionToPlayer)
            {
                m_leftMostPlayerDistance = directionToPlayer;
                m_leftMostPlayerObject = playerGameObject;
            }

            //ゴーストから一番近い距離の場合
            if (m_minDistanceToPlayer > distance)
            {
                m_minDistanceToPlayer = distance;
                m_minDistanceToPlayerObject = playerGameObject;
                m_canMove = true;
            }
            //Debug.Log(distance);
        }
    }

    /// <summary>
    /// ゴーストの画像と状態の変更
    /// </summary>
    void SetGhostState()
    {
        //ゴーストが動けない状態の場合
        if (m_canNotMove)
        {
            m_ghostSprite.sprite = m_hideRender;
            m_state = GhostState.Hide;
        }
        //ゴーストが動ける場合
        else if (!m_canNotMove)
        {
            m_ghostSprite.sprite = m_moveRender;
            m_state = GhostState.Move;
        }
    }

    /// <summary>
    /// ゴーストの追跡処理。
    /// </summary>
    void Move()
    {
        // ゴーストとプレイヤーの位置
        Vector2 ghostPos = transform.position;
        Vector2 playerPos = m_minDistanceToPlayerObject.transform.position;

        // ゴースト → プレイヤー方向の単位ベクトル
        Vector2 direction = (playerPos - ghostPos).normalized;

        // 移動させる
        rBody2D.velocity = direction * m_moveSpeed;
    }
    /// <summary>
    /// プレイヤーがゴーストの方を見ているかどうか
    /// </summary>
    /// <returns></returns>
    bool IsPlayerLookingAtGhost()
    {
        //ゴーストの位置
        Vector2 ghostPos = this.transform.position;

        foreach (GameObject playerObject in m_doorControllerScript.m_playerGameObjects)
        {
            // プレイヤーの位置
            Vector2 playerPos = playerObject.transform.position;
            //プレイヤーが向いている方向
            Vector3 direction = playerObject.transform.localScale;
            // ゴーストからプレイヤーへの方向ベクトル
            float directionToPlayer = ghostPos.x - playerPos.x;

            //プレイヤーが左を向いているかつ
            //プレイヤーの位置がゴーストより右側だった場合
            if (direction.x < 0.0f && directionToPlayer < 0.0f)
            {
                return true;
            }

            //プレイヤーが右を向いているかつ
            //プレイヤーの位置がゴーストより左側だった場合
            else if (direction.x > 0.0f && directionToPlayer > 0.0f)
            {
                return true;
            }
            //Debug.Log(direction.x);
            //Debug.Log(directionToPlayer);
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
