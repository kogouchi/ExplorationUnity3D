using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//Enemy�I�u�W�F�N�g�{��
public class EnemyBody : MonoBehaviour
{
    public Transform player;//player��Transform�擾
    public Transform mytransform;//Transform�擾
    public GravityAttractor attractor;//�uGravityAttractor.cs�vC#���Q��
    public GameObject[] item;//item�I�u�W�F�N�g�擾
    private Rigidbody rb;//Rigidbody�擾

    public float movespeed = 0.8f;//�ړ��X�s�[�h
    private bool targetflag = false;//target(player)�̂���

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�擾
        mytransform = transform;//�ʒu���W�̎擾
    }

    // Update is called once per frame
    void Update()
    {
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    void FixedUpdate()
    {
        if (targetflag == false)
            //player�ɒǏ]�����鏈��
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = true;//���̂̓����~
            targetflag = true;
        }
        //�A�C�e�������������ꍇ
        if (collision.gameObject.name == "Item")     item[0].SetActive(false);
        if (collision.gameObject.name == "Item (1)") item[1].SetActive(false);
        if (collision.gameObject.name == "Item (2)") item[2].SetActive(false);
        if (collision.gameObject.name == "Item (3)") item[3].SetActive(false);
        if (collision.gameObject.name == "Item (4)") item[4].SetActive(false);
        if (collision.gameObject.name == "Item (5)") item[5].SetActive(false);
        if (collision.gameObject.name == "Item (6)") item[6].SetActive(false);
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = false;//���̂̓���Đ�
            targetflag = false;
        }
    }
}