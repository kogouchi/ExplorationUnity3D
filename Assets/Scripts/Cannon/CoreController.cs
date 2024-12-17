using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdata()
    {
        RaycastHit hit;

        //レイキャストの可視化
        Debug.DrawRay(gameObject.transform.position, Vector3.up * 6, Color.blue, 10.0f);

    }
}
