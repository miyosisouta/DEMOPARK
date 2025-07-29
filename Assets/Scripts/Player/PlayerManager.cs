using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool m_playerSpawned = false;
    private DEMOPARK_2025 m_inputActions;

    // Start is called before the first frame update
    void Start()
    {
        //インプットアクションを使用可能にする
        m_inputActions = new DEMOPARK_2025();
        m_inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが一人もスポーンしていない場合
        if (!m_playerSpawned)
        {
            OnPlayer();
        }
    }
    /// <summary>
    /// プレイヤーが一人でもスポーンしたかどうか
    /// </summary>
    private void OnPlayer()
    {
        if (m_inputActions.Player.PlayerSpawner.triggered)
        {
            m_playerSpawned = true;
        }
    }
    /// <summary>
    /// プレイヤーがスポーンしているかどうか
    /// </summary>
    /// <returns></returns>
    public bool PlayerSpawned()
    {
        if (m_playerSpawned)
        {
            return true;
        }
        return false;
    }
}
