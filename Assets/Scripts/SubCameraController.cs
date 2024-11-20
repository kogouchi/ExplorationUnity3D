using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    public PlayerController player;//PlayerController参照
    private GameObject mainCamera;//メインカメラ格納用
    private GameObject subCamera;//サブカメラ格納用
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("SubCamera");
        mainCamera.SetActive(false);//メインカメラ非表示
        subCamera.SetActive(true);//サブカメラ表示
        //subCamera.SetActive(false);//サブカメラ非表示
    }

    // Update is called once per frame
    void Update()
    {
        CameraChange();
    }

    void CameraChange()
    {
        //スペースが押された場合
        if (Input.GetKey("space") || flg == true)
        {
            //サブカメラ表示
            mainCamera.SetActive(false);
            player.flg = true;
            subCamera.SetActive(true);
        }
        else
        {
            //メインカメラ表示
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
            flg = false;
        }
    }

    //オブジェクトが衝突したとき
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player当たる");
            flg = true;
        }
    }
}
