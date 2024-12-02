using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public Slider healthbar;//Sliderバー取得
    public Text hptext;//textの取得
    public Text gameovertext;//gameovertext取得
    public Animation anim = null;//animation再生時使用
    private Rigidbody rb;//Rigidbody取得
    private Transform mytransform;//Transform取得
    public int power = 1;//power(Item獲得時の個数)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//移動速度
    public bool groundflg = false;//地面flg
    private Vector3 movedir;//移動キーに使用

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody取得
        mytransform = transform;//Transform取得
    }

    // Update is called once per frame
    void Update()
    {
        Move();//移動+重力処理
        HP();//HP処理
        Ani();//animation再生
    }

    //移動処理
    void FixedUpdate()
    {
        //進んでいる方向にゆっくりと向く
        {
            //float Ry = transform.localEulerAngles.y;//現在のRotationY軸を取得

            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90度回転させる
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90度回転させる
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90度回転させる
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90度回転させる

            //transform.forward = Vector3.Slerp(transform.forward, movedir, Time.deltaTime * 0.1f);
            //Slerpだとcameraがバグる→コライダーが原因
            //ベクトルの大きさが、0.01以上の時に向きを変える→クォータニオン
            //Vector3 latesPos = transform.position;
            //Vector3 diff = transform.position - latesPos;
            //if (diff.magnitude > 0.01f)
            //{
            //    transform.rotation = Quaternion.LookRotation(diff);
            //}

        }
    }

    //移動+重力処理
    public void Move()
    {
        //移動処理
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ←→
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ↑↓ .normalizedでベクトルの正規化

        //地面の上に立っている場合
        if (groundflg == true)
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
    public void Ani()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {

        }
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        if (collision.gameObject.tag == "Item") power++;
        //Enemyの接触処理
        if (collision.gameObject.tag == "Enemy")
        {
            if (hp == 0)
            {
                hptext.gameObject.SetActive(false);//hpテキスト非表示
                healthbar.gameObject.SetActive(false);//hpバー非表示
                gameovertext.gameObject.SetActive(true);//gameover表示
                Time.timeScale = 0.0f;
            }
            else hp -= 1.0f;
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
