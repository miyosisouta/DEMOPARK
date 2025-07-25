using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class SwichScript : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject Swich_Push;

    [SerializeField] GameObject MoveGroundObject;
    MoveGround m_moveGroundScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクトの名前が"Player"の場合
        if(collision.gameObject.name == "Player")
        {
            //オブジェクトを生成する位置を計算
            Vector3 spawnPosition = new Vector2(37.84f, -1.86f);//transform.position + SpawnOffset;
            //オブジェクトを生成
            Instantiate(Swich_Push, spawnPosition,Quaternion.identity);
            //現在のオブジェクトを消す
            Destroy(gameObject);
            // MoveGroundObjectのMoveGroundスクリプトを呼び出す
            m_moveGroundScript.m_isMoving=true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       m_moveGroundScript = MoveGroundObject.GetComponent<MoveGround>();
    }

    void Update()
    {

    }
}

