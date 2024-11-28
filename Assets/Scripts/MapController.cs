using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;
using Unity.VisualScripting;//シーンで使用

public class MapController : MonoBehaviour
{
    public Button s1button;
    public Button s2button;
    public Button s3button;
    public Button s4button;
    private int flg = 0;

    // Start is called before the first frame update
    void Start()
    {
        //MapSceneだった場合
        if (SceneManager.GetActiveScene().name == "MapScene")
            s1button.Select();//フォーカス変更
    }

    // Update is called once per frame
    void Update()
    {
        MapChange();
    }

    //Map切り替え
    public void MapChange()
    {
        //Sキーが押された場合(flgでボタンの位置を変更+flgが4だった場合何もしない)
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (flg)
            {
                case 0:
                    s2button.Select();//フォーカス変更
                    flg++;
                    break;
                case 1:
                    s3button.Select();//フォーカス変更
                    flg++;
                    break;
                case 2:
                    s4button.Select();//フォーカス変更
                    flg++;
                    break;
            }
            Debug.Log(flg);
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (flg)
            {
                case 3:
                    s3button.Select();//フォーカス変更
                    flg--;
                    break;
                case 2:
                    s2button.Select();//フォーカス変更
                    flg--;
                    break;
                case 1:
                    s1button.Select();//フォーカス変更
                    flg--;
                    break;
            }
            Debug.Log(flg);
        }
        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0) SceneManager.LoadScene("GameScene1");//GameScene1に切り替え
            if (flg == 1) SceneManager.LoadScene("GameScene2");//GameScene2に切り替え
            if (flg == 2) SceneManager.LoadScene("GameScene3");//GameScene3に切り替え
            if (flg == 3) SceneManager.LoadScene("GameScene4");//GameScene4に切り替え
        }
    }
}
