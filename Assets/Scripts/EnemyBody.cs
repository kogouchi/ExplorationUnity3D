using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//�A�C�e���ڐG����
public class EnemyBody : MonoBehaviour
{
    public Text EnemyPowerText;//EnemyPowerText�擾
    private int power = 1;//power(Item�l�����̌�)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyPowerText.text = "Power " + power;//EnemyPowerText�\���X�V
        //Enemy����\���ɂȂ����ꍇ
        if(!gameObject) EnemyPowerText.gameObject.SetActive(false);//EnemyPowerText��\��
    }
}