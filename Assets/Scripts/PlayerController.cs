using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public Text missiontext;//textの取得
    public Text hptext;//textの取得
    public Text cleartext;//cleartextの取得
    public Text gameovertext;//gameovertextの取得
    public Text damegetext;//damegetextの取得
    public Slider healthbar;//Sliderバーの取得
    public float currenthp = 100.0f;//現在のhp

    public float movespeed = 15.0f;
    private Vector3 movedir;
    private Rigidbody rb;
    public GameObject[] item;//itemの取得
    public GameObject enemy;//enemmyの取得
    private int itemcnt = 0;//, itemmax = 7;//itemカウント、itemの最大値
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
        TEXT();//TEXT処理
        HP();//HP処理
        movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//カーソルキー ←→
            0,
            Input.GetAxisRaw("Vertical")).normalized;//カーソルキー ↑↓
        //.normalizedでベクトルの正規化
    }

    void FixedUpdate()
    {
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる
        //※スケールと位置座標に影響されない
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //TEXT処理
    public void TEXT()
    {
        if (itemcnt == 0) missiontext.text = "itemを拾ってpower up!";
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
            //gameObject.SetActive(false);//削除ではなくfalse試し
            //Destroy(gameObject);//プレイヤー削除

        }
    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        //Itemの接触処理
        {
            if (collision.gameObject.name == "Item")
            {
                Destroy(item[0]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (1)")
            {
                Destroy(item[1]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (2)")
            {
                Destroy(item[2]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (3)")
            {
                Destroy(item[3]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (4)")
            {
                Destroy(item[4]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (5)")
            {
                Destroy(item[5]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (6)")
            {
                Destroy(item[6]);
                itemcnt++;
                scale = transform.localScale;//現在のスケールを取得
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//スケールの反映
                //Debug.Log($"スケール変更 x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }

        }
        //Enemyの接触処理
        if (collision.gameObject.name == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                currenthp -= 1.0f;
                damegetext.gameObject.SetActive(true);//damageテキストの表示
                //Debug.Log("エネミーの方が強い");
            }
            else
            {
                Destroy(enemy);//敵の削除
                cleartext.gameObject.SetActive(true);//Clearテキストの表示
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
