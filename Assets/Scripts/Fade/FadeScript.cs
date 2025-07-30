using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float Speed = 0.01f; // �t�F�[�h���x
    float red, green, blue, alfa; // RGBA�l

    public bool Out = false; // �t�F�[�h�A�E�g�t���O
    public bool In = false; // �t�F�[�h�C���t���O

    Image fadeImage; // �t�F�[�h�p�̃C���[�W

    public GameObject target; // �^�[�Q�b�g�I�u�W�F�N�g�i�K�v�ɉ����Ďg�p�j


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Out = true; // �t�F�[�h�A�E�g�J�n
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
            Out = false; // �t�F�[�h�C�����̓t�F�[�h�A�E�g�t���O�����Z�b�g
            Debug.Log("�t�F�[�h�C����: ");
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
            fadeImage.enabled = false; // �t�F�[�h�C��������ɃC���[�W���\���ɂ���
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true; // �t�F�[�h�A�E�g�J�n���ɃC���[�W��\��
        alfa += Speed;
        Alpha();
        if(alfa >= 20)
        {
            Out = false;

            SceneManager.LoadScene("Stage1-3Scene"); // �t�F�[�h�A�E�g������ɃV�[�������[�h
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
