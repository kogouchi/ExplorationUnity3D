using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeAnimationController : MonoBehaviour
{
    private float angleY;//��]�p�x
    private Vector3 mytrQ;//Rotation�擾

    // Start is called before the first frame update
    void Start()
    {
        angleY = 10.0f;//�����l
    }

    // Update is called once per frame
    void Update()
    {
        //Y���ɉ�]������
        transform.Rotate(0, angleY * Time.deltaTime, 0);
    }
}
