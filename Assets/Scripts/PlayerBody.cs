using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//HP�̕\���Ŏg�p+t�e�L�X�g�\���Ŏg�p

/// <summary>
/// Unity��ł��邱�� Player
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class PlayerBody : MonoBehaviour
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
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }
}
