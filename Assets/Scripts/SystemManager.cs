using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンで使用
using UnityEngine.UI;//テキスト表示で使用

public class SystemManager : MonoBehaviour
{
    public GameObject tipsText;//tipsテキスト
    public GameObject clearText;//Clearテキスト
    public GameObject GameoverText;//GameOvewテキスト
    public GameObject settingText;//Settingテキスト
    public AudioSource audioSource;//流すための音源を入れるもの
    public AudioClip[] audioClips;//音源格納
    public Button playbutton;//続けるボタン
    public Button restartbutton;//リトライボタン
    public Button endbutton;//endボタン

    private int buttonflg = 0;//各ボタンの番号振り分けフラグ(複数なのでint)
    private bool keyflg = false;//ボタンが押されているかどうかフラグ

    // Start is called before the first frame update
    void Start()
    {
        settingText.SetActive(false);//設定画面非表示
        playbutton.Select();//始めに選択されている
    }

    // Update is called once per frame
    void Update()
    {
        if(!tipsText.activeInHierarchy)
        {
            SettingManager();
            SelectChange();
        }

        if (clearText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("MapScene");//MapSceneに切り替え
        }
        if (GameoverText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            //if (Input.GetKeyDown(KeyCode.Space))
            //    SceneManager.LoadScene("MapScene");//MapSceneに切り替え
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (SceneManager.GetActiveScene().name == "GameScene1")
                    SceneManager.LoadScene("GameScene1");//GameScene1に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene2")
                    SceneManager.LoadScene("GameScene2");//GameScene2に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene3")
                    SceneManager.LoadScene("GameScene3");//GameScene3に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene4")
                    SceneManager.LoadScene("GameScene4");//GameScene4に切り替え
            }
        }
    }

    /// <summary>
    /// 設定画面の表示
    /// </summary>
    void SettingManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playbutton.Select();//起動と共にセレクト場所をリセット
            settingText.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    
    /// <summary>
    /// ボタンセレクト
    /// </summary>
    void SelectChange()
    {
        //キーが離された場合
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) keyflg = false;

        //Sキーが押された場合(flgでボタンの位置を変更+flgが4だった場合何もしない)
        if (Input.GetKeyDown(KeyCode.S) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 0:
                    restartbutton.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    restartbutton.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    endbutton.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    endbutton.interactable = true;
                    buttonflg = 2;
                    break;
            }
        }

        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 2:
                    restartbutton.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    restartbutton.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    playbutton.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    playbutton.interactable = true;
                    buttonflg = 0;
                    break;
            }
        }

        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space) && keyflg == false)
        {
            keyflg = true;
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == 0)
            {
                settingText.SetActive(false);
                Time.timeScale = 1.0f;
            }
            if (buttonflg == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);//現在のシーン再ロード
            if (buttonflg == 2) SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
        }
    }
}
