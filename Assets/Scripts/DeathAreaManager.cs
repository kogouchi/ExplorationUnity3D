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
    public Text damegetext;//damegetext�擾
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flg) player.hp -= 1.0f;
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            flg = true;
            damegetext.gameObject.SetActive(true);//damage�\��
        }
    }

    //�I�u�W�F�N�g���m�����ꂽ�ꍇ
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            flg = false;
            damegetext.gameObject.SetActive(false);//damage��\��
        }
    }

}
