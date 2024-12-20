using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public EnemyController enemy;
    public Slider healthbar;//Sliderバー取得
    public Text hptext;//textの取得
    public Text gameovertext;//gameovertext取得
    public AnimationClip[] animationClips;//アニメーションズ格納
    public Animator anim = null;//animation再生時使用
    private Rigidbody rb;//Rigidbody取得
    private Transform mytransform;//Transform取得
    public int power = 1;//power(Item獲得時の個数)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//移動速度
    public bool groundflg = false;//地面flg
    private Vector3 movedir;//移動キーに使用
    public bool aniflg = false;//animationフラグ
    public bool moveflg = false;
    bool timeflg = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody取得
        anim = GetComponent<Animator>();//animation取得
        mytransform = transform;//Transform取得
    }

    // Update is called once per frame
    void Update()
    {
        HP();//HP処理
        Move();//移動+重力処理
        //Ani();//animation再生
    }

    //移動処理
    void FixedUpdate()
    {
        Debug.Log(power);
    }

    //移動+重力処理
    public void Move()
    {
        if(gameObject.activeSelf && moveflg == false)
        {
            //移動処理
            movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//AD ←→
            0,
            Input.GetAxisRaw("Vertical")).normalized;//WS ↑↓ .normalizedでベクトルの正規化
        }
        //地面の上に立っている場合
        if (groundflg == true && moveflg == false)
        {
            //重力処理
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                //MovePosition()→指定した特定の座標に向かって移動する
                //TransformDirection()→法線や方向のベクトルの向きを変更できる
                //※スケールと位置座標に影響されない
                rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
            }
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
        }
    }

    //HP処理
    public void HP()
    {
        healthbar.value = hp;//バーのvalueをhpとする
        hptext.text = "HP　" + hp + "/100";//textの表示
    }

    //animation再生
    //public void Ani()
    //{
    //    //if(!Input.aniKey) //何も押されていない時
    //    if(aniflg == false)
    //    {
    //        aniflg = true;
    //        //右
    //        if (Input.GetKeyDown(KeyCode.D) == true)
    //        {
    //            anim.CrossFade("RightAnimation", 0.3f);
    //            Debug.Log("右");
    //        }
    //        else anim.SetBool("RightAnimation", false);
    //        //左
    //        if (Input.GetKeyDown(KeyCode.A) == true)
    //        {
    //            anim.SetBool("LeftAnimation", true);
    //            Debug.Log("左");
    //        }
    //        else anim.SetBool("LeftAnimation", false);
    //        //上
    //        if(Input.GetKeyDown(KeyCode.W) == true)
    //        {
    //            anim.SetBool("WalkAnimation", true);
    //            Debug.Log("上");
    //        }
    //        else anim.SetBool("WalkAnimation", false);
    //        //下
    //        if(Input.GetKeyDown(KeyCode.S) == true)
    //        {
    //            anim.SetBool("BackAnimation", true);
    //            Debug.Log("下");
    //        }
    //        else anim.SetBool("BackAnimation", false);
    //    }
    //    else aniflg = false;
    //}

    //オブジェクト同士が接触した時

    public void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        if (collision.gameObject.tag == "Item") power++;
        //Enemyの接触処理
        if (collision.gameObject.tag == "Enemy")
        {
            if (hp <= 0)
            {
                hptext.gameObject.SetActive(false);//hpテキスト非表示
                healthbar.gameObject.SetActive(false);//hpバー非表示
                gameovertext.gameObject.SetActive(true);//gameover表示
                Time.timeScale = 0.0f;
            }
            if(hp != 0 && enemy.power > power)
                 hp -= 1.0f;
        }
        //地面の接触処理
        if (collision.gameObject.tag == "Planet")
        {
            groundflg = true;
            //Debug.Log("地面の上に立っている");
        }
    }

    ////オブジェクト同士が離れた場合
    //public void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Planet")
    //    {
    //        groundflg = false;
    //        Debug.Log("地面から離れたため、重力地面に立たせる");
    //        //GravityAttractor.csのAttract関数処理
    //        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    //    }
    //}
}
