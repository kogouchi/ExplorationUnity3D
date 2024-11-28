using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;
using Unity.VisualScripting;//シーンで使用

public class TitleController : MonoBehaviour
{
    public Button sbutton;
    public Button ebutton;
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        //TitleSceneだった場合
        if (SceneManager.GetActiveScene().name == "TitleScene")
            sbutton.Select();//フォーカス変更
    }

    // Update is called once per frame
    void Update()
    {
        TitleChange();
    }

    //Title切り替え
    public void TitleChange()
    {
        //Sキーが押された場合
        if (Input.GetKeyDown(KeyCode.S))
        {
            flg = false;
            ebutton.Select();
            Debug.Log(flg);
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = true;
            sbutton.Select();
            Debug.Log(flg);
        }
        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == true)
                SceneManager.LoadScene("MapScene");//MapSceneに切り替え
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了(ゲームエンジンで起動時)
#else
            Application.Quit();//ゲーム終了(ビルドで起動時)
#endif
            }
        }
    }
}
