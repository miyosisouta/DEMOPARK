using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    Vector2 aPos, bPos;
    float moveTextTime = 0.0f;
    //レクトトランスフォームコンポーネント用変数
    RectTransform rt;
    //テキストメッシュプロコンポーネント用変数
    TextMeshProUGUI myTMP;

    // Start is called before the first frame update
    void Start()
    {
        //レクトトランスフォームコンポーネントの取得
        rt = GetComponent<RectTransform>();
        //テキストメッシュプロコンポーネントの取得
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
