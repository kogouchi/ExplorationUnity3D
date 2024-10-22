using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Transform player;//playerの取得
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public float movespeed = 0.5f;
    Transform mytransform;
    private Rigidbody rb;
    private bool trigger = false;

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
        if(trigger == false)
            //playerに追従させる処理
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //オブジェクト同士が接触した時
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = true;
    }

    //オブジェクト同士が離れた場合
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = false;
    }
}