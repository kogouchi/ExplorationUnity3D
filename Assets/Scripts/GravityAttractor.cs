using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity上ですること GravityObjct
/// 【Rigidbody】 Use Gravity チェックオフ
/// 【Rigidbody】 Mass 100
/// </summary>
public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10;//加速度の大きさ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //GravityBody.csへ参照させる関数
    public void Attract(Transform body, Rigidbody rb)
    {
        //向かう向きを取得
        Vector3 gravityup = (body.position - transform.position).normalized;//.normalizedでベクトルの正規化
        Vector3 bodyup = body.up;

        //加速度を与える
        rb.AddForce(gravityup * gravity);

        //進行方向を向く回転の計算
        //Quaternion.FromToRotation(開始方向、終了方向)
        Quaternion targetRotation = Quaternion.FromToRotation(
            bodyup, gravityup) * body.rotation;

        //2点間補完→Quaternion.Slerp 2点間を滑らかに移動させるための関数
        //現在のオブジェクトの角度から目標の角度までゆっくりと回転させる
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
