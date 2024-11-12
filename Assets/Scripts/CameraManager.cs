using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用

//MainCameraにCameraManagerをアタッチ+TipsTextを追加
//TipsTextのアクティブ、非アクティブ化の処理
//GameOverTextの表示、ClearTextの表示
public class CameraManager : MonoBehaviour
{
    public GameObject player;//player取得
    public GameObject enemy;//enemmy取得
    public GameObject tipsText;//TipsTextの取得
    public Text MissionText;//missiontext取得
    public Text clearText;//cleartext取得
    public Text gameOverText;//gameovertext取得

    #region 参考サイト
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tipsText.SetActive(true);//Tipsの表示
        Time.timeScale = 0.0f;//ゲーム停止
    }

    // Update is called once per frame
    void Update()
    {
        //Player表示している場合
        //if(player.activeInHierarchy)
        //{
        //    transform.position = new Vector3(player.transform.position.x,
        //        player.transform.position.y,
        //        player.transform.position.z);
        //}

        //gamescene1だった場合
        if(SceneManager.GetActiveScene().name == "GameScene1")
        {
            MissionText.text = "アイテムを拾ってパワーアップ!";
            TipsTextManager();//TipsTextManagerの呼び出し
            //playerが非表示の場合
            if (!player.activeInHierarchy)
            {
                gameOverText.gameObject.SetActive(true);//gameoverText表示
                MissionText.gameObject.SetActive(false);//Missionテキスト非表示
            }
            //enemyが非表示の場合
            if (!enemy.activeInHierarchy) clearText.gameObject.SetActive(true);//ClearText表示
        }
        //gamescene2だった場合
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            MissionText.text = "生き延びよう!";
        }
        //gamescene3だった場合
        //if (SceneManager.GetActiveScene().name == "GameScene3")
        //{
        //
        //}
    }

    //TipsTextManager処理
    public void TipsTextManager()
    {
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
}