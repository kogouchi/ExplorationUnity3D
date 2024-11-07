using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//player�Ǐ]����+player�ڐG�����{item�ڐG����
public class EnemyController : MonoBehaviour
{
    public GravityAttractor attractor;//�uGravityAttractor.cs�vC#���Q��
    public PlayerController player;//�uPlayerController.cs�vC#���Q��
    public Transform playerpos;//player��Transform�擾
    public Text EnemyPowerText;//EnemyPowerText�擾
    public Text damegetext;//damegetext�擾
    private Transform mytransform;//Enemy��Transform�擾
    private Rigidbody rb;//Rigidbody�擾
    public Material[] material;//�}�e���A���̎擾

    public int power = 3;//power(Item�l�����̌�)
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
        MaterialSetting();//Material�ύX����
    }

    //�Ǐ]����
    void TargetMove()
    {
        //�Ǐ]�J�n��Ԃ̏ꍇ
        if (targetflag == true)
            //player�ɒǏ]�����鏈��
            mytransform.position = Vector3.Lerp(mytransform.position, playerpos.position, movespeed * Time.deltaTime);
    }

    //MaterialSetting����
    public void MaterialSetting()
    {
        //power��player�̕����傫���ꍇ
        if(power < player.power)
        {
            //Material��ύX
            player.GetComponent<Renderer>().material = material[0];
            gameObject.GetComponent<Renderer>().material = material[1];
        }
        else
        {
            //Material�����ɖ߂�
            gameObject.GetComponent<Renderer>().material = material[0];
            player.GetComponent<Renderer>().material = material[1];
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (power < player.power)
            {
                gameObject.SetActive(false);//enemy�폜
                damegetext.gameObject.SetActive(false);//damage��\��
            }
            else
            {
                rb.isKinematic = true;//���̂̓����~
                targetflag = false;//�Ǐ]��~
                if(player.hp > 0.0f) damegetext.gameObject.SetActive(true);//damage�\��
            }
        }
        if (collision.gameObject.tag == "Item") power++;
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damegetext.gameObject.SetActive(false);//damage��\��
            rb.isKinematic = false;//���̂̓���Đ�
            targetflag = true;//�Ǐ]�J�n
        }
    }
}
