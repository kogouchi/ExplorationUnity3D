using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用

public class TitleController : MonoBehaviour
{
    //各ボタンの格納
    public Button sbutton;
    public Button ebutton;

    public AudioClip[] audioClips;//音源格納
    private AudioSource audioSource;//流すための音源を入れるもの
    //フラグ用
    private int buttonflg = 0;
    private bool keyflg = false;

    // Start is called before the first frame updates
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
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
        if (Input.GetKeyDown(KeyCode.S) && keyflg == false)
        {
            keyflg = true;
            if (buttonflg == 0)
            {
                ebutton.Select();
                audioSource.PlayOneShot(audioClips[1]);
                buttonflg++;
            }
        }
        else keyflg = false;

        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            if(buttonflg == 1)
            {
                sbutton.Select();
                audioSource.PlayOneShot(audioClips[1]);
                buttonflg--;
            }
        }
        else keyflg = false;

        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == 0)
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
