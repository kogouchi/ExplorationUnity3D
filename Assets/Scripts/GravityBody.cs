using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity��ł��邱�� Player
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public GameObject item;//item�̎擾
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item") Destroy(item);
    }
}
