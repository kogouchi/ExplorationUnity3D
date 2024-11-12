using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

//MainCamera��CameraManager���A�^�b�`+TipsText��ǉ�
//TipsText�̃A�N�e�B�u�A��A�N�e�B�u���̏���
//GameOverText�̕\���AClearText�̕\��
public class CameraManager : MonoBehaviour
{
    public GameObject tipsText;//TipsText�̎擾
    public GameObject player;//player�擾
    public GameObject enemy;//enemmy�擾
    public Text MissionText;//missiontext�擾
    public Text clearText;//cleartext�擾
    public Text gameOverText;//gameovertext�擾


    #region �Q�l�T�C�g
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tipsText.SetActive(true);//Tips�̕\��
        Time.timeScale = 0.0f;//�Q�[����~
    }

    // Update is called once per frame
    void Update()
    {
        TipsTextManager();//TipsTextManager�̌Ăяo��
        //player����\���̏ꍇ
        if (!player.activeInHierarchy) gameOverText.gameObject.SetActive(true);//gameoverText�\��
        //enemy����\���̏ꍇ
        if (!enemy.activeInHierarchy) clearText.gameObject.SetActive(true);//ClearText�\��
    }

    //TipsTextManager����
    public void TipsTextManager()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //UItext����\���̏ꍇ
            if (tipsText.activeSelf)
            {
                tipsText.SetActive(false);
                Time.timeScale = 1.0f;
                //Debug.Log("�Q�[���Đ�");
            }
            else
            {
                tipsText.SetActive(true);
                Time.timeScale = 0.0f;
                //Debug.Log("�Q�[����~");
            }
        }
    }
}