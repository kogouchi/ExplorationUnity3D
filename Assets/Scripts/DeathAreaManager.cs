using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//DeathArea����
public class DeathAreaManager : MonoBehaviour
{
    public PlayerController player;//player�擾
    public Text timeText;//timetext�擾
    public Text damegetext;//damegetext�擾
    public GameObject DeathAreaEffect;//DeathAreaEffect�擾

    private bool hpflg = false;//hp�����t���O
    private bool trSChangeflg = false;//transform.Scale�t���O(��x�̂ݏ������s����悤�ɕύX����)
    private float objSize = 0.2f;//Scale�ύX�l
    private bool tipsflg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�f�X�G���A�ɂ����ԁ{TipsText�\�����Ahp�����炳�Ȃ��悤�ɂ��邽�߂ɂ���
        if (Time.timeScale == 0.0f)
        {
            tipsflg = true;
            damegetext.gameObject.SetActive(false);//damage��\��
        }
        else tipsflg = false;
        if (hpflg == true && tipsflg == false) player.hp -= 0.5f;
        if(player.hp == 0) damegetext.gameObject.SetActive(false);//damage��\��
        AreaScaleChange();//AreaScale�ύX����
    }

    //AreaScale�ύX����
    public void AreaScaleChange()
    {
        //�J�E���g��0�ɂȂ����ꍇ
        if (timeText.text == "�������� �c��30�b" && 
            timeText.text != "�������� �c��0�b" &&
            trSChangeflg == false)
        {
            trSChangeflg = true;
            //Scale�����X�ɑ傫�����Ă���
            StartCoroutine(ScaleUp());
        }
    }

    public IEnumerator ScaleUp()
    {
        Vector3 trS = DeathAreaEffect.transform.localScale;//���݂�Scale�擾
        Vector3 mytrS = transform.localScale;

        //�ő�Scale����艺���ꍇ               //�ő�l��
        for (/*�������͏�ōs���Ă��邽�ߕs�v*/; trS.x < 2.0f;
            trS.x += objSize, trS.y += objSize, 
            mytrS.x = mytrS.x + 0.1f, mytrS.y = mytrS.y + 0.1f)
        {
            DeathAreaEffect.transform.localScale = new Vector3(trS.x, trS.y, trS.z);//Scale�̑��
            transform.localScale = new Vector3(mytrS.x, mytrS.y, mytrS.z);
            //Debug.Log("Scale�̊g�咆");
            yield return new WaitForSeconds(1.5f);//()�b��҂�
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp >= 0)
        {
            hpflg = true;
            damegetext.gameObject.SetActive(true);//damage�\��
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp >= 0)
        {
            hpflg = false;
            damegetext.gameObject.SetActive(false);//damage��\��
        }
    }

    //�I�u�W�F�N�g���ڐG���̏ꍇ�i�v���C���[�ƐڐG���{tipstext�\���̂��A�Q�[����ʂɖ߂�ۂ�damagetext�\���j
    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && tipsflg == false)
        {
            damegetext.gameObject.SetActive(true);//damage�\��
        }
    }
}
