using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class SwichScript : MonoBehaviour
{
    //��������I�u�W�F�N�g
    public GameObject Swich_Push;

    [SerializeField] GameObject MoveGroundObject;
    MoveGround m_moveGroundScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Փ˂����I�u�W�F�N�g�̖��O��"Player"�̏ꍇ
        if(collision.gameObject.name == "Player")
        {
            //�I�u�W�F�N�g�𐶐�����ʒu���v�Z
            Vector3 spawnPosition = new Vector2(37.84f, -1.86f);//transform.position + SpawnOffset;
            //�I�u�W�F�N�g�𐶐�
            Instantiate(Swich_Push, spawnPosition,Quaternion.identity);
            //���݂̃I�u�W�F�N�g������
            Destroy(gameObject);
            // MoveGroundObject��MoveGround�X�N���v�g���Ăяo��
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

