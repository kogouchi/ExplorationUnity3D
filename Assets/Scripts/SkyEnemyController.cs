using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemyController : MonoBehaviour
{
    public int cnt = 0;
    public AudioClip audioClip;//音源格納
    private AudioSource audioSource;//音源入れるもの

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
    }

    // Update is called once per frame
    void Update()
    {

    }

    //オブジェクトが衝突した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            //Debug.Log("エネミーを倒した");
            Destroy(gameObject, 0.6f);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
    }
}
