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
    public Slider healthBar;//Sliderバーの取得
    public float hp = 100.0f;//最大hp
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
        if (cnt == 0) scoretext.text = "アイテムを集めよう!";
        else scoretext.text = "" + cnt + "/" + maxcnt;//textの表示内容
        if (cnt == maxcnt) scoretext.text = "ミッションクリア!";

        healthBar.value = hp;//バーのvalueをhpとする
        hptext.text = "HP　" + "" + hp + "/100";//textの表示
        if (hp == 0)
        {
            hptext.gameObject.SetActive(false);//hpテキストの削除
            healthBar.gameObject.SetActive(false);//hpバーの削除
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
        if (collision.gameObject.name == "Enemy") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (1)") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (2)") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (3)") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (4)") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (5)") hp -= 1.0f;
        if (collision.gameObject.name == "Enemy (6)") hp -= 1.0f;

    }
}
