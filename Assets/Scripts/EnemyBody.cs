using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//Enemyオブジェクト本体
public class EnemyBody : MonoBehaviour
{
    public Transform player;//playerのTransform取得
    public Transform mytransform;//Transform取得
    public GravityAttractor attractor;//「GravityAttractor.cs」C#を参照
    public GameObject[] item;//itemオブジェクト取得
    private Rigidbody rb;//Rigidbody取得

    public float movespeed = 0.8f;//移動スピード
    private bool targetflag = false;//target(player)のこと

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody取得
        mytransform = transform;//位置座標の取得
    }

    // Update is called once per frame
    void Update()
    {
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
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = true;//物体の動作停止
            targetflag = true;
        }
        //アイテムが当たった場合
        if (collision.gameObject.name == "Item")     item[0].SetActive(false);
        if (collision.gameObject.name == "Item (1)") item[1].SetActive(false);
        if (collision.gameObject.name == "Item (2)") item[2].SetActive(false);
        if (collision.gameObject.name == "Item (3)") item[3].SetActive(false);
        if (collision.gameObject.name == "Item (4)") item[4].SetActive(false);
        if (collision.gameObject.name == "Item (5)") item[5].SetActive(false);
        if (collision.gameObject.name == "Item (6)") item[6].SetActive(false);
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