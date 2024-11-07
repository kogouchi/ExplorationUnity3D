using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Itemの削除＋Item復活処理
public class ItemBody : MonoBehaviour
{
    private MeshRenderer mr;//MeshRenderer取得
    private SphereCollider col;//SphereCollider取得

    public float displayDelay = 10.0f;//表示までの時間
    private bool activeflg = true;//コルーチンを繰り返さないためのフラグ

    #region 参考サイト
    // メッシュの取得と非表示の書き方
    // https://futabazemi.net/unity/meshrenderer-change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();//MeshRenderer取得
        col = GetComponent<SphereCollider>();//Collider取得
    }

    // Update is called once per frame
    void Update()
    {
        //Itemが非表示かつフラグがfalseである場合
        if (activeflg == false) StartCoroutine(ItemActive());//コルーチン開始
    }

    public IEnumerator ItemActive()
    {
        activeflg = true;//activeflgをtrue
        yield return new WaitForSeconds(displayDelay);//displayDelay分待つ
        mr.enabled = true;//Mesh非表示
        col.enabled = true;//Collider非表示
    }

    //オブジェクト同士が接触した時
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            activeflg = false;//activeflgをfalse
            mr.enabled = false;//Mesh非表示
            col.enabled = false;//Collider非表示
        }
    }
}
