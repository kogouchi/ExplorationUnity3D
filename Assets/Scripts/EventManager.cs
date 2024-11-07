using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//現状動作出来ていない↓
public class EventManager : MonoBehaviour
{
    public GameObject player;//player取得
    public GameObject enemy;//enemmy取得
    public Text MissionText;//missiontext取得
    public Text clearText;//cleartext取得
    public Text gameOverText;//gameovertext取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerが非表示の場合
        if(player == false) gameOverText.gameObject.SetActive(true);//gameoverText表示
        //enemyが非表示の場合
        if (enemy == false) clearText.gameObject.SetActive(true);//ClearText表示
    }
}
