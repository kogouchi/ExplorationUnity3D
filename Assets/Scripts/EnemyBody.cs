using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public GameObject searchobj;//探索用C#取得
    public SearchManager searchscript;//探索用C#取得
    public Transform player;//playerの取得
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public float movespeed = 0.5f;
    public Transform mytransform;
    private Rigidbody rb;
    private bool targetflag = false;
    private string itemname;
    public GameObject[] item;//itemの取得

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
        searchscript = GetComponent<SearchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //探索用位置座標を敵位置座標に変更
        searchobj.transform.position = mytransform.position;
        //searchscript.objname = itemname;
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    void FixedUpdate()
    {
        if (targetflag == false)
            //playerに追従させる処理
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //オブジェクト同士が接触した時
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = true;//物体の動作停止
            targetflag = true;
        }
        //アイテムが当たった場合
        if (collision.gameObject.name == "Item")
        {
            Destroy(item[0]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (1)")
        {
            Destroy(item[1]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (2)")
        {
            Destroy(item[2]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (3)")
        {
            Destroy(item[3]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (4)")
        {
            Destroy(item[4]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (5)")
        {
            Destroy(item[5]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (6)")
        {
            Destroy(item[6]);
            Debug.Log("アイテムに当たった");
        }

    }

    //オブジェクト同士が離れた場合
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = false;//物体の動作再生
            targetflag = false;
        }
    }
}