using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs‚ğQÆ
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
        //GravityAttractor.cs‚ÌAttractŠÖ”ˆ—
        attractor.Attract(mytransform, rb);//transform‚Ærigidbody‚Ìî•ñ‚ğ“n‚·
    }
}
