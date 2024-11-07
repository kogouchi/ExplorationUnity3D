using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public GameObject enemy;//enemmy取得
    public Material[] material;//マテリアルの取得
    public Slider healthbar;//Sliderバー取得
    public Text hptext;//textの取得
    public Text damegetext;//damegetext取得
    public Text powertext;//powertext取得
    private Rigidbody rb;//Rigidbody取得
    private Transform mytransform;//Transform取得

    public int power = 1;//power(Item獲得時の個数)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//移動速度
    private Vector3 movedir;//移動キーに使用
    private Vector3 scale;//scale変更時に使用


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
    }

    //移動処理
    void FixedUpdate()
    {
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる
        //※スケールと位置座標に影響されない
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //移動+重力処理
    public void Move()
    {
        //移動処理
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ←→
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ↑↓ .normalizedでベクトルの正規化
        //重力処理
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    //HP処理
    public void HP()
    {
        healthbar.value = hp;//バーのvalueをhpとする
        hptext.text = "HP　" + hp + "/100";//textの表示
    }

    //MaterialSetting処理
    public void MaterialSetting()
    {
        power++;
        //Powerの可視化
        powertext.text = "Power " + power;//EnemyPowerText表示更新
        //マテリアルの変更
        if (this.transform.localScale.x > enemy.transform.localScale.x)
        {
            enemy.GetComponent<Renderer>().material = material[0];
            gameObject.GetComponent<Renderer>().material = material[1];
            //Debug.Log("マテリアル変更");
        }
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        if (collision.gameObject.tag == "Item") ItemCollision();
        //Enemyの接触処理
        if (collision.gameObject.tag == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                hp -= 1.0f;
                if(hp >= 0.0f) damegetext.gameObject.SetActive(true);//damageテキストの表示
                if (hp == 0)
                {
                    hptext.gameObject.SetActive(false);//hpテキストの削除
                    healthbar.gameObject.SetActive(false);//hpバーの削除
                }
            }
        }
    }

    //ITEM取得時のPlayerScaleの変更＋制限処理
    public void ItemCollision()
    {
        scale = transform.localScale;//現在のスケールを取得
        if (scale.x <= 1.0f)
        {
            scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
            transform.localScale = scale;//スケールの反映
        }
    }

    //オブジェクト同士が離れた場合
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")　damegetext.gameObject.SetActive(false);//damageテキストの非表示
    }
}
