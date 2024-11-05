using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public GameObject[] items;//すべてのItem取得
    public float displayDelay = 5.0f;//表示までの時間

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //非表示になった場合
        if (!items[0].activeSelf) StartCoroutine(ItemActive());
        if (!items[1].activeSelf) StartCoroutine(ItemActive1());
        if (!items[2].activeSelf) StartCoroutine(ItemActive2());
        if (!items[3].activeSelf) StartCoroutine(ItemActive3());
        if (!items[4].activeSelf) StartCoroutine(ItemActive4());

    }

    public IEnumerator ItemActive()
    {
        yield return new WaitForSeconds(displayDelay);
        //一定時間経過したらオブジェクトを表示
        items[0].SetActive(true);
        //Debug.Log("Item表示");
    }
    public IEnumerator ItemActive1()
    {
        yield return new WaitForSeconds(displayDelay);
        //一定時間経過したらオブジェクトを表示
        items[1].SetActive(true);
        //Debug.Log("Item1表示");
    }
    public IEnumerator ItemActive2()
    {
        yield return new WaitForSeconds(displayDelay);
        //一定時間経過したらオブジェクトを表示
        items[2].SetActive(true);
        //Debug.Log("Item2表示");
    }
    public IEnumerator ItemActive3()
    {
        yield return new WaitForSeconds(displayDelay);
        //一定時間経過したらオブジェクトを表示
        items[3].SetActive(true);
        //Debug.Log("Item3表示");
    }
    public IEnumerator ItemActive4()
    {
        yield return new WaitForSeconds(displayDelay);
        //一定時間経過したらオブジェクトを表示
        items[4].SetActive(true);
        //Debug.Log("Item4表示");
    }

}
