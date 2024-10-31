using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public GameObject searchobj;//�T���pC#�擾
    public SearchManager searchscript;//�T���pC#�擾
    public Transform player;//player�̎擾
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public float movespeed = 0.5f;
    public Transform mytransform;
    private Rigidbody rb;
    private bool targetflag = false;
    private string itemname;
    public GameObject[] item;//item�̎擾

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
        searchscript = GetComponent<SearchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //�T���p�ʒu���W��G�ʒu���W�ɕύX
        searchobj.transform.position = mytransform.position;
        //searchscript.objname = itemname;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.isKinematic = true;//���̂̓����~
            targetflag = true;
        }
        //�A�C�e�������������ꍇ
        if (collision.gameObject.name == "Item")
        {
            Destroy(item[0]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (1)")
        {
            Destroy(item[1]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (2)")
        {
            Destroy(item[2]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (3)")
        {
            Destroy(item[3]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (4)")
        {
            Destroy(item[4]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (5)")
        {
            Destroy(item[5]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (6)")
        {
            Destroy(item[6]);
            Debug.Log("�A�C�e���ɓ�������");
        }

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