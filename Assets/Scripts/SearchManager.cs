using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//Enemyアイテム拾う範囲
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemyの取得
    public bool searchflag = false;//探索フラグ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit[] hits = Physics.SphereCastAll(
       transform.position,
       3.0f,
       Vector3.forward);

        //Debug.Log($"検出されたコライダー数:{this.Length}");

        //現在の検知したオブジェクトの表記
        //if(searchflag)
        foreach (var hit in hits)
        {
            //Debug.Log($"検出されたobj{hit.collider.name}");
            if(hit.collider.tag == "Item")
            {
                //enemyがitemへ追従する
                enemy.transform.position =
                        Vector3.MoveTowards(
                enemy.transform.position, 
                hit.transform.position,
                5.0f * Time.deltaTime );
                Debug.Log("itemゲット");
            }
        }
    }
}
