using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity上ですること Player
/// 【Rigidbody】 Use Gravity チェックオフ
/// 【Rigidbody】 Constraints Freeze Rotation チェックオン
/// </summary>
public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public GameObject item;//itemの取得
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item") Destroy(item);
    }
}
