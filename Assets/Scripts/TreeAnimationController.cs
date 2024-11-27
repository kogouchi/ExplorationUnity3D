using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeAnimationController : MonoBehaviour
{
    private float angleY;//回転角度
    private Vector3 mytrQ;//Rotation取得

    // Start is called before the first frame update
    void Start()
    {
        angleY = 10.0f;//初期値
    }

    // Update is called once per frame
    void Update()
    {
        //Y軸に回転させる
        transform.Rotate(0, angleY * Time.deltaTime, 0);
    }
}
