using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//アイテム接触処理(Raycastを使用)
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemyの取得
    public float ray = 2.5f;//検知範囲
    public float movepeed = 5.0f;//移動スピード

    // Start is called before the first frame update
    void Start()
    {
        //位置設定(enemy本体の位置)
        transform.position = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //位置情報の更新（常にenemy本体の位置）
        transform.position = enemy.transform.position;

        //RaycastHit使用
        RaycastHit[] hits = Physics.SphereCastAll(
        transform.position,
        ray,
        Vector3.forward);

        //現在の検知したオブジェクトの表記
        foreach (var hit in hits)
        {
            //Debug.Log($"検出されたobj{hit.collider.name}");
            if(hit.collider.tag == "Item")
            {
                //enemyがitemへ追従する
                enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position, //enemy位置座標
                hit.transform.position,//検知したItemタグの位置座標
                movepeed * Time.deltaTime);
                //Debug.Log("itemゲット");
            }
        }
    }
}
