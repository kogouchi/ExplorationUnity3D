using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainCameraにCameraManagerをアタッチ+TipsTextを追加
//TipsTextのアクティブ、非アクティブ化の処理
public class CameraManager : MonoBehaviour
{
    public GameObject tipsText;//TipsTextの取得

    #region 参考サイト
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tipsText.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TipsTextManager();//TipsTextManagerの呼び出し

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