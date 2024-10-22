using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//HPの表示でUIをを使用

/// <summary>
/// Unity上ですること Player
/// 【Rigidbody】 Use Gravity チェックオフ
/// 【Rigidbody】 Constraints Freeze Rotation チェックオン
/// </summary>
public class PlayerBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public Slider healthBar;//hpバーの取得
    public float hp = 10.0f;//最大hp
    private Transform mytransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            //GravityAttractor.csのAttract関数処理
            attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す

        healthBar.value = hp;//バーのvalueをhpとする
        if (hp == 0) Destroy(gameObject);//プレイヤー削除
    }

    //オブジェクト同士が接触した時
    private void OnCollisionEnter(Collision collision)
    {
        //エネミーに当たった場合
        if (collision.gameObject.name == "Enemy") hp -= 1.0f;
    }
}
