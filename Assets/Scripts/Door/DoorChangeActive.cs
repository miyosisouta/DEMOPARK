using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChangeActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �A�N�e�B�u��Ԃ̐؂�ւ�
    /// </summary>
    public void ActiveSwitch()
    {
        bool active = gameObject.activeSelf;
        if (!active)
        {
            gameObject.SetActive(true);
        }

        else if (active)
        {
            gameObject.SetActive(false);
        }
    }
}
