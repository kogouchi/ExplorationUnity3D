using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//EnemyPowerText�ǉ�
public class EnemyPowerTextManager : MonoBehaviour
{
    public EnemyController enemyController;//EnemyController�Q��
    public Text EnemyPowerText;//EnemyPowerText�擾

    // Start is called before the first frame update
    void Start()
    {
        //Power�����l
        EnemyPowerText.text = "EnemyPower" + enemyController.power;
    }

    // Update is called once per frame
    void Update()
    {
        //Power�l�X�V
        EnemyPowerText.text = "EnemyPower" + enemyController.power;
    }
}