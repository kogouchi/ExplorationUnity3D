using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンで使用

public class SystemManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //F1キーが押された場合
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
        }
    }
}
