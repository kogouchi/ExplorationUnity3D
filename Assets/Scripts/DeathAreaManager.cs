using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//DeathArea処理
public class DeathAreaManager : MonoBehaviour
{
    public PlayerController player;//player取得
    public Text damegetext;//damegetext取得
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

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            flg = true;
            damegetext.gameObject.SetActive(true);//damage表示
        }
    }

    //オブジェクト同士が離れた場合
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            flg = false;
            damegetext.gameObject.SetActive(false);//damage非表示
        }
    }

}
