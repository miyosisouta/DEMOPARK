using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float Speed = 0.01f; // フェード速度
    float red, green, blue, alfa; // RGBA値

    public bool Out = false; // フェードアウトフラグ
    public bool In = false; // フェードインフラグ

    Image fadeImage; // フェード用のイメージ

    public GameObject target; // ターゲットオブジェクト（必要に応じて使用）


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Out = true; // フェードアウト開始
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(In)
        {
            FadeIn();
            Out = false; // フェードイン中はフェードアウトフラグをリセット
            Debug.Log("フェードイン中: ");
        }

        if(Out)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        alfa -= Speed;
        Alpha();
        if(alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false; // フェードイン完了後にイメージを非表示にする
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true; // フェードアウト開始時にイメージを表示
        alfa += Speed;
        Alpha();
        if(alfa >= 20)
        {
            Out = false;

            SceneManager.LoadScene("Stage1-3Scene"); // フェードアウト完了後にシーンをロード
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
