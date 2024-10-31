using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public Text missiontext;//text�̎擾
    public Text hptext;//text�̎擾
    public Text cleartext;//cleartext�̎擾
    public Text gameovertext;//gameovertext�̎擾
    public Text damegetext;//damegetext�̎擾
    public Slider healthbar;//Slider�o�[�̎擾
    public float currenthp = 100.0f;//���݂�hp

    public float movespeed = 15.0f;
    private Vector3 movedir;
    private Rigidbody rb;
    public GameObject[] item;//item�̎擾
    public GameObject enemy;//enemmy�̎擾
    private int itemcnt = 0;//, itemmax = 7;//item�J�E���g�Aitem�̍ő�l
    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;//�X�P�[���̎擾
        scale = new Vector3(0.5f, 0.5f, 0.5f);//�X�P�[�������ݒ�
        transform.localScale = scale;//�X�P�[���̔��f
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TEXT();//TEXT����
        HP();//HP����
        movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//�J�[�\���L�[ ����
            0,
            Input.GetAxisRaw("Vertical")).normalized;//�J�[�\���L�[ ����
        //.normalized�Ńx�N�g���̐��K��
    }

    void FixedUpdate()
    {
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
        //���X�P�[���ƈʒu���W�ɉe������Ȃ�
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //TEXT����
    public void TEXT()
    {
        if (itemcnt == 0) missiontext.text = "item���E����power up!";
        //else missiontext.text = "" + itemcnt + "/" + itemmax;//text�̕\�����e
        //if (itemcnt == itemmax) missiontext.text = "�~�b�V�����N���A!";
    }

    //HP����
    public void HP()
    {
        healthbar.value = currenthp;//�o�[��value��hp�Ƃ���
        hptext.text = "HP�@" + currenthp + "/100";//text�̕\��
        if (currenthp == 0)
        {
            hptext.gameObject.SetActive(false);//hp�e�L�X�g�̍폜
            healthbar.gameObject.SetActive(false);//hp�o�[�̍폜
            gameovertext.gameObject.SetActive(true);//gameover�e�L�X�g�\��
            //gameObject.SetActive(false);//�폜�ł͂Ȃ�false����
            //Destroy(gameObject);//�v���C���[�폜

        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        {
            if (collision.gameObject.name == "Item")
            {
                Destroy(item[0]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (1)")
            {
                Destroy(item[1]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (2)")
            {
                Destroy(item[2]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (3)")
            {
                Destroy(item[3]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (4)")
            {
                Destroy(item[4]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (5)")
            {
                Destroy(item[5]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }
            if (collision.gameObject.name == "Item (6)")
            {
                Destroy(item[6]);
                itemcnt++;
                scale = transform.localScale;//���݂̃X�P�[�����擾
                scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
                transform.localScale = scale;//�X�P�[���̔��f
                //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
            }

        }
        //Enemy�̐ڐG����
        if (collision.gameObject.name == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                currenthp -= 1.0f;
                damegetext.gameObject.SetActive(true);//damage�e�L�X�g�̕\��
                //Debug.Log("�G�l�~�[�̕�������");
            }
            else
            {
                Destroy(enemy);//�G�̍폜
                cleartext.gameObject.SetActive(true);//Clear�e�L�X�g�̕\��
                //Debug.Log("Enemy��|����");
            }
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            damegetext.gameObject.SetActive(false);//damage�e�L�X�g�̔�\��
        }
    }

}
