using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameCamera : MonoBehaviour
{

    List<GameObject> m_playerGameObjects = new List<GameObject>();
    List<PlayerController> m_playerControllers = new List<PlayerController>();

    private PlayerController m_playerController; // プレイヤーコントローラーの参照

    private Vector3 m_initPos;

    public float cameraMinX = 0f;      // カメラ移動の最小X（左端）
    public float cameraMaxX = 100f;    // カメラ移動の最大X（右端）
    public float cameraMinY = 0f;      // カメラ移動の最小Y（下端）
    public float cameraMaxY = 100f;    // カメラ移動の最大Y（上端）
    public float smoothTime = 0.2f;    // カメラ移動のなめらかさ

    //プレイヤーのX座標を取得するための変数
    private Vector3 m_playerPos ;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        


       
    }

    // Update is called once per frame
    void Update()
    {
        //リスト内のゲームオブジェクトの中にあるPlayerをすべて見つける
        m_playerGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        // 見つけたPlayerの中にあるPlayerControllerをリストの中に入れる
        foreach (GameObject playerGameObject in m_playerGameObjects)
        {
            m_playerControllers.Add(playerGameObject.GetComponent<PlayerController>());
        }

        // プレイヤーの位置を取得
        if (m_playerControllers.Count > 0)
        {
            m_playerController = m_playerControllers[0]; // 最初のプレイヤーを取得
            m_playerPos = m_playerController.transform.position;
        }
        else
        {
            return; // プレイヤーがいない場合は何もしない
        }

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (m_playerControllers.Count == 0 || m_playerControllers[0] == null) return;

        // プレイヤーの位置を取得
        float x = m_playerControllers[0].transform.position.x;
        float y = m_playerControllers[0].transform.position.y;

        // 範囲制限
        x = Mathf.Clamp(x, cameraMinX, cameraMaxX);
        y = Mathf.Clamp(y, cameraMinY, cameraMaxY);

        // 現在のZを維持したまま追従位置を設定
        Vector3 targetPosition = new Vector3(x, y, transform.position.z);

        // スムーズに追従
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);




    }

   
}
