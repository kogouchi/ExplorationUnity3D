using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

//サブカメラが起動している場合の不必要オブジェクトの処理
public class MainCameraController : MonoBehaviour
{
    //格納するもの(フィールド上で動くもの)
    public PlayerController player;
    private Vector3 pos;//位置座標
    private Vector3 trQ;//回転座標

    // Start is called before the first frame update
    void Start()
    {
        //Camera位置座標をPlayerに変更
        pos = player.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
        trQ = player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera位置座標をPlayerに変更
        pos = player.transform.position;
        pos.y = 14.0f;
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
