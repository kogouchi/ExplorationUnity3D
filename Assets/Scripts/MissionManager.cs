using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

/// <summary>
/// �e�~�b�V�����̏���
/// </summary>
public class MissionManager : MonoBehaviour
{
    public Text scoretext;//text�̎擾
    public GameObject[] item;//item�̎擾
    public GameObject[] enemy;//enemmy�̎擾
    private int cnt = 0, maxcnt = 7;//�X�R�A�J�E���g�A�X�R�A�̍ő�l

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "" + cnt + "/" + maxcnt;//text�̕\�����e
        if (cnt == maxcnt) scoretext.text = "�~�b�V�����N���A!";
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Item")
        {
            Destroy(item[0]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (1)")
        {
            Destroy(item[1]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (2)")
        {
            Destroy(item[2]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (3)")
        {
            Destroy(item[3]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (4)")
        {
            Destroy(item[4]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (5)")
        {
            Destroy(item[5]);
            cnt++;
        }
        if (collision.gameObject.name == "Item (6)")
        {
            Destroy(item[6]);
            cnt++;
        }
    }
}
