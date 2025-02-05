using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public EnemyController enemy;

    public float movespeed = 10.0f;//移動速度
    public bool groundflg = false;//地面flg
    public bool moveflg = false;

    private Rigidbody myrb;//Rigidbody取得
    private Transform mytransform;//Transform取得
    private Vector3 movedir;//移動キーに使用

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();//Rigidbody取得
        mytransform = transform;//Transform取得
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();//移動処理
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    public void Move()
    {
        //移動処理
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS
        //normalizedでベクトルの正規化(絶対しないといけないらしい)

        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, myrb);//自身のtransformとrigidbodyの情報を渡す

        //重力処理
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる
        //※スケールと位置座標に影響されない
        myrb.MovePosition(myrb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
