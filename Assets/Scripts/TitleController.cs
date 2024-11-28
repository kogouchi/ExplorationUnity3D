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
    private bool buttonflg = false;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonflg = false;
            ebutton.Select();
            audioSource.PlayOneShot(audioClips[1]);
        }
        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonflg = true;
            sbutton.Select();
            audioSource.PlayOneShot(audioClips[1]);
        }
        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == true)
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
