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
    public PlayerController player;//�uPlayerController�v�̎Q��
    public EnemyController enemy;//�uEnemyController�v�̎Q��
    public GameObject player_obj;//player�擾
    public GameObject enemy_obj;//enemmy�擾
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
        TipsTextSeting();//�e�L�X�g�̐ݒ�
        MissionTextSeting();//�e�L�X�g�̐ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        //gamescene1�������ꍇ
        if(SceneManager.GetActiveScene().name == "GameScene1")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                gameOverText.gameObject.SetActive(true);//gameoverText�\��
                MissionText.gameObject.SetActive(false);//Mission�e�L�X�g��\��
            }
            //enemy����\���̏ꍇ
            if (!enemy_obj.activeInHierarchy) clearText.gameObject.SetActive(true);//ClearText�\��
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                gameOverText.gameObject.SetActive(true);//gameoverText�\��
                MissionText.gameObject.SetActive(false);//Mission�e�L�X�g��\��
            }
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
        //F�L�[�������ꂽ�ꍇ
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

    //TipsTextSeting����
    public void TipsTextSeting()
    {
        var tipsTextTransform = tipsText.transform;//tipsText��Transform�擾
        var children = new GameObject[tipsTextTransform.childCount];//�q�I�u�W�F�N�g���i�[����z��쐬

        //�q�I�u�W�F�N�g��z��Ɋi�[
        for(var i = 0; i< children.Length; ++i)
            //Transform����Q�[���I�u�W�F�N�g���擾���Ċi�[
            children[i] = tipsTextTransform.GetChild(i).gameObject;

        //�Sstage����
        Text UItext = children[0].gameObject.GetComponent<Text>();
        UItext.text = "������@\n�ړ��L�[�@ADWS ��������";

        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "���F�̃A�C�e���Ńp���[�A�b�v!\n" +
                "�G���v���C���[�̕���������ΐF�ɕω�!\n" +
                "�G��|���΃N���A!";
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�������Ԃ��\�������!\n" +
                "�Ō�܂Ő����c�낤!";
        }

        //�Sstage����
        Text Ftext = children[2].gameObject.GetComponent<Text>();
        Ftext.text = "F�L�[�ŕ���";
    }

    //MissionTextSeting����
    public void MissionTextSeting()
    {
        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            if (player.power < enemy.power)
                MissionText.text = "�A�C�e�����E���ăp���[�A�b�v!";
            else
                MissionText.text = "�ːi���ēG��|����!";
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            MissionText.text = "�Ō�܂Ő����c�낤!";
        }
    }
}