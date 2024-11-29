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
    public CameraManager cameraManager;//CameraManager�Q��
    public Text damegetext;//damegetext�擾
    private bool hpflg = false;//hp�����t���O
    private bool trSChangeflg = false;//transform.Scale�t���O(��x�̂ݏ������s����悤�ɕύX����)
    private float objSize = 0.2f;//Scale�ύX�l

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hpflg) player.hp -= 1.0f;
        if(player.hp == 0) damegetext.gameObject.SetActive(false);//damage��\��
        AreaScaleChange();//AreaScale�ύX����
    }

    //AreaScale�ύX����
    public void AreaScaleChange()
    {
        //�J�E���g��0�ɂȂ����ꍇ
        if (cameraManager.timeText.text == "30�b" && 
            cameraManager.timeText.text != "0�b"  &&
            trSChangeflg == false)
        {
            trSChangeflg = true;
            //Scale�����X�ɑ傫�����Ă���
            StartCoroutine(ScaleUp());
        }
    }

    public IEnumerator ScaleUp()
    {
        Vector3 trS = this.transform.localScale;//���݂�Scale�擾

        //�ő�Scale����艺���ꍇ               //�ő�l��
        for (/*�������͏�ōs���Ă��邽�ߕs�v*/; trS.x < 7.0f; trS.x += objSize, trS.y += objSize)
        {
            this.transform.localScale = new Vector3(trS.x, trS.y, trS.z);//Scale�̑��
            //Debug.Log("Scale�̊g�咆");
            yield return new WaitForSeconds(1.5f);//()�b��҂�
        }
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            hpflg = true;
            damegetext.gameObject.SetActive(true);//damage�\��
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            hpflg = false;
            damegetext.gameObject.SetActive(false);//damage��\��
        }
    }

}
