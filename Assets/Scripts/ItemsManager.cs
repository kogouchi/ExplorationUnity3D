using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public GameObject[] items;//���ׂĂ�Item�擾
    public float displayDelay = 5.0f;//�\���܂ł̎���

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //��\���ɂȂ����ꍇ
        if (!items[0].activeSelf) StartCoroutine(ItemActive());
        if (!items[1].activeSelf) StartCoroutine(ItemActive1());
        if (!items[2].activeSelf) StartCoroutine(ItemActive2());
        if (!items[3].activeSelf) StartCoroutine(ItemActive3());
        if (!items[4].activeSelf) StartCoroutine(ItemActive4());

    }

    public IEnumerator ItemActive()
    {
        yield return new WaitForSeconds(displayDelay);
        //��莞�Ԍo�߂�����I�u�W�F�N�g��\��
        items[0].SetActive(true);
        //Debug.Log("Item�\��");
    }
    public IEnumerator ItemActive1()
    {
        yield return new WaitForSeconds(displayDelay);
        //��莞�Ԍo�߂�����I�u�W�F�N�g��\��
        items[1].SetActive(true);
        //Debug.Log("Item1�\��");
    }
    public IEnumerator ItemActive2()
    {
        yield return new WaitForSeconds(displayDelay);
        //��莞�Ԍo�߂�����I�u�W�F�N�g��\��
        items[2].SetActive(true);
        //Debug.Log("Item2�\��");
    }
    public IEnumerator ItemActive3()
    {
        yield return new WaitForSeconds(displayDelay);
        //��莞�Ԍo�߂�����I�u�W�F�N�g��\��
        items[3].SetActive(true);
        //Debug.Log("Item3�\��");
    }
    public IEnumerator ItemActive4()
    {
        yield return new WaitForSeconds(displayDelay);
        //��莞�Ԍo�߂�����I�u�W�F�N�g��\��
        items[4].SetActive(true);
        //Debug.Log("Item4�\��");
    }

}
