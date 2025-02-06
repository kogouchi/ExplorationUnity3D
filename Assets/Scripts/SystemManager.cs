using UnityEngine;
using UnityEngine.SceneManagement;//シーンで使用
using UnityEngine.UI;//テキスト表示で使用

public class SystemManager : MonoBehaviour
{
    public GameObject tipsText;//tipsテキスト
    public GameObject tipskeyText;//tipskeyテキスト
    public GameObject clearText;//Clearテキスト
    public GameObject GameoverText;//GameOvewテキスト
    public GameObject settingText;//Settingテキスト
    public GameObject settingkeyText;//settingkeyテキスト
    public AudioSource audioSource;//流すための音源を入れるもの
    public AudioClip[] audioClips;//音源格納
    public Button playbutton;//続けるボタン
    public Button restartbutton;//リトライボタン
    public Button endbutton;//endボタン

    public int buttonflg = 0;//各ボタンの番号振り分けフラグ(複数なのでint)
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
        //tipsTextとゲームクリアとゲームオーバーが非表示の場合
        if (!tipsText.activeInHierarchy && !clearText.activeInHierarchy && !GameoverText.activeInHierarchy)
        {
            SettingManager();
            //設定画面が表示している場合
            if (settingText.activeInHierarchy)
            {
                //非表示------------------------
                tipskeyText.gameObject.SetActive(false);
                settingkeyText.gameObject.SetActive(false);
                //------------------------------
                SelectChange();
            }
        }
        TextManager();
    }

    /// <summary>
    /// ゲームクリアとゲームオーバーテキストの表示
    /// </summary>
    void TextManager()
    {
        if (clearText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            settingkeyText.SetActive(false);//非表示
            CameraManager.systemflg = true;//初期化
            if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("MapScene");//MapSceneに切り替え
        }
        if (GameoverText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            settingkeyText.SetActive(false);//非表示
            CameraManager.systemflg = true;//初期化
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);//現在のシーン再ロード
        }
    }

    /// <summary>
    /// 設定画面の表示
    /// </summary>
    void SettingManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && keyflg == false)
        {
            keyflg = true;
            buttonflg = 0;
            playbutton.Select();//起動と共にセレクト場所をリセット
            settingText.SetActive(true);
            CameraManager.systemflg = false;//非表示
            Time.timeScale = 0.0f;
        }
        else keyflg = false;
    }
    
    /// <summary>
    /// ボタンセレクト
    /// </summary>
    void SelectChange()
    {
        //キーが離された場合
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.R)) keyflg = false;

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
                case 0:
                    playbutton.Select();//フォーカス変更
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
                //再表示------------------------
                tipskeyText.gameObject.SetActive(true);
                settingkeyText.gameObject.SetActive(true);
                //------------------------------
                settingText.SetActive(false);
                Time.timeScale = 1.0f;
            }
            if (buttonflg == 1)
            {
                CameraManager.systemflg = true;//表示
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);//現在のシーン再ロード
            }
            if (buttonflg == 2)
            {
                CameraManager.systemflg = true;//表示
                SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
            }
        }
    }
}
