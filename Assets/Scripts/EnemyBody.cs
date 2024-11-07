using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//アイテム接触判定
public class EnemyBody : MonoBehaviour
{
    public Text EnemyPowerText;//EnemyPowerText取得
    private int power = 1;//power(Item獲得時の個数)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyPowerText.text = "Power " + power;//EnemyPowerText表示更新
        //Enemyが非表示になった場合
        if(!gameObject) EnemyPowerText.gameObject.SetActive(false);//EnemyPowerText非表示
    }
}