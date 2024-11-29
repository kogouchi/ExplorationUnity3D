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
    public CameraManager cameraManager;//CameraManager参照
    public Text damegetext;//damegetext取得
    private bool hpflg = false;//hp減少フラグ
    private bool trSChangeflg = false;//transform.Scaleフラグ(一度のみ処理が行われるように変更する)
    private float objSize = 0.2f;//Scale変更値

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hpflg) player.hp -= 1.0f;
        if(player.hp == 0) damegetext.gameObject.SetActive(false);//damage非表示
        AreaScaleChange();//AreaScale変更処理
    }

    //AreaScale変更処理
    public void AreaScaleChange()
    {
        //カウントが0になった場合
        if (cameraManager.timeText.text == "30秒" && 
            cameraManager.timeText.text != "0秒"  &&
            trSChangeflg == false)
        {
            trSChangeflg = true;
            //Scaleを徐々に大きくしていく
            StartCoroutine(ScaleUp());
        }
    }

    public IEnumerator ScaleUp()
    {
        Vector3 trS = this.transform.localScale;//現在のScale取得

        //最大Scale数より下回る場合               //最大値↓
        for (/*初期化は上で行っているため不要*/; trS.x < 7.0f; trS.x += objSize, trS.y += objSize)
        {
            this.transform.localScale = new Vector3(trS.x, trS.y, trS.z);//Scaleの代入
            //Debug.Log("Scaleの拡大中");
            yield return new WaitForSeconds(1.5f);//()秒後待つ
        }
    }

    //オブジェクト同士が接触した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            hpflg = true;
            damegetext.gameObject.SetActive(true);//damage表示
        }
    }

    //オブジェクト同士が離れた場合
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.hp != 0)
        {
            hpflg = false;
            damegetext.gameObject.SetActive(false);//damage非表示
        }
    }

}
