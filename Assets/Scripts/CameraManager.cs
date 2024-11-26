using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用

//シーンごとにコード分けるときれいかも↓

//MainCameraにCameraManagerをアタッチ
//Textのアクティブ、非アクティブ化の処理
//GameOverTextの表示、ClearTextの表示
//リフレッシュレートを設定（設定することで軽くなるらしい）
public class CameraManager : MonoBehaviour
{
    public PlayerController player;//「PlayerController」の参照
    public EnemyController enemy;//「EnemyController」の参照
    public SkyEnemyController skyEnemy;//SkyEnemyControllerの参照
    public GameObject player_obj;//player取得
    public GameObject enemy_obj;//enemmy取得
    public GameObject tipsText;//TipsTextの取得
    public Text MissionText;//missiontext取得
    public Text clearText;//cleartext取得
    public Text gameOverText;//gameovertext取得
    public Text timeText;//timetext取得
    public float countdown = 60;//カウントダウン
    private bool flg = false;

    #region 参考サイト
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートの設定
        tipsText.SetActive(true);//Tipsの表示
        Time.timeScale = 0.0f;//ゲーム停止
        TipsTextSeting();//テキストの設定
        MissionTextSeting();//テキストの設定
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();//SceneChange用

        //gamescene1だった場合
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            TipsTextManager();//TipsTextManagerの呼び出し
            //playerが非表示の場合
            if (!player_obj.activeInHierarchy) GameOverManager();
            //enemyが非表示の場合
            if (!enemy_obj.activeInHierarchy)
            {
                clearText.gameObject.SetActive(true);//ClearText表示
                Time.timeScale = 0.0f;
            }
        }
        //gamescene2だった場合
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            TipsTextManager();//TipsTextManagerの呼び出し
            TimeManager();//TimeManagerの呼び出し
            //playerが非表示の場合
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//timeテキスト非表示
            }
        }
        //gamescene3だった場合
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            TipsTextManager();//TipsTextManagerの呼び出し
            TimeManager();//TimeManagerの呼び出し
            //playerが非表示の場合
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//timeテキスト非表示
            }
        }

        //gamescene5だった場合
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            TipsTextManager();//TipsTextManagerの呼び出し
            TimeManager();//TimeManagerの呼び出し
            //playerが非表示の場合
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//timeテキスト非表示
            }
            //enemyが非表示の場合
            if (!enemy_obj.activeInHierarchy && timeText.text == "0秒")
            {
                clearText.gameObject.SetActive(true);//ClearText表示
                Time.timeScale = 0.0f;
            }
        }
    }

    //TipsTextManager処理
    public void TipsTextManager()
    {
        //Fキーが押された場合
        if (Input.GetKeyDown(KeyCode.F))
        {
            //UItextが非表示の場合
            if (tipsText.activeSelf)
            {
                tipsText.SetActive(false);
                Time.timeScale = 1.0f;
                //Debug.Log("ゲーム再生");
            }
            else
            {
                tipsText.SetActive(true);
                Time.timeScale = 0.0f;
                //Debug.Log("ゲーム停止");
            }
        }
    }

    //TimeManager処理　gamescene2
    public void TimeManager()
    {
        //tipsTextが表示の場合
        if (tipsText.activeSelf) timeText.gameObject.SetActive(false);
        //tipsTextが非表示の場合
        else
        {
            //カウントが0になった場合
            if (timeText.text == "0秒")
            {
                //playerが生き残っている場合
                if (player_obj.activeSelf && !flg)
                {
                    flg = true;
                    timeText.gameObject.SetActive(false);
                    clearText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
            else
            {
                //playerのHpが0になった場合
                if (player.hptext.text == "HP　0/100" && !flg)
                {
                    flg = true;
                    player.healthbar.gameObject.SetActive(false);
                    player.hptext.gameObject.SetActive(false);
                    gameOverText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
                if (!flg)
                {
                    countdown -= Time.timeScale / 60;//時間のカウントダウン(カウントダウンが早かったため÷60した)
                    int cntdown = (int)countdown;
                    timeText.text = cntdown.ToString() + "秒";
                    timeText.gameObject.SetActive(true);
                }
            }

        }
    }

    //GameOverManager処理
    public void GameOverManager()
    {
        gameOverText.gameObject.SetActive(true);//gameoverText表示
        MissionText.gameObject.SetActive(false);//Missionテキスト非表示
    }

    //TipsTextSeting処理
    public void TipsTextSeting()
    {
        var tipsTextTransform = tipsText.transform;//tipsTextのTransform取得
        var children = new GameObject[tipsTextTransform.childCount];//子オブジェクトを格納する配列作成

        //子オブジェクトを配列に格納
        for(var i = 0; i< children.Length; ++i)
            //Transformからゲームオブジェクトを取得して格納
            children[i] = tipsTextTransform.GetChild(i).gameObject;

        //全stage共通
        Text UItext = children[0].gameObject.GetComponent<Text>();
        UItext.text = "操作方法\n移動キー　ADWS ←→↑↓";

        //gamescene1だった場合
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "【ミッション】\n" +
                "黄色のアイテムでパワーアップ!\n" +
                "敵よりプレイヤーの方が強ければ青色に変化!\n" +
                "敵を倒せばクリア!";
        }
        //gamescene2だった場合
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "【ミッション】\n" +
                "制限時間が表示される!\n" +
                "最後まで生き残ろう!";
        }


        //gamescene5だった場合
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "【ミッション】\n" +
                "敵を全滅させよう!\n" +
                "最後まで生き残ろう!";
        }

        //全stage共通
        Text Ftext = children[2].gameObject.GetComponent<Text>();
        Ftext.text = "Fキーで閉じる";
    }

    //MissionTextSeting処理
    public void MissionTextSeting()
    {
        //gamescene1だった場合
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            if (player.power < enemy.power)
                MissionText.text = "アイテムを拾ってパワーアップ!";
            else
                MissionText.text = "突進して敵を倒そう!";
        }
        //gamescene2だった場合
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            MissionText.text = "最後まで生き残ろう!";
        }


        //gamescene5だった場合
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            MissionText.text = "敵を倒し、最後まで生き残ろう!";
        }
    }

    //SceneChange用
    public void SceneChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("GameScene1");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("GameScene2");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SceneManager.LoadScene("GameScene5");
    }
}