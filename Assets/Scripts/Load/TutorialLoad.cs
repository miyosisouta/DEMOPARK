using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLoad : MonoBehaviour
{
    [SerializeField]float m_loadTime = 2.0f; // ���[�h����

    private float m_timer = 0.0f; // �^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[���X�V
        m_timer += Time.deltaTime;
        // ���[�h���Ԃ𒴂�����V�[�������[�h
        if (m_timer >= m_loadTime)
        {
            // �V�[�������[�h
            SceneManager.LoadScene("Stage1-1Scene");
        }
    }
}
