using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public GameObject player;//playerの取得
    public GravityAttractor attractor;//GravityAttractor.csを参照
    private Transform mytransform;
    private Rigidbody rb;

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

        //playerへの追従

    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") Destroy(player);
    }
}