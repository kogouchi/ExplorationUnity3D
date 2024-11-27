using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用
using UnityEngine.EventSystems;//フォーカス変更時使用

public class ScenesController : MonoBehaviour
{
    public Button startButton;//startButtonの取得
    public Button endButton;//endButtonの取得
    public Button s1Button;//s1Buttonの取得
    public Button s2Button;//s2Buttonの取得
    public Button s3Button;//s3Buttonの取得
    public Button s4Button;//s4Buttonの取得
    private int flg = 0;//flg切り替え(Title、stageの画面切り替え時用)

    // Start is called before the first frame update
    void Start()
    {
        startButton = startButton.GetComponent<Button>();//button取得
        endButton = endButton.GetComponent<Button>();//button取得
        s1Button = s1Button.GetComponent<Button>();//s1button取得
        s2Button = s2Button.GetComponent<Button>();//s2button取得
        s3Button = s3Button.GetComponent<Button>();//s3button取得
        s4Button = s4Button.GetComponent<Button>();//s4button取得
        EventSystem.current.SetSelectedGameObject(null);//全てのフォーカスを解除
        //TitleSceneだった場合
        if (SceneManager.GetActiveScene().name == "TitleScene")
            startButton.Select();//startButtonにフォーカスする
        //MapSceneだった場合
        if (SceneManager.GetActiveScene().name == "MapScene")
            s1Button.Select();//s1Buttonにフォーカスする
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
            endButton.Select();//endButtonにフォーカスする
            Debug.Log("終了ボタン選択");
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = 0;
            startButton.Select();//startButtonにフォーカスする
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
                    s2Button.Select();//s2Buttonにフォーカスする
                    flg++;
                    Debug.Log("s2ボタン選択");
                    break;
                case 1:
                    s3Button.Select();//s3Buttonにフォーカスする
                    flg++;
                    Debug.Log("s3ボタン選択");
                    break;
                case 2:
                    s4Button.Select();//s4Buttonにフォーカスする
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
                    s3Button.Select();//s3Buttonにフォーカスする
                    flg--;
                    Debug.Log("s3ボタン選択");
                    break;
                case 2:
                    s2Button.Select();//s2Buttonにフォーカスする
                    flg--;
                    Debug.Log("s2ボタン選択");
                    break;
                case 1:
                    s1Button.Select();//s1Buttonにフォーカスする
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