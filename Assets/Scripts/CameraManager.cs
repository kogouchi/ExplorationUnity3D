using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

//MainCamera��CameraManager���A�^�b�`+TipsText��ǉ�
//TipsText�̃A�N�e�B�u�A��A�N�e�B�u���̏���
//GameOverText�̕\���AClearText�̕\��
public class CameraManager : MonoBehaviour
{
    public GameObject player;//player�擾
    public GameObject enemy;//enemmy�擾
    public GameObject tipsText;//TipsText�̎擾
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
        //Player�\�����Ă���ꍇ
        //if(player.activeInHierarchy)
        //{
        //    transform.position = new Vector3(player.transform.position.x,
        //        player.transform.position.y,
        //        player.transform.position.z);
        //}

        //gamescene1�������ꍇ
        if(SceneManager.GetActiveScene().name == "GameScene1")
        {
            MissionText.text = "�A�C�e�����E���ăp���[�A�b�v!";
            TipsTextManager();//TipsTextManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player.activeInHierarchy)
            {
                gameOverText.gameObject.SetActive(true);//gameoverText�\��
                MissionText.gameObject.SetActive(false);//Mission�e�L�X�g��\��
            }
            //enemy����\���̏ꍇ
            if (!enemy.activeInHierarchy) clearText.gameObject.SetActive(true);//ClearText�\��
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            MissionText.text = "�������т悤!";
        }
        //gamescene3�������ꍇ
        //if (SceneManager.GetActiveScene().name == "GameScene3")
        //{
        //
        //}
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