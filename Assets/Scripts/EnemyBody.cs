using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//�A�C�e���ڐG����
public class EnemyBody : MonoBehaviour
{
    public GameObject[] items;//item�I�u�W�F�N�g�擾

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //�A�C�e�������������ꍇ
        if (collision.gameObject.name == "Item")     items[0].SetActive(false);
        if (collision.gameObject.name == "Item (1)") items[1].SetActive(false);
        if (collision.gameObject.name == "Item (2)") items[2].SetActive(false);
        if (collision.gameObject.name == "Item (3)") items[3].SetActive(false);
        if (collision.gameObject.name == "Item (4)") items[4].SetActive(false);
        if (collision.gameObject.name == "Item (5)") items[5].SetActive(false);
        if (collision.gameObject.name == "Item (6)") items[6].SetActive(false);
    }
}