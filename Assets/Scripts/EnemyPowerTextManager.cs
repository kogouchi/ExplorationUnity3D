using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//テキスト表示で使用

//EnemyPowerText追加
public class EnemyPowerTextManager : MonoBehaviour
{
    public EnemyController enemyController;//EnemyController参照
    public Text EnemyPowerText;//EnemyPowerText取得

    // Start is called before the first frame update
    void Start()
    {
        //Power初期値
        EnemyPowerText.text = "EnemyPower" + enemyController.power;
    }

    // Update is called once per frame
    void Update()
    {
        //Power値更新
        EnemyPowerText.text = "EnemyPower" + enemyController.power;
    }
}