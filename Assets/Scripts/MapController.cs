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
    private int buttonflg = 0;//各ボタンの番号振り分け用
    private bool keyflg = false;//ボタンが押されているかどうか用
    private static bool startflg = false;//初回のみ実行する用

    #region 参考サイト
    // 値引き渡し
    // https://qiita.com/Akarinnn/items/00f58b7cbc7c5d659d92
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
        s1button.Select();//フォーカス変更
        Cursor.visible = false;//マウスカーソルの非表示
        
        //初回一度のみ実行
        if(startflg == false)
        {
            //Debug.Log("初回画面");
            startflg = true;
            s1button.interactable = true;
            s2button.interactable = false;
            s3button.interactable = false;
            s4button.interactable = false;
        }
        else
        {
            //Debug.Log("2つ目のステージ以降");
            //クリアするごとに値を呼ぶ(CameraManager.csを参照)
            s1button.interactable = true;
            s2button.interactable = CameraManager.s2;
            s3button.interactable = CameraManager.s3;
            s4button.interactable = CameraManager.s4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MapChange();
    }

    /// <summary>
    /// ステージ選択時のキーの割り当て
    /// </summary>
    public void MapChange()
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
                    if(s2button.interactable == false) s1button.Select();
                    else
                    {
                        s2button.Select();//フォーカス変更
                        audioSource.PlayOneShot(audioClips[1]);
                        s2button.interactable = true;
                        buttonflg = 1;
                    }
                    break;
                case 1:
                    if(s3button.interactable == false) s2button.Select();
                    else
                    {
                        s3button.Select();//フォーカス変更
                        audioSource.PlayOneShot(audioClips[1]);
                        s3button.interactable = true;
                        buttonflg = 2;
                    }
                    break;
                case 2:
                    if(s4button.interactable == false) s3button.Select();
                    else
                    {
                        s4button.Select();//フォーカス変更
                        audioSource.PlayOneShot(audioClips[1]);
                        s4button.interactable = true;
                        buttonflg = 3;
                    }
                    break;
            }
        }

        //Wキーが押された場合
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 3:
                    s3button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    s3button.interactable = true;
                    buttonflg = 2;
                    break;
                case 2:
                    s2button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    s2button.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    s1button.Select();//フォーカス変更
                    audioSource.PlayOneShot(audioClips[1]);
                    s1button.interactable = true;
                    buttonflg = 0;
                    break;
            }
        }

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

        //Rキーが押された場合
        if (Input.GetKeyDown(KeyCode.R) && keyflg == false)
        {
            keyflg = true;
            if (buttonflg == 0 || buttonflg == 1 || buttonflg == 2 || buttonflg == 3) 
                SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
        }
    }
}
