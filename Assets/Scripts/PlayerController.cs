using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public EnemyController enemy;
    public Slider healthbar;//Slider�o�[�擾
    public Text hptext;//text�̎擾
    public Text gameovertext;//gameovertext�擾
    public AnimationClip[] animationClips;//�A�j���[�V�����Y�i�[
    public Animator anim = null;//animation�Đ����g�p
    private Rigidbody rb;//Rigidbody�擾
    private Transform mytransform;//Transform�擾
    public int power = 1;//power(Item�l�����̌�)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//�ړ����x
    public bool groundflg = false;//�n��flg
    private Vector3 movedir;//�ړ��L�[�Ɏg�p
    public bool aniflg = false;//animation�t���O
    public bool moveflg = false;
    bool timeflg = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�擾
        anim = GetComponent<Animator>();//animation�擾
        mytransform = transform;//Transform�擾
    }

    // Update is called once per frame
    void Update()
    {
        HP();//HP����
        Move();//�ړ�+�d�͏���
        //Ani();//animation�Đ�
    }

    //�ړ�����
    void FixedUpdate()
    {
        Debug.Log(power);
    }

    //�ړ�+�d�͏���
    public void Move()
    {
        if(gameObject.activeSelf && moveflg == false)
        {
            //�ړ�����
            movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//AD ����
            0,
            Input.GetAxisRaw("Vertical")).normalized;//WS ���� .normalized�Ńx�N�g���̐��K��
        }
        //�n�ʂ̏�ɗ����Ă���ꍇ
        if (groundflg == true && moveflg == false)
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
    //public void Ani()
    //{
    //    //if(!Input.aniKey) //����������Ă��Ȃ���
    //    if(aniflg == false)
    //    {
    //        aniflg = true;
    //        //�E
    //        if (Input.GetKeyDown(KeyCode.D) == true)
    //        {
    //            anim.CrossFade("RightAnimation", 0.3f);
    //            Debug.Log("�E");
    //        }
    //        else anim.SetBool("RightAnimation", false);
    //        //��
    //        if (Input.GetKeyDown(KeyCode.A) == true)
    //        {
    //            anim.SetBool("LeftAnimation", true);
    //            Debug.Log("��");
    //        }
    //        else anim.SetBool("LeftAnimation", false);
    //        //��
    //        if(Input.GetKeyDown(KeyCode.W) == true)
    //        {
    //            anim.SetBool("WalkAnimation", true);
    //            Debug.Log("��");
    //        }
    //        else anim.SetBool("WalkAnimation", false);
    //        //��
    //        if(Input.GetKeyDown(KeyCode.S) == true)
    //        {
    //            anim.SetBool("BackAnimation", true);
    //            Debug.Log("��");
    //        }
    //        else anim.SetBool("BackAnimation", false);
    //    }
    //    else aniflg = false;
    //}

    //�I�u�W�F�N�g���m���ڐG������

    public void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        if (collision.gameObject.tag == "Item") power++;
        //Enemy�̐ڐG����
        if (collision.gameObject.tag == "Enemy")
        {
            if (hp <= 0)
            {
                hptext.gameObject.SetActive(false);//hp�e�L�X�g��\��
                healthbar.gameObject.SetActive(false);//hp�o�[��\��
                gameovertext.gameObject.SetActive(true);//gameover�\��
                Time.timeScale = 0.0f;
            }
            if(hp != 0 && enemy.power > power)
                 hp -= 1.0f;
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
