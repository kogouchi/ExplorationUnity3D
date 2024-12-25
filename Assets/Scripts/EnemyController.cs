using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用
using UnityEngine.SceneManagement;//シーンで使用

//player追従処理+player接触処理＋item接触処理
public class EnemyController : MonoBehaviour
{
    //public Text ePower;
    public GravityAttractor attractor;//「GravityAttractor.cs」C#を参照
    public PlayerController player;//「PlayerController.cs」C#を参照
    public Transform playerpos;//playerのTransform取得
    //public Text EnemyPowerText;//EnemyPowerText取得
    public Text damegetext;//damegetext取得
    private Transform mytransform;//EnemyのTransform取得
    private Rigidbody rb;//Rigidbody取得
    public Material[] material;//マテリアルの取得
    public GameObject particleEffect;//死んだ時のエフェクト取得
    public MeshRenderer mr;//MeshRenderer取得
    private SphereCollider col;//SphereCollider取得
    public GameObject Leaf;//葉っぱ取得

    public int power = 3;//power(Item獲得時の個数)
    public float movespeed = 2.0f;//移動スピード
    private bool targetflag = true;//target(playerのこと)
    public float displayDelay = 0.1f;//表示までの時間
    private bool activeflg = true;//コルーチンを繰り返さないためのフラグ
    public bool effectflg = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody取得
        mr = GetComponent<MeshRenderer>();//MeshRenderer取得
        col = GetComponent<SphereCollider>();//Collider取得
        mytransform = transform;//位置座標の取得
        //int rnd = Random.Range(0, 2);
        //if (rnd == 0) gameObject.SetActive(false);
        //if (rnd == 1) gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Powerの可視化
        //EnemyPowerText.text = "Power " + power;//EnemyPowerText表示更新
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    void FixedUpdate()
    {
        TargetMove();//追従処理
        MaterialSetting();//Material変更処理
        //gamescene5だった場合
        //if (SceneManager.GetActiveScene().name == "GameScene1")
        //    GameStage();//Stage5の場合
    }

    //追従処理
    public void TargetMove()
    {
        //追従開始状態の場合
        if (targetflag == true)
        {
            //playerに追従させる処理            
            mytransform.position = Vector3.Lerp(mytransform.position, playerpos.position, movespeed * Time.deltaTime);
        }
    }

    //MaterialSetting処理
    public void MaterialSetting()
    {
        //powerがplayerの方が大きい場合
        if(power < player.power)
        {
            //Materialを変更
            player.GetComponent<Renderer>().material = material[0];
            gameObject.GetComponent<Renderer>().material = material[1];
        }
        else
        {
            //Materialを元に戻す
            gameObject.GetComponent<Renderer>().material = material[0];
            player.GetComponent<Renderer>().material = material[1];
        }
    }

    //gamescene5の場合
    public void GameStage()
    {
        if (!gameObject && activeflg == false)
            StartCoroutine(EnemyActive());//コルーチン開始
    }

    //enemy非表示の場合
    public IEnumerator EnemyActive()
    {
        yield return new WaitForSeconds(1.0f);//displayDelay分待つ
        gameObject.SetActive(false);//enemy削除
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (power < player.power)
            {
                player.moveflg = true;//Player移動不可設定
                damegetext.gameObject.SetActive(false);//damage非表示
                mr.enabled = false;//モデルの非表示
                Leaf.gameObject.SetActive(false);//非表示
                //エフェクトは1度のみ再生
                if (effectflg == false)
                {
                    Instantiate(particleEffect, transform.position, transform.rotation);//Effect再生
                    effectflg = true;
                }
                targetflag = false;//プレイヤーへの追従を無くす
                StartCoroutine(EnemyActive());//コルーチン開始
                //particleEffect.Play();//エフェクト再生                
            }
            else
            {
                rb.isKinematic = true;//物体の動作停止
                targetflag = false;//追従停止
                if(player.hp > 0.0f) damegetext.gameObject.SetActive(true);//damage表示
            }
        }
        if (collision.gameObject.tag == "Item") power++;
    }

    //オブジェクト同士が離れた場合
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damegetext.gameObject.SetActive(false);//damage非表示
            rb.isKinematic = false;//物体の動作再生
            targetflag = true;//追従開始
        }
    }
}
