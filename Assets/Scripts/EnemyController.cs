using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

//player�Ǐ]����+player�ڐG�����{item�ڐG����
public class EnemyController : MonoBehaviour
{
    //public Text ePower;
    public GravityAttractor attractor;//�uGravityAttractor.cs�vC#���Q��
    public PlayerController player;//�uPlayerController.cs�vC#���Q��
    public Transform playerpos;//player��Transform�擾
    //public Text EnemyPowerText;//EnemyPowerText�擾
    public Text damegetext;//damegetext�擾
    private Transform mytransform;//Enemy��Transform�擾
    private Rigidbody rb;//Rigidbody�擾
    public Material[] material;//�}�e���A���̎擾
    public GameObject particleEffect;//���񂾎��̃G�t�F�N�g�擾
    public MeshRenderer mr;//MeshRenderer�擾
    private SphereCollider col;//SphereCollider�擾
    public GameObject Leaf;//�t���ώ擾

    public int power = 3;//power(Item�l�����̌�)
    public float movespeed = 2.0f;//�ړ��X�s�[�h
    private bool targetflag = true;//target(player�̂���)
    public float displayDelay = 0.1f;//�\���܂ł̎���
    private bool activeflg = true;//�R���[�`�����J��Ԃ��Ȃ����߂̃t���O
    public bool effectflg = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�擾
        mr = GetComponent<MeshRenderer>();//MeshRenderer�擾
        col = GetComponent<SphereCollider>();//Collider�擾
        mytransform = transform;//�ʒu���W�̎擾
        //int rnd = Random.Range(0, 2);
        //if (rnd == 0) gameObject.SetActive(false);
        //if (rnd == 1) gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Power�̉���
        //EnemyPowerText.text = "Power " + power;//EnemyPowerText�\���X�V
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    void FixedUpdate()
    {
        TargetMove();//�Ǐ]����
        MaterialSetting();//Material�ύX����
        //gamescene5�������ꍇ
        //if (SceneManager.GetActiveScene().name == "GameScene1")
        //    GameStage();//Stage5�̏ꍇ
    }

    //�Ǐ]����
    public void TargetMove()
    {
        //�Ǐ]�J�n��Ԃ̏ꍇ
        if (targetflag == true)
        {
            //player�ɒǏ]�����鏈��            
            mytransform.position = Vector3.Lerp(mytransform.position, playerpos.position, movespeed * Time.deltaTime);
        }
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

    //gamescene5�̏ꍇ
    public void GameStage()
    {
        if (!gameObject && activeflg == false)
            StartCoroutine(EnemyActive());//�R���[�`���J�n
    }

    //enemy��\���̏ꍇ
    public IEnumerator EnemyActive()
    {
        yield return new WaitForSeconds(1.0f);//displayDelay���҂�
        gameObject.SetActive(false);//enemy�폜
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (power < player.power)
            {
                player.moveflg = true;//Player�ړ��s�ݒ�
                damegetext.gameObject.SetActive(false);//damage��\��
                mr.enabled = false;//���f���̔�\��
                Leaf.gameObject.SetActive(false);//��\��
                //�G�t�F�N�g��1�x�̂ݍĐ�
                if (effectflg == false)
                {
                    Instantiate(particleEffect, transform.position, transform.rotation);//Effect�Đ�
                    effectflg = true;
                }
                targetflag = false;//�v���C���[�ւ̒Ǐ]�𖳂���
                StartCoroutine(EnemyActive());//�R���[�`���J�n
                //particleEffect.Play();//�G�t�F�N�g�Đ�                
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
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damegetext.gameObject.SetActive(false);//damage��\��
            rb.isKinematic = false;//���̂̓���Đ�
            targetflag = true;//�Ǐ]�J�n
        }
    }
}
