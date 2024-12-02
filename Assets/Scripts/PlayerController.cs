using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public Slider healthbar;//Slider�o�[�擾
    public Text hptext;//text�̎擾
    public Text gameovertext;//gameovertext�擾
    public Animation anim = null;//animation�Đ����g�p
    private Rigidbody rb;//Rigidbody�擾
    private Transform mytransform;//Transform�擾
    public int power = 1;//power(Item�l�����̌�)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//�ړ����x
    public bool groundflg = false;//�n��flg
    private Vector3 movedir;//�ړ��L�[�Ɏg�p

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�擾
        mytransform = transform;//Transform�擾
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�ړ�+�d�͏���
        HP();//HP����
        Ani();//animation�Đ�
    }

    //�ړ�����
    void FixedUpdate()
    {
        //�i��ł�������ɂ������ƌ���
        {
            //float Ry = transform.localEulerAngles.y;//���݂�RotationY�����擾

            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90�x��]������
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90�x��]������
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90�x��]������
            //if (Input.GetKeyDown(KeyCode.A))
            //    Ry += 90.0f;//90�x��]������

            //transform.forward = Vector3.Slerp(transform.forward, movedir, Time.deltaTime * 0.1f);
            //Slerp����camera���o�O�遨�R���C�_�[������
            //�x�N�g���̑傫�����A0.01�ȏ�̎��Ɍ�����ς��遨�N�H�[�^�j�I��
            //Vector3 latesPos = transform.position;
            //Vector3 diff = transform.position - latesPos;
            //if (diff.magnitude > 0.01f)
            //{
            //    transform.rotation = Quaternion.LookRotation(diff);
            //}

        }
    }

    //�ړ�+�d�͏���
    public void Move()
    {
        //�ړ�����
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ����
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ���� .normalized�Ńx�N�g���̐��K��

        //�n�ʂ̏�ɗ����Ă���ꍇ
        if (groundflg == true)
        {
            //�d�͏���
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
                //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
                //���X�P�[���ƈʒu���W�ɉe������Ȃ�
                rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
            }
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
        }
    }

    //HP����
    public void HP()
    {
        healthbar.value = hp;//�o�[��value��hp�Ƃ���
        hptext.text = "HP�@" + hp + "/100";//text�̕\��
    }

    //animation�Đ�
    public void Ani()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {

        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        if (collision.gameObject.tag == "Item") power++;
        //Enemy�̐ڐG����
        if (collision.gameObject.tag == "Enemy")
        {
            if (hp == 0)
            {
                hptext.gameObject.SetActive(false);//hp�e�L�X�g��\��
                healthbar.gameObject.SetActive(false);//hp�o�[��\��
                gameovertext.gameObject.SetActive(true);//gameover�\��
                Time.timeScale = 0.0f;
            }
            else hp -= 1.0f;
        }
        //�n�ʂ̐ڐG����
        if (collision.gameObject.tag == "Planet")
        {
            groundflg = true;
            //Debug.Log("�n�ʂ̏�ɗ����Ă���");
        }
    }

    ////�I�u�W�F�N�g���m�����ꂽ�ꍇ
    //public void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Planet")
    //    {
    //        groundflg = false;
    //        Debug.Log("�n�ʂ��痣�ꂽ���߁A�d�͒n�ʂɗ�������");
    //        //GravityAttractor.cs��Attract�֐�����
    //        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    //    }
    //}
}
