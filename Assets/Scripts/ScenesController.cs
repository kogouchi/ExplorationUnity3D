using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用
using UnityEngine.EventSystems;//フォーカス変更時使用

//TitleとMapの切り替え＋各Sound設定
public class ScenesController : MonoBehaviour
{
    public Button[] buttons;//Button格納
    private int flg = 0;//flg切り替え(Title、stageの画面切り替え時用)

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);//全てのフォーカスを解除
        //TitleSceneだった場合
        if (SceneManager.GetActiveScene().name == "TitleScene")
            buttons[0].Select();//フォーカス変更
        //MapSceneだった場合
        if (SceneManager.GetActiveScene().name == "MapScene")
            buttons[2].Select();//フォーカス変更
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Title切り替え
    public void TitleChange()
    {
        //Sキーが押された場合
        if (Input.GetKeyDown(KeyCode.S))
        {
            flg = 1;
            buttons[1].Select();//endButtonにフォーカスする
            Debug.Log("終了ボタン選択");
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = 0;
            buttons[0].Select();//startButtonにフォーカスする
            Debug.Log("開始ボタン選択");
        }
        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0)
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

    //Map切り替え
    public void MapChange()
    {
        //Sキーが押された場合(flgでボタンの位置を変更+flgが4だった場合何もしない)
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (flg)
            {
                case 0:
                    buttons[3].Select();//フォーカス変更
                    flg++;
                    Debug.Log("s2ボタン選択");
                    break;
                case 1:
                    buttons[4].Select();//フォーカス変更
                    flg++;
                    Debug.Log("s3ボタン選択");
                    break;
                case 2:
                    buttons[5].Select();//フォーカス変更
                    flg++;
                    Debug.Log("s4ボタン選択");
                    break;
            }
            Debug.Log(flg);
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch(flg)
            {
                case 3:
                    buttons[4].Select();//フォーカス変更
                    flg--;
                    Debug.Log("s3ボタン選択");
                    break;
                case 2:
                    buttons[3].Select();//フォーカス変更
                    flg--;
                    Debug.Log("s2ボタン選択");
                    break;
                case 1:
                    buttons[2].Select();//フォーカス変更
                    flg--;
                    Debug.Log("s1ボタン選択");
                    break;
            }
            Debug.Log(flg);
        }
        //スペースキーが押された場合
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0) SceneManager.LoadScene("GameScene1");//GameScene1に切り替え
            if (flg == 1) SceneManager.LoadScene("GameScene2");//GameScene2に切り替え
            if (flg == 2) SceneManager.LoadScene("GameScene3");//GameScene3に切り替え
            if (flg == 3) SceneManager.LoadScene("GameScene4");//GameScene4に切り替え
        }
    }
}