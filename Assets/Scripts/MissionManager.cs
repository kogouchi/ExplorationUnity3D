using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各ミッションの処理
/// </summary>
public class MissionManager : MonoBehaviour
{
    public GameObject[] item;//itemの取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Item")     Destroy(item[0]);
        if (collision.gameObject.name == "Item (1)") Destroy(item[1]);
        if (collision.gameObject.name == "Item (2)") Destroy(item[2]);
        if (collision.gameObject.name == "Item (3)") Destroy(item[3]);
        if (collision.gameObject.name == "Item (4)") Destroy(item[4]);
        if (collision.gameObject.name == "Item (5)") Destroy(item[5]);
    }
}
