using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemyアイテム拾う範囲
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemyの取得
    public GameObject[] item;//itemの取得
    private string objname;//Object名取得

    // Start is called before the first frame update
    void Start()
    {
        transform.position = enemy.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //objname = collision.gameObject.name;

        //アイテムが当たった場合
        if (collision.gameObject.name == "Item")
        {
            Destroy(item[0]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (1)")
        {
            Destroy(item[1]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (2)")
        {
            Destroy(item[2]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (3)")
        {
            Destroy(item[3]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (4)")
        {
            Destroy(item[4]);
            Debug.Log("アイテムに当たった");
        }
        if (collision.gameObject.name == "Item (5)")
        {
            Destroy(item[5]);
            Debug.Log("アイテムに当たった");
        }       
        if (collision.gameObject.name == "Item (6)")
        {
            Destroy(item[6]);
            Debug.Log("アイテムに当たった");
        }
    }
}
