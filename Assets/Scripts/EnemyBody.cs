using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Transform player;//player�̎擾
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public float movespeed = 0.5f;
    Transform mytransform;
    private Rigidbody rb;
    private bool trigger = false;

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

    private void FixedUpdate()
    {
        if(trigger == false)
            //player�ɒǏ]�����鏈��
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //�I�u�W�F�N�g���m���ڐG������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = true;
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = false;
    }
}