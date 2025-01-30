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
    public Text timeText;//timetext取得
    public Text damegetext;//damegetext取得
    public GameObject DeathAreaEffect;//DeathAreaEffect取得

    private bool hpflg = false;//hp減少フラグ
    private bool trSChangeflg = false;//transform.Scaleフラグ(一度のみ処理が行われるように変更する)
    private float objSize = 0.2f;//Scale変更値
    private bool tipsflg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //デスエリアにいる状態＋TipsText表示時、hpを減らさないようにするためにする
        if (Time.timeScale == 0.0f)
        {
            tipsflg = true;
            damegetext.gameObject.SetActive(false);//damage非表示
        }
        else tipsflg = false;
        if (hpflg == true && tipsflg == false) player.hp -= 0.5f;
        if(player.hp == 0) damegetext.gameObject.SetActive(false);//damage非表示
        AreaScaleChange();//AreaScale変更処理
    }

    //AreaScale変更処理
    public void AreaScaleChange()
    {
        //カウントが0になった場合
        if (timeText.text == "制限時間 残り30秒" && 
            timeText.text != "制限時間 残り0秒" &&
            trSChangeflg == false)
        {
            trSChangeflg = true;
            //Scaleを徐々に大きくしていく
            StartCoroutine(ScaleUp());
        }
    }

    public IEnumerator ScaleUp()
    {
        Vector3 trS = DeathAreaEffect.transform.localScale;//現在のScale取得
        Vector3 mytrS = transform.localScale;

        //最大Scale数より下回る場合               //最大値↓
        for (/*初期化は上で行っているため不要*/; trS.x < 2.0f;
            trS.x += objSize, trS.y += objSize, 
            mytrS.x = mytrS.x + 0.1f, mytrS.y = mytrS.y + 0.1f)
        {
            DeathAreaEffect.transform.localScale = new Vector3(trS.x, trS.y, trS.z);//Scaleの代入
            transform.localScale = new Vector3(mytrS.x, mytrS.y, mytrS.z);
            //Debug.Log("Scaleの拡大中");
            yield return new WaitForSeconds(1.5f);//()秒後待つ
        }
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp >= 0)
        {
            hpflg = true;
            damegetext.gameObject.SetActive(true);//damage表示
        }
    }

    //オブジェクト同士が離れた場合
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp >= 0)
        {
            hpflg = false;
            damegetext.gameObject.SetActive(false);//damage非表示
        }
    }

    //オブジェクトが接触中の場合（プレイヤーと接触中＋tipstext表示のち、ゲーム画面に戻る際のdamagetext表示）
    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && tipsflg == false)
        {
            damegetext.gameObject.SetActive(true);//damage表示
        }
    }
}
