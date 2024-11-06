using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public GameObject enemy;//enemmy取得
    public Text hptext;//textの取得

    public Material[] material;//マテリアルの取得
    public Text missiontext;//textの取得
    public Text cleartext;//cleartext取得
    public Text gameovertext;//gameovertext取得
    public Text damegetext;//damegetext取得
    //public Text leveltext;//leveltext取得
    public Slider healthbar;//Sliderバー取得
    public float currenthp = 100.0f;//現在のhp

    public float movespeed = 10.0f;
    private Vector3 movedir;
    private Rigidbody rb;
    public GameObject[] items;//items取得
    //private int itemcnt = 0;, itemmax = 7;//itemカウント、itemの最大値
    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;//スケールの取得
        scale = new Vector3(0.5f, 0.5f, 0.5f);//スケール初期設定
        transform.localScale = scale;//スケールの反映
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ////マテリアルの変更
        //if(enemy == true)
        //if(this.transform.localScale.x > enemy.transform.localScale.x)
        //{
        //    enemy.GetComponent<Renderer>().material = material[0];
        //    gameObject.GetComponent<Renderer>().material = material[1];
        //    //Debug.Log("マテリアル変更");
        //}

        TextManager();//TEXT処理
        HP();//HP処理
        KeyMove();//キー処理
    }

    //移動処理
    void FixedUpdate()
    {
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる
        //※スケールと位置座標に影響されない
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //TEXT処理
    public void TextManager()
    {
        //leveltext.text = "level " + itemcnt;//levelの表示
        if (enemy == true)
            if (transform.localScale.x < enemy.transform.localScale.x)
                missiontext.text = "Itemを拾ってパワーアップ!";
            else missiontext.text = "敵を攻撃しよう";
        //else missiontext.text = "" + itemcnt + "/" + itemmax;//textの表示内容
        //if (itemcnt == itemmax) missiontext.text = "ミッションクリア!";
    }

    //HP処理
    public void HP()
    {
        healthbar.value = currenthp;//バーのvalueをhpとする
        hptext.text = "HP　" + currenthp + "/100";//textの表示
        if (currenthp == 0)
        {
            hptext.gameObject.SetActive(false);//hpテキストの削除
            healthbar.gameObject.SetActive(false);//hpバーの削除
            gameovertext.gameObject.SetActive(true);//gameoverテキスト表示
            gameObject.SetActive(false);//削除ではなくfalse試し
            //Destroy(gameObject);//プレイヤー削除

        }
    }

    //キー処理
    public void KeyMove()
    {
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ←→
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ↑↓
        //.normalizedでベクトルの正規化
    }

    //ITEM取得時のPlayerScaleの変更処理
    public void ItemCollision()
    {
        //Debug.Log("Itemに当たった");
        //itemcnt++;
        scale = transform.localScale;//現在のスケールを取得
        if(scale.x <= 1.0f)
        {
            scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
            transform.localScale = scale;//スケールの反映
            //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
        }
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        {
            if (collision.gameObject.name == "Item")
            {
                items[0].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (1)")
            {
                items[1].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (2)")
            {
                items[2].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (3)")
            {
                items[3].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (4)")
            {
                items[4].SetActive(false);
                ItemCollision();
            }
            //if (collision.gameObject.name == "Item (5)")
            //{
            //    items[5].SetActive(false);
            //    ItemCollision();
            //}
            //if (collision.gameObject.name == "Item (6)")
            //{
            //    items[6].SetActive(false);
            //    ItemCollision();
            //}
        }
        //Enemyの接触処理
        if (collision.gameObject.name == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                currenthp -= 1.0f;
                if(currenthp >= 0.0f)
                    damegetext.gameObject.SetActive(true);//damageテキストの表示
                //Debug.Log("エネミーの方が強い");
            }
            else
            {
                //Destroy(enemy, 0.5f);//敵の削除
                enemy.SetActive(false);//enemyの非表示
                cleartext.gameObject.SetActive(true);//Clearテキストの表示
                //Time.timeScale = 0.0f;
                //Debug.Log("Enemyを倒した");
            }
        }
    }

    //オブジェクト同士が離れた場合
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            damegetext.gameObject.SetActive(false);//damageテキストの非表示
        }
    }
}
