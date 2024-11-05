using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UISystemに追加
//操作説明テキストの表示
public class UIManager : MonoBehaviour
{
    public GameObject Uiobj;

    // Start is called before the first frame update
    void Start()
    {
        Uiobj.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Fキーが押された");

            //UItextが非表示の場合
            if (Uiobj.activeSelf)
            {
                Uiobj.SetActive(false);
                Time.timeScale = 1.0f;
                Debug.Log("ゲーム再生");
            }
            else
            {
                Uiobj.SetActive(true);
                Time.timeScale = 0.0f;
                Debug.Log("ゲーム停止");
            }
        }
    }
}