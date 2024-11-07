using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public GameObject enemy;//enemmy�擾
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
    private Vector3 scale;//scale�ύX���Ɏg�p


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
        power++;
        //Power�̉���
        powertext.text = "Power " + power;//EnemyPowerText�\���X�V
        //�}�e���A���̕ύX
        if (this.transform.localScale.x > enemy.transform.localScale.x)
        {
            enemy.GetComponent<Renderer>().material = material[0];
            gameObject.GetComponent<Renderer>().material = material[1];
            //Debug.Log("�}�e���A���ύX");
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        if (collision.gameObject.tag == "Item") ItemCollision();
        //Enemy�̐ڐG����
        if (collision.gameObject.tag == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                hp -= 1.0f;
                if(hp >= 0.0f) damegetext.gameObject.SetActive(true);//damage�e�L�X�g�̕\��
                if (hp == 0)
                {
                    hptext.gameObject.SetActive(false);//hp�e�L�X�g�̍폜
                    healthbar.gameObject.SetActive(false);//hp�o�[�̍폜
                }
            }
        }
    }

    //ITEM�擾����PlayerScale�̕ύX�{��������
    public void ItemCollision()
    {
        scale = transform.localScale;//���݂̃X�P�[�����擾
        if (scale.x <= 1.0f)
        {
            scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
            transform.localScale = scale;//�X�P�[���̔��f
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")�@damegetext.gameObject.SetActive(false);//damage�e�L�X�g�̔�\��
    }
}
