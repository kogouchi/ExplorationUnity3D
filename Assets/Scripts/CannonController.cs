using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//大砲向き回転処理
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerController参照
    public Vector3 rot;//rotation取得
    public float minAngles = -25.0f, maxAngles = 25.0f;//角度範囲

    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        rot = gameObject.transform.localEulerAngles;//現在のrotation取得
        //角度の制御
        if (player.flg)
        {
            if(minAngles < rot.y || rot.y < maxAngles)
                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }
    }
}
