using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    Vector2 aPos, bPos;
    float moveTextTime = 0.0f;
    //���N�g�g�����X�t�H�[���R���|�[�l���g�p�ϐ�
    RectTransform rt;
    //�e�L�X�g���b�V���v���R���|�[�l���g�p�ϐ�
    TextMeshProUGUI myTMP;

    // Start is called before the first frame update
    void Start()
    {
        //���N�g�g�����X�t�H�[���R���|�[�l���g�̎擾
        rt = GetComponent<RectTransform>();
        //�e�L�X�g���b�V���v���R���|�[�l���g�̎擾
        myTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void doSetEasing()
    {
        //aPos = Vector2();
        //bPos = Vector2.zero;
    }
    public void doEasing()
    {
        rt.anchoredPosition = Vector2.Lerp(aPos, bPos,moveTextTime);
    }
}
