using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeAnimationController : MonoBehaviour
{
    private float angleY;//‰ñ“]Šp“x
    private Vector3 mytrQ;//Rotationæ“¾

    // Start is called before the first frame update
    void Start()
    {
        angleY = 10.0f;//‰Šú’l
    }

    // Update is called once per frame
    void Update()
    {
        //Y²‚É‰ñ“]‚³‚¹‚é
        transform.Rotate(0, angleY * Time.deltaTime, 0);
    }
}
