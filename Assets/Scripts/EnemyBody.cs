using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�A�C�e���ڐG����
public class EnemyBody : MonoBehaviour
{
    public GameObject[] items;//item�I�u�W�F�N�g�擾
    public Text EnemyPowerText;//EnemyPowerText�擾
    private int power = 1;//power(Item�l�����̌�)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyPowerText.text = "Power " + power;//EnemyPowerText�\���X�V
        //Enemy����\���ɂȂ����ꍇ
        if(!gameObject) EnemyPowerText.gameObject.SetActive(false);//EnemyPowerText��\��
    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //�A�C�e�������������ꍇ
        {
            if (collision.gameObject.name == "Item")
            {
                items[0].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (1)")
            {
                items[1].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (2)")
            {
                items[2].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (3)")
            {
                items[3].SetActive(false);
                power++;
            }
            if (collision.gameObject.name == "Item (4)")
            {
                items[4].SetActive(false);
                power++;
            }
        }
    }
}