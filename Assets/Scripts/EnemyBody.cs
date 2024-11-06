using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//アイテム接触判定
public class EnemyBody : MonoBehaviour
{
    public GameObject[] items;//itemオブジェクト取得
    public Text EnemyPowerText;//EnemyPowerText取得
    private int power = 1;//power(Item獲得時の個数)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyPowerText.text = "Power " + power;//EnemyPowerText表示更新
        //Enemyが非表示になった場合
        if(!gameObject) EnemyPowerText.gameObject.SetActive(false);//EnemyPowerText非表示
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //アイテムが当たった場合
        {
            if (collision.gameObject.name == "Item")
            {
                items[0].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (1)")
            {
                items[1].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (2)")
            {
                items[2].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (3)")
            {
                items[3].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (4)")
            {
                items[4].SetActive(false);
                power++;
            }
        }
    }
}