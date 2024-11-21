using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//大砲向き回転処理
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerController参照
    public SubCameraController scc;//SubCameraController参照
    public GameObject corePos;//corePos取得
    public Vector3 rot;//rotation取得
    private float speed = 300f;//大砲弾の速さ
    public float minAngles = -25.0f, maxAngles = 25.0f;//角度範囲

    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        //Spaceキーが押された時
        if (Input.GetKeyDown(KeyCode.Space) && scc.flg == true)
        {
            //coreをインスタンス化して発射
            GameObject createCore = Instantiate(corePos) as GameObject;
            createCore.GetComponent<MeshRenderer>().enabled = true;
            createCore.transform.position = corePos.transform.position;

            //発射ベクトル
            Vector3 force;
            //発射の向きと速度を決定
            force = corePos.transform.forward * speed;
            //rigidbodyに力を加えて発射
            createCore.GetComponent<Rigidbody>().AddForce(force);
            Destroy(createCore, 10.0f);
        }

        rot = gameObject.transform.localEulerAngles;//現在のrotation取得
        //角度の制御
        if (player.flg)
        {
            if(minAngles < rot.y || rot.y < maxAngles)
                transform.Rotate(
                    Input.GetAxis("Vertical"), 
                    Input.GetAxis("Horizontal"), 
                    0);
        }
    }
}
