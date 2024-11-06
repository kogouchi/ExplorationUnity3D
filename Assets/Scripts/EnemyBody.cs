using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//アイテム接触判定
public class EnemyBody : MonoBehaviour
{
    public GameObject[] items;//itemオブジェクト取得

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        //アイテムが当たった場合
        if (collision.gameObject.name == "Item")     items[0].SetActive(false);
        if (collision.gameObject.name == "Item (1)") items[1].SetActive(false);
        if (collision.gameObject.name == "Item (2)") items[2].SetActive(false);
        if (collision.gameObject.name == "Item (3)") items[3].SetActive(false);
        if (collision.gameObject.name == "Item (4)") items[4].SetActive(false);
        if (collision.gameObject.name == "Item (5)") items[5].SetActive(false);
        if (collision.gameObject.name == "Item (6)") items[6].SetActive(false);
    }
}