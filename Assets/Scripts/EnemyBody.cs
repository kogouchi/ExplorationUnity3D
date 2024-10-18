using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Transform player_pos;//player位置座標の取得
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public float movespeed = 0.5f;//移動速度
    private Transform mytransform;
    private Rigidbody rb;
    private bool trigger = true;//true 動き続ける false プレイヤーの前にいる(停止状態)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    private void FixedUpdate()
    {
        if (trigger == true)
            mytransform.position = Vector3.Lerp(mytransform.position, player_pos.position, movespeed * Time.deltaTime);//プレイヤーの位置移動
    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = false;
    }

    //オブジェクト同士が離れた時
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = true;
    }
}