using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーコントローラー処理
public class PlayerController : MonoBehaviour
{
    public float movespeed = 15.0f;
    private Vector3 movedir;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//カーソルキー ←→
            0,
            Input.GetAxisRaw("Vertical")).normalized;//カーソルキー ↑↓
        //.normalizedでベクトルの正規化
    }

    void FixedUpdate()
    {
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる
        //※スケールと位置座標に影響されない
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
