using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    public PlayerController player;//PlayerController参照
    private GameObject mainCamera;//メインカメラ格納用
    private GameObject subCamera;//サブカメラ格納用
    public bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートの設定
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("SubCamera");
        subCamera.SetActive(false);//サブカメラ非表示
    }

    // Update is called once per frame
    void Update()
    {
        CameraChange();
    }

    void CameraChange()
    {
        //プレイヤーとコライダーが当たった場合＋サブカメラ作動
        if (flg == true)
        {
            //サブカメラ表示
            subCamera.SetActive(true);
            mainCamera.SetActive(false);
            //オブジェクト停止
            player.gameObject.SetActive(false);
            player.flg = true;

        }
        //Qキーが押された場合
        if(Input.GetKeyDown(KeyCode.Q) && flg == true)
        {
            Debug.Log("Q push");
            //オブジェクト作動
            player.gameObject.SetActive(true);
            player.flg = false;
            flg = false;
            //メインカメラ表示
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
            //isTriggerオフ
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    //オブジェクトが衝突した時
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")       
           flg = true;
    }

    //オブジェクトが離れた時
    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            //isTriggerオン
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
