using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public GameObject enemyobj;//enemmy�擾
    public Material[] material;//�}�e���A���̎擾
    public Slider healthbar;//Slider�o�[�擾
    public Text hptext;//text�̎擾
    public Text damegetext;//damegetext�擾
    public Text powertext;//powertext�擾
    private Rigidbody rb;//Rigidbody�擾
    private Transform mytransform;//Transform�擾

    public int power = 1;//power(Item�l�����̌�)
    public float hp = 100.0f;//playerhp
    public float movespeed = 10.0f;//�ړ����x
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
        MaterialSetting();//Material�̕ύX
    }

    //�ړ�����
    void FixedUpdate()
    {
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
        //���X�P�[���ƈʒu���W�ɉe������Ȃ�
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //�ړ�+�d�͏���
    public void Move()
    {
        //�ړ�����
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ����
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ���� .normalized�Ńx�N�g���̐��K��
        //�d�͏���
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    //HP����
    public void HP()
    {
        healthbar.value = hp;//�o�[��value��hp�Ƃ���
        hptext.text = "HP�@" + hp + "/100";//text�̕\��
    }

    //MaterialSetting����
    public void MaterialSetting()
    {
        //Power�̉���
        powertext.text = "Power " + power;//EnemyPowerText�\���X�V
        //�}�e���A���̕ύX
        if (this.transform.localScale.x > enemyobj.transform.localScale.x)
        {
            enemyobj.GetComponent<Renderer>().material = material[0];
            gameObject.GetComponent<Renderer>().material = material[1];
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
                hptext.gameObject.SetActive(false);//hp�e�L�X�g�̍폜
                healthbar.gameObject.SetActive(false);//hp�o�[�̍폜
                gameObject.SetActive(false);
            }
            else hp -= 1.0f;
            if(hp > 0.0f) damegetext.gameObject.SetActive(true);//damage�e�L�X�g�̕\��
            else damegetext.gameObject.SetActive(false);//damage�e�L�X�g�̔�\��
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")�@damegetext.gameObject.SetActive(false);//damage�e�L�X�g�̔�\��
    }
}
