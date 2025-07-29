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
        //�C���v�b�g�A�N�V�������g�p�\�ɂ���
        m_inputActions = new DEMOPARK_2025();
        m_inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[����l���X�|�[�����Ă��Ȃ��ꍇ
        if (!m_playerSpawned)
        {
            OnPlayer();
        }
    }
    /// <summary>
    /// �v���C���[����l�ł��X�|�[���������ǂ���
    /// </summary>
    private void OnPlayer()
    {
        if (m_inputActions.Player.PlayerSpawner.triggered)
        {
            m_playerSpawned = true;
        }
    }
    /// <summary>
    /// �v���C���[���X�|�[�����Ă��邩�ǂ���
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
