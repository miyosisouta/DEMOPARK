using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLoad : MonoBehaviour
{
    [SerializeField]float m_loadTime = 2.0f; // ロード時間

    private float m_timer = 0.0f; // タイマー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを更新
        m_timer += Time.deltaTime;
        // ロード時間を超えたらシーンをロード
        if (m_timer >= m_loadTime)
        {
            // シーンをロード
            SceneManager.LoadScene("Stage1-1Scene");
        }
    }
}
