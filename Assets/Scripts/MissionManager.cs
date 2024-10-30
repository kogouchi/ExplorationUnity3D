using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

/// <summary>
/// 各ミッションの処理
/// </summary>
public class MissionManager : MonoBehaviour
{
    public Text missiontext;//textの取得
    public Text hptext;//textの取得
    public Slider healthbar;//Sliderバーの取得
    public float currenthp = 100.0f;//現在のhp
    public float distance = 1.0f;//オブジェクト検出可能な距離
    public GameObject[] item;//itemの取得
    public GameObject[] enemy;//enemmyの取得
    public int killcnt = 0;//敵のカウント
    private int itemcnt = 0, itemmax = 7;//itemカウント、itemの最大値
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;
        scale = new Vector3(0.5f, 0.5f, 0.5f);//初期位置追加
        transform.localScale = scale;//スケールの反映
    }

    // Update is called once per frame
    void Update()
    {
        TEXT();//TEXT処理
        RAY();//RAY処理→敵を倒すミッションの場合
        HP();//HP処理→常に表示させる
    }

    //TEXT処理
    public void TEXT()
    {
        if (itemcnt == 0) missiontext.text = "ミッションテキスト";
        else missiontext.text = "" + itemcnt + "/" + itemmax;//textの表示内容
        if (itemcnt == itemmax) missiontext.text = "ミッションクリア!";
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

            if (isHit && killcnt != 6)
            {
                //LogにHitしたオブジェクト名を出力
                Debug.Log("" + raycastHit.collider.gameObject.name + "を倒した");
                Destroy(raycastHit.collider.gameObject);
                killcnt++;
                enemy[killcnt].SetActive(true);//enemy生成
            }
        }
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
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (1)")
            {
                Destroy(item[1]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (2)")
            {
                Destroy(item[2]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (3)")
            {
                Destroy(item[3]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (4)")
            {
                Destroy(item[4]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (5)")
            {
                Destroy(item[5]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
            }
            if (collision.gameObject.name == "Item (6)")
            {
                Destroy(item[6]);
                itemcnt++;
                scale = transform.localScale;
                scale.x += 0.1f;
                scale.y += 0.1f;
                scale.z += 0.1f;
                transform.localScale = scale;
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
