using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

/// <summary>
/// 各ミッションの処理
/// </summary>
public class MissionManager : MonoBehaviour
{
    public Text scoretext;//textの取得
    public Text hptext;//textの取得
    public Slider healthbar;//Sliderバーの取得
    public float currenthp = 100.0f;//現在のhp
    public float distance = 1.0f;//オブジェクト検出可能な距離
    public GameObject[] item;//itemの取得
    public GameObject[] enemy;//enemmyの取得
    private int cnt = 0, maxcnt = 7;//スコアカウント、スコアの最大値

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (cnt == 0) scoretext.text = "アイテムを集めよう!";
            else scoretext.text = "" + cnt + "/" + maxcnt;//textの表示内容
            if (cnt == maxcnt) scoretext.text = "ミッションクリア!";
        }

        RAY();//RAY処理
        HP();//HP処理
    }

    //RAY処理
    public void RAY()
    {
        Vector3 raystartpos = transform.position;//Rayはプレイヤーの位置から飛ばす
        Vector3 raydirection = transform.forward.normalized;//Rayはプレイヤーが向いている方向に飛ばす

        RaycastHit raycastHit;//Hitしたオブジェクト格納用

        //スペースキーが押された場合
        if (Input.GetKey(KeyCode.Space))
        {
            var isHit = Physics.Raycast(raystartpos, raydirection, out raycastHit, distance);//Rayの発射

            Debug.DrawRay(raystartpos, raydirection * distance, Color.red);
            //Debug.DrawRay(Vector3　start(ray開始位置), Vector3 dir(rayの方向と長さ), Color color(ラインの色));

            if (isHit)
            {
                //LogにHitしたオブジェクト名を出力
                Debug.Log("" + raycastHit.collider.gameObject.name + "を倒した");
                Destroy(raycastHit.collider.gameObject);
            }
        }
    }

    //HP処理
    public void HP()
    {
        healthbar.value = currenthp;//バーのvalueをhpとする
        hptext.text = "HP　" + "" + currenthp + "/100";//textの表示
        if (currenthp == 0)
        {
            hptext.gameObject.SetActive(false);//hpテキストの削除
            healthbar.gameObject.SetActive(false);//hpバーの削除
            Destroy(gameObject);//プレイヤー削除
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
                cnt++;
            }
            if (collision.gameObject.name == "Item (1)")
            {
                Destroy(item[1]);
                cnt++;
            }
            if (collision.gameObject.name == "Item (2)")
            {
                Destroy(item[2]);
                cnt++;
            }
            if (collision.gameObject.name == "Item (3)")
            {
                Destroy(item[3]);
                cnt++;
            }
            if (collision.gameObject.name == "Item (4)")
            {
                Destroy(item[4]);
                cnt++;
            }
            if (collision.gameObject.name == "Item (5)")
            {
                Destroy(item[5]);
                cnt++;
            }
            if (collision.gameObject.name == "Item (6)")
            {
                Destroy(item[6]);
                cnt++;
            }

        }
        //Enemyの接触処理
        if (collision.gameObject.name == "Enemy") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (1)") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (2)") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (3)") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (4)") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (5)") currenthp -= 1.0f;
        if (collision.gameObject.name == "Enemy (6)") currenthp -= 1.0f;

    }
}
