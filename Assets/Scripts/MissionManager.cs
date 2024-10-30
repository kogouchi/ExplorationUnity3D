using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

/// <summary>
/// �e�~�b�V�����̏���
/// </summary>
public class MissionManager : MonoBehaviour
{
    public Text missiontext;//text�̎擾
    public Text hptext;//text�̎擾
    public Slider healthbar;//Slider�o�[�̎擾
    public float currenthp = 100.0f;//���݂�hp
    public float distance = 1.0f;//�I�u�W�F�N�g���o�\�ȋ���
    public GameObject[] item;//item�̎擾
    public GameObject[] enemy;//enemmy�̎擾
    public int killcnt = 0;//�G�̃J�E���g
    private int itemcnt = 0, itemmax = 7;//item�J�E���g�Aitem�̍ő�l
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = transform.localScale;
        scale = new Vector3(0.5f, 0.5f, 0.5f);//�����ʒu�ǉ�
        transform.localScale = scale;//�X�P�[���̔��f
    }

    // Update is called once per frame
    void Update()
    {
        TEXT();//TEXT����
        //RAY();//RAY�������G��|���~�b�V�����̏ꍇ
        HP();//HP����
    }

    //TEXT����
    public void TEXT()
    {
        if (itemcnt == 0) missiontext.text = "�~�b�V�����e�L�X�g";
        else missiontext.text = "" + itemcnt + "/" + itemmax;//text�̕\�����e
        if (itemcnt == itemmax) missiontext.text = "�~�b�V�����N���A!";
    }

    //RAY����
    public void RAY()
    {
        Vector3 raystartpos = transform.position;//Ray�̓v���C���[�̈ʒu�����΂�
        Vector3 raydirection = transform.forward.normalized;//Ray�̓v���C���[�������Ă�������ɔ�΂�
        RaycastHit raycastHit;//Hit�����I�u�W�F�N�g�i�[�p

        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.Space))
        {
            var isHit = Physics.Raycast(raystartpos, raydirection, out raycastHit, distance);//Ray�̔���

            Debug.DrawRay(raystartpos, raydirection * distance, Color.red);
            //Debug.DrawRay(Vector3�@start(ray�J�n�ʒu), Vector3 dir(ray�̕����ƒ���), Color color(���C���̐F));

            if (isHit && killcnt != 6)
            {
                //Log��Hit�����I�u�W�F�N�g�����o��
                Debug.Log("" + raycastHit.collider.gameObject.name + "��|����");
                Destroy(raycastHit.collider.gameObject);
                killcnt++;
                enemy[killcnt].SetActive(true);//enemy����
            }
        }
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
            //Destroy(gameObject);//�v���C���[�폜
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    //void OnCollisionEnter(Collision collision)
    //{
    //    //Item�̐ڐG����
    //    {
    //        if (collision.gameObject.name == "Item")
    //        {
    //            Destroy(item[0]);
    //            itemcnt++;
    //            //scale = transform.localScale;
    //            //scale.x += 0.1f;
    //            //scale.y += 0.1f;
    //            //scale.z += 0.1f;
    //            //transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (1)")
    //        {
    //            Destroy(item[1]);
    //            itemcnt++;
    //            //scale = transform.localScale;
    //            //scale.x += 0.1f;
    //            //scale.y += 0.1f;
    //            //scale.z += 0.1f;
    //            //transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (2)")
    //        {
    //            Destroy(item[2]);
    //            itemcnt++;
    //            //scale = transform.localScale;
    //            //scale.x += 0.1f;
    //            //scale.y += 0.1f;
    //            //scale.z += 0.1f;
    //            //transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (3)")
    //        {
    //            Destroy(item[3]);
    //            itemcnt++;
    //            scale = transform.localScale;
    //            scale.x += 0.1f;
    //            scale.y += 0.1f;
    //            scale.z += 0.1f;
    //            transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (4)")
    //        {
    //            Destroy(item[4]);
    //            itemcnt++;
    //            scale = transform.localScale;
    //            scale.x += 0.1f;
    //            scale.y += 0.1f;
    //            scale.z += 0.1f;
    //            transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (5)")
    //        {
    //            Destroy(item[5]);
    //            itemcnt++;
    //            scale = transform.localScale;
    //            scale.x += 0.1f;
    //            scale.y += 0.1f;
    //            scale.z += 0.1f;
    //            transform.localScale = scale;
    //        }
    //        if (collision.gameObject.name == "Item (6)")
    //        {
    //            Destroy(item[6]);
    //            itemcnt++;
    //            scale = transform.localScale;
    //            scale.x += 0.1f;
    //            scale.y += 0.1f;
    //            scale.z += 0.1f;
    //            transform.localScale = scale;
    //        }
    //    }
    //    //Enemy�̐ڐG����
    //    if (collision.gameObject.name == "Enemy") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (1)") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (2)") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (3)") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (4)") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (5)") currenthp -= 1.0f;
    //    if (collision.gameObject.name == "Enemy (6)") currenthp -= 1.0f;
    //}
}
