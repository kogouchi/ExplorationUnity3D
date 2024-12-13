using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemyController : MonoBehaviour
{
    public int cnt = 0;
    public GameObject particleEffect;//死んだ時のエフェクト取得
    public AudioClip audioClip;//音源格納
    private AudioSource audioSource;//音源入れるもの
    private bool effectflg = false;//effectフラグ

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator EnemyActive()
    {
        Destroy(gameObject, 0.2f);
        yield return new WaitForSeconds(5.0f);//displayDelay分待つ
    }

    //オブジェクトが衝突した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            //Debug.Log("エネミーを倒した");
            //エフェクトは1度のみ再生
            if (effectflg == false)
            {
                Instantiate(particleEffect, transform.position, transform.rotation);//Effect再生
                effectflg = true;
            }
            StartCoroutine(EnemyActive());//コルーチン開始
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
    }
}
