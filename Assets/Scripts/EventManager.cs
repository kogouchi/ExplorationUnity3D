using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//���󓮍�o���Ă��Ȃ���
public class EventManager : MonoBehaviour
{
    public GameObject player;//player�擾
    public GameObject enemy;//enemmy�擾
    public Text MissionText;//missiontext�擾
    public Text clearText;//cleartext�擾
    public Text gameOverText;//gameovertext�擾

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player����\���̏ꍇ
        if(player == false) gameOverText.gameObject.SetActive(true);//gameoverText�\��
        //enemy����\���̏ꍇ
        if (enemy == false) clearText.gameObject.SetActive(true);//ClearText�\��
    }
}
