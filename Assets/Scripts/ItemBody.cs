using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
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
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }
}
