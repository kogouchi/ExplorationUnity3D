using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public Transform player_pos;//player�ʒu���W�̎擾
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public float movespeed = 0.5f;//�ړ����x
    private Transform mytransform;
    private Rigidbody rb;
    private bool trigger = true;//true ���������� false �v���C���[�̑O�ɂ���(��~���)

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
        if (trigger == true)
            mytransform.position = Vector3.Lerp(mytransform.position, player_pos.position, movespeed * Time.deltaTime);//�v���C���[�̈ʒu�ړ�
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = false;
    }

    //�I�u�W�F�N�g���m�����ꂽ��
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") trigger = true;
    }
}