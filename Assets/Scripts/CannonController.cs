using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//��C������]����
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    public Vector3 rot;//rotation�擾
    public float minAngles = -25.0f, maxAngles = 25.0f;//�p�x�͈�

    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;//������
    }

    // Update is called once per frame
    void Update()
    {
        rot = gameObject.transform.localEulerAngles;//���݂�rotation�擾
        //�p�x�̐���
        if (player.flg)
        {
            if(minAngles < rot.y || rot.y < maxAngles)
                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }
    }
}
