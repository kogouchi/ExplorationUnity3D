using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//player追従処理+player接触処理＋item接触処理
public class EnemyController : MonoBehaviour
{
    public GravityAttractor attractor;//「GravityAttractor.cs」C#を参照
    public Transform player;//playerのTransform取得
    public Text EnemyPowerText;//EnemyPowerText取得
    private Transform mytransform;//EnemyのTransform取得
    private Rigidbody rb;//Rigidbody取得

    public int power = 1;//power(Item獲得時の個数)
    public float movespeed = 1.0f;//移動スピード
    private bool targetflag = true;//target(playerのこと)
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody取得
        mytransform = transform;//位置座標の取得
    }

    // Update is called once per frame
    void Update()
    {
        //Powerの可視化
        EnemyPowerText.text = "Power " + power;//EnemyPowerText表示更新
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    void FixedUpdate()
    {
        TargetMove();//追従処理
    }

    //追従処理
    void TargetMove()
    {
        //追従開始状態の場合
        if (targetflag == true)
            //playerに追従させる処理
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = true;//物体の動作停止
            targetflag = false;//追従停止
            //gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Item") power++;
    }

    //オブジェクト同士が離れた場合
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = false;//物体の動作再生
            targetflag = true;//追従開始
        }
    }
}
