using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy�A�C�e���E���͈�
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemy�̎擾
    public GameObject[] item;//item�̎擾
    private string objname;//Object���擾

    // Start is called before the first frame update
    void Start()
    {
        transform.position = enemy.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�I�u�W�F�N�g���m���ڐG������
    public void OnCollisionEnter(Collision collision)
    {
        //objname = collision.gameObject.name;

        //�A�C�e�������������ꍇ
        if (collision.gameObject.name == "Item")
        {
            Destroy(item[0]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (1)")
        {
            Destroy(item[1]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (2)")
        {
            Destroy(item[2]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (3)")
        {
            Destroy(item[3]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (4)")
        {
            Destroy(item[4]);
            Debug.Log("�A�C�e���ɓ�������");
        }
        if (collision.gameObject.name == "Item (5)")
        {
            Destroy(item[5]);
            Debug.Log("�A�C�e���ɓ�������");
        }       
        if (collision.gameObject.name == "Item (6)")
        {
            Destroy(item[6]);
            Debug.Log("�A�C�e���ɓ�������");
        }
    }
}
