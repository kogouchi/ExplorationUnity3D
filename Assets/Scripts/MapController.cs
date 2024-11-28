using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用

public class MapController : MonoBehaviour
{
    //各ボタンの格納
    public Button s1button;
    public Button s2button;
    public Button s3button;
    public Button s4button;

    public AudioClip[] audioClips;//音源格納
    private AudioSource audioSource;//流すための音源を入れるもの

    //フラグ用
    private int buttonflg = 0;
    private bool keyflg = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
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
        if (Input.GetKeyDown(KeyCode.S) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 0:
                    s2button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
                case 1:
                    s3button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
                case 2:
                    s4button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
            }
            Debug.Log(buttonflg);
        }
        else keyflg = false;

        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 3:
                    s3button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
                case 2:
                    s2button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
                case 1:
                    s1button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
            }
            Debug.Log(buttonflg);
        }
        else keyflg = false;

        //スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space) && keyflg == false)
        {
            keyflg = true;
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == 0) SceneManager.LoadScene("GameScene1");//GameScene1に切り替え
            if (buttonflg == 1) SceneManager.LoadScene("GameScene2");//GameScene2に切り替え
            if (buttonflg == 2) SceneManager.LoadScene("GameScene3");//GameScene3に切り替え
            if (buttonflg == 3) SceneManager.LoadScene("GameScene4");//GameScene4に切り替え
        }
        else keyflg = false;

        //Rキーが押された場合
        if (Input.GetKey(KeyCode.R) && keyflg == false)
        {
            keyflg = true;
            if (buttonflg == 0) SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
        }
        else keyflg = false;
    }
}
