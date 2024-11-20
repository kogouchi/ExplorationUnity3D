using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//‘å–CŒü‚«‰ñ“]ˆ—
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerControllerQÆ
    public Vector3 rot;//rotationæ“¾
    public float minAngles = -25.0f, maxAngles = 25.0f;//Šp“x”ÍˆÍ

    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;//‰Šú‰»
    }

    // Update is called once per frame
    void Update()
    {
        rot = gameObject.transform.localEulerAngles;//Œ»İ‚Ìrotationæ“¾
        //Šp“x‚Ì§Œä
        if (player.flg)
        {
            if(minAngles < rot.y || rot.y < maxAngles)
                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }
    }
}
