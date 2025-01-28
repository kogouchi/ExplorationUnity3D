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

    public int power = 1;//power(Item獲得時の個数)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//移動速度
    public bool groundflg = false;//地面flg
    public bool hpflg = false;//hpフラグ(hpが0以上の時はhp減らすようにするためのフラグ)
    public bool moveflg = false;

    private Rigidbody myrb;//Rigidbody取得
    private Transform mytransform;//Transform取得
    private Vector3 movedir;//移動キーに使用

    #region 参考サイト
    // 球体の上にオブジェクトを歩かせる
    // https://youtube.com/watch?v=gHeQ8Hr92P4&si=MevGvtv3gmaj5lh0
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();//Rigidbody取得
        mytransform = transform;//Transform取得
    }

    // Update is called once per frame
    void Update()
    {
        HP();//HP処理
    }

    void FixedUpdate()
    {
        Move();//移動処理
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    public void Move()
    {
        if(gameObject.activeSelf && moveflg == false)
        {
            //移動処理
            movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//AD
            0,
            Input.GetAxisRaw("Vertical")).normalized;//WS
            //normalizedでベクトルの正規化(絶対しないといけないらしい)
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
                myrb.MovePosition(myrb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
            }
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, myrb);//自身のtransformとrigidbodyの情報を渡す
        }
        //HPが0になった場合
        if (hp <= 0 && hpflg == false)
        {
            //ゲームオーバー処理-------------------------------------------
            //(CameraManagerでも使用するためのちに関数化させる)------------
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, myrb);//自身のtransformとrigidbodyの情報を渡す
            hpflg = true;//hpをこれ以上減らさないようにする
            hptext.gameObject.SetActive(false);//hpテキスト非表示
            healthbar.gameObject.SetActive(false);//hpバー非表示
            gameovertext.gameObject.SetActive(true);//gameover表示
            Time.timeScale = 0.0f;
            //-------------------------------------------------------------
        }
        //クリア時のプレイヤーオブジェクト固定させるための処理
        //現状:Scene3、Scene4はPrefab化したエネミーを格納→それ以外は処理は通る
        if(!enemy.gameObject.activeSelf && hp >= 0)
        {
            //クリア時処理-------------------------------------------------
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, myrb);//自身のtransformとrigidbodyの情報を渡す
        }
    }

    /// <summary>
    /// HP処理
    /// </summary>
    public void HP()
    {
        healthbar.value = hp;//バーのvalueをhpとする
        hptext.text = "HP　" + hp + "/100";//textの表示
    }

    /// <summary>
    /// オブジェクト同士の当たり判定
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        if (collision.gameObject.tag == "Item") power++;
        //Enemyの接触処理
        if (collision.gameObject.tag == "Enemy")
            if (enemy.power > power) hp -= 1.0f;
        //地面の接触処理
        if (collision.gameObject.tag == "Planet")　groundflg = true;
    }
}
