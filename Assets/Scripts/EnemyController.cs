using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//player�Ǐ]����+player�ڐG�����{item�ڐG����
public class EnemyController : MonoBehaviour
{
    public GravityAttractor attractor;//�uGravityAttractor.cs�vC#���Q��
    public Transform player;//player��Transform�擾
    public Text EnemyPowerText;//EnemyPowerText�擾
    private Transform mytransform;//Enemy��Transform�擾
    private Rigidbody rb;//Rigidbody�擾

    public int power = 1;//power(Item�l�����̌�)
    public float movespeed = 1.0f;//�ړ��X�s�[�h
    private bool targetflag = true;//target(player�̂���)
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�擾
        mytransform = transform;//�ʒu���W�̎擾
    }

    // Update is called once per frame
    void Update()
    {
        //Power�̉���
        EnemyPowerText.text = "Power " + power;//EnemyPowerText�\���X�V
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    void FixedUpdate()
    {
        TargetMove();//�Ǐ]����
    }

    //�Ǐ]����
    void TargetMove()
    {
        //�Ǐ]�J�n��Ԃ̏ꍇ
        if (targetflag == true)
            //player�ɒǏ]�����鏈��
            mytransform.position = Vector3.Lerp(mytransform.position, player.position, movespeed * Time.deltaTime);
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = true;//���̂̓����~
            targetflag = false;//�Ǐ]��~
            //gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Item") power++;
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = false;//���̂̓���Đ�
            targetflag = true;//�Ǐ]�J�n
        }
    }
}
