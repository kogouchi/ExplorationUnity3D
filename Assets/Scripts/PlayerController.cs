using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public GameObject enemy;//enemmy�擾
    public Text hptext;//text�̎擾

    public Material[] material;//�}�e���A���̎擾
    public Text missiontext;//text�̎擾
    public Text cleartext;//cleartext�擾
    public Text gameovertext;//gameovertext�擾
    public Text damegetext;//damegetext�擾
    //public Text leveltext;//leveltext�擾
    public Slider healthbar;//Slider�o�[�擾
    public float currenthp = 100.0f;//���݂�hp

    public float movespeed = 10.0f;
    private Vector3 movedir;
    private Rigidbody rb;
    public GameObject[] items;//items�擾
    //private int itemcnt = 0;, itemmax = 7;//item�J�E���g�Aitem�̍ő�l
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
        ////�}�e���A���̕ύX
        //if(enemy == true)
        //if(this.transform.localScale.x > enemy.transform.localScale.x)
        //{
        //    enemy.GetComponent<Renderer>().material = material[0];
        //    gameObject.GetComponent<Renderer>().material = material[1];
        //    //Debug.Log("�}�e���A���ύX");
        //}

        TextManager();//TEXT����
        HP();//HP����
        KeyMove();//�L�[����
    }

    //�ړ�����
    void FixedUpdate()
    {
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
        //���X�P�[���ƈʒu���W�ɉe������Ȃ�
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }

    //TEXT����
    public void TextManager()
    {
        //leveltext.text = "level " + itemcnt;//level�̕\��
        if (enemy == true)
            if (transform.localScale.x < enemy.transform.localScale.x)
                missiontext.text = "Item���E���ăp���[�A�b�v!";
            else missiontext.text = "�G���U�����悤";
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
            gameObject.SetActive(false);//�폜�ł͂Ȃ�false����
            //Destroy(gameObject);//�v���C���[�폜

        }
    }

    //�L�[����
    public void KeyMove()
    {
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD ����
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS ����
        //.normalized�Ńx�N�g���̐��K��
    }

    //ITEM�擾����PlayerScale�̕ύX����
    public void ItemCollision()
    {
        //Debug.Log("Item�ɓ�������");
        //itemcnt++;
        scale = transform.localScale;//���݂̃X�P�[�����擾
        if(scale.x <= 1.0f)
        {
            scale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
            transform.localScale = scale;//�X�P�[���̔��f
            //Debug.Log($"�X�P�[���ύX x=%f{scale.x}, y=%f{scale.y}, z=%f{scale.z}");
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //Item�̐ڐG����
        {
            if (collision.gameObject.name == "Item")
            {
                items[0].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (1)")
            {
                items[1].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (2)")
            {
                items[2].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (3)")
            {
                items[3].SetActive(false);
                ItemCollision();
            }
            if (collision.gameObject.name == "Item (4)")
            {
                items[4].SetActive(false);
                ItemCollision();
            }
            //if (collision.gameObject.name == "Item (5)")
            //{
            //    items[5].SetActive(false);
            //    ItemCollision();
            //}
            //if (collision.gameObject.name == "Item (6)")
            //{
            //    items[6].SetActive(false);
            //    ItemCollision();
            //}
        }
        //Enemy�̐ڐG����
        if (collision.gameObject.name == "Enemy")
        {
            if(this.transform.localScale.x < enemy.transform.localScale.x)
            {
                currenthp -= 1.0f;
                if(currenthp >= 0.0f)
                    damegetext.gameObject.SetActive(true);//damage�e�L�X�g�̕\��
                //Debug.Log("�G�l�~�[�̕�������");
            }
            else
            {
                //Destroy(enemy, 0.5f);//�G�̍폜
                enemy.SetActive(false);//enemy�̔�\��
                cleartext.gameObject.SetActive(true);//Clear�e�L�X�g�̕\��
                //Time.timeScale = 0.0f;
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
