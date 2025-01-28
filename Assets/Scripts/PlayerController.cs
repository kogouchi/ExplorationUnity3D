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

    public int power = 1;//power(Item�l�����̌�)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//�ړ����x
    public bool groundflg = false;//�n��flg
    public bool hpflg = false;//hp�t���O(hp��0�ȏ�̎���hp���炷�悤�ɂ��邽�߂̃t���O)
    public bool moveflg = false;

    private Rigidbody myrb;//Rigidbody�擾
    private Transform mytransform;//Transform�擾
    private Vector3 movedir;//�ړ��L�[�Ɏg�p

    #region �Q�l�T�C�g
    // ���̂̏�ɃI�u�W�F�N�g���������
    // https://youtube.com/watch?v=gHeQ8Hr92P4&si=MevGvtv3gmaj5lh0
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();//Rigidbody�擾
        mytransform = transform;//Transform�擾
    }

    // Update is called once per frame
    void Update()
    {
        HP();//HP����
    }

    void FixedUpdate()
    {
        Move();//�ړ�����
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    public void Move()
    {
        if(gameObject.activeSelf && moveflg == false)
        {
            //�ړ�����
            movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//AD
            0,
            Input.GetAxisRaw("Vertical")).normalized;//WS
            //normalized�Ńx�N�g���̐��K��(��΂��Ȃ��Ƃ����Ȃ��炵��)
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
                myrb.MovePosition(myrb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
            }
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, myrb);//���g��transform��rigidbody�̏���n��
        }
        //HP��0�ɂȂ����ꍇ
        if (hp <= 0 && hpflg == false)
        {
            //�Q�[���I�[�o�[����-------------------------------------------
            //(CameraManager�ł��g�p���邽�߂̂��Ɋ֐���������)------------
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, myrb);//���g��transform��rigidbody�̏���n��
            hpflg = true;//hp������ȏ㌸�炳�Ȃ��悤�ɂ���
            hptext.gameObject.SetActive(false);//hp�e�L�X�g��\��
            healthbar.gameObject.SetActive(false);//hp�o�[��\��
            gameovertext.gameObject.SetActive(true);//gameover�\��
            Time.timeScale = 0.0f;
            //-------------------------------------------------------------
        }
        //�N���A���̃v���C���[�I�u�W�F�N�g�Œ肳���邽�߂̏���
        //����:Scene3�AScene4��Prefab�������G�l�~�[���i�[������ȊO�͏����͒ʂ�
        if(!enemy.gameObject.activeSelf && hp >= 0)
        {
            //�N���A������-------------------------------------------------
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, myrb);//���g��transform��rigidbody�̏���n��
        }
    }

    /// <summary>
    /// HP����
    /// </summary>
    public void HP()
    {
        healthbar.value = hp;//�o�[��value��hp�Ƃ���
        hptext.text = "HP�@" + hp + "/100";//text�̕\��
    }

    /// <summary>
    /// �I�u�W�F�N�g���m�̓����蔻��
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        if (collision.gameObject.tag == "Item") power++;
        //Enemy�̐ڐG����
        if (collision.gameObject.tag == "Enemy")
            if (enemy.power > power) hp -= 1.0f;
        //�n�ʂ̐ڐG����
        if (collision.gameObject.tag == "Planet")�@groundflg = true;
    }
}
