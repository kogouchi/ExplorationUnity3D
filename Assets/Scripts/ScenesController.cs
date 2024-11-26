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
    private int flg = 0;//flg切り替え

    // Start is called before the first frame update
    void Start()
    {
        startButton = startButton.GetComponent<Button>();//button取得
        endButton = endButton.GetComponent<Button>();//button取得
        endButton = s1Button.GetComponent<Button>();//s1button取得
        endButton = s2Button.GetComponent<Button>();//s2button取得
        endButton = s3Button.GetComponent<Button>();//s3button取得
        endButton = s4Button.GetComponent<Button>();//s4button取得
        EventSystem.current.SetSelectedGameObject(null);//全てのフォーカスを解除
        startButton.Select();//startButtonにフォーカスする
        s1Button.Select();//s1Buttonにフォーカスする
    }

    // Update is called once per frame
    void Update()
    {
        //TitleSceneだった場合
        if (SceneManager.GetActiveScene().name == "TitleScene") TitleChange();//Title切り替え
        //MapSceneだった場合
        if (SceneManager.GetActiveScene().name == "MapScene") MapChange();//Map切り替え
    }

    //Title切り替え
    public void TitleChange()
    {
        //Sキーが押された場合
        if (Input.GetKeyDown(KeyCode.S))
        {
            endButton.Select();//endButtonにフォーカスする
            flg = 1;
            Debug.Log("終了ボタン選択");
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            startButton.Select();//startButtonにフォーカスする
            flg = 0;
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
                UnityEditor.EditorApplication.isPlaying = false;//ゲーム終了
#else
        Application.Quit();//ゲーム終了
#endif
            }
        }
    }

    //Map切り替え
    public void MapChange()
    {
        //Sキーが押された場合
        if (Input.GetKeyDown(KeyCode.S))
        {
            endButton.Select();//endButtonにフォーカスする
            flg = 1;
            Debug.Log("終了ボタン選択");
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            startButton.Select();//startButtonにフォーカスする
            flg = 2;
            Debug.Log("開始ボタン選択");
        }
    }
}