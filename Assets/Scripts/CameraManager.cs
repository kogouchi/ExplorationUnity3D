using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

//�V�[�����ƂɃR�[�h������Ƃ��ꂢ������

//MainCamera��CameraManager���A�^�b�`
//Text�̃A�N�e�B�u�A��A�N�e�B�u���̏���
//GameOverText�̕\���AClearText�̕\��
//���t���b�V�����[�g��ݒ�i�ݒ肷�邱�ƂŌy���Ȃ�炵���j
public class CameraManager : MonoBehaviour
{
    public PlayerController player;//�uPlayerController�v�̎Q��
    public EnemyController enemy;//�uEnemyController�v�̎Q��
    public SkyEnemyController skyEnemy;//SkyEnemyController�̎Q��
    public GameObject player_obj;//player�擾
    public GameObject enemy_obj;//enemmy�擾
    public GameObject tipsText;//TipsText�̎擾
    public Text MissionText;//missiontext�擾
    public Text clearText;//cleartext�擾
    public Text gameOverText;//gameovertext�擾
    public Text timeText;//timetext�擾
    public float countdown = 60;//�J�E���g�_�E��
    private bool flg = false;

    #region �Q�l�T�C�g
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g�̐ݒ�
        tipsText.SetActive(true);//Tips�̕\��
        Time.timeScale = 0.0f;//�Q�[����~
        TipsTextSeting();//�e�L�X�g�̐ݒ�
        MissionTextSeting();//�e�L�X�g�̐ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();//SceneChange�p

        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy) GameOverManager();
            //enemy����\���̏ꍇ
            if (!enemy_obj.activeInHierarchy)
            {
                clearText.gameObject.SetActive(true);//ClearText�\��
                Time.timeScale = 0.0f;
            }
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//time�e�L�X�g��\��
            }
        }
        //gamescene3�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//time�e�L�X�g��\��
            }
        }

        //gamescene5�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                GameOverManager();
                timeText.gameObject.SetActive(false);//time�e�L�X�g��\��
            }
            //enemy����\���̏ꍇ
            if (!enemy_obj.activeInHierarchy && timeText.text == "0�b")
            {
                clearText.gameObject.SetActive(true);//ClearText�\��
                Time.timeScale = 0.0f;
            }
        }
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

    //TimeManager�����@gamescene2
    public void TimeManager()
    {
        //tipsText���\���̏ꍇ
        if (tipsText.activeSelf) timeText.gameObject.SetActive(false);
        //tipsText����\���̏ꍇ
        else
        {
            //�J�E���g��0�ɂȂ����ꍇ
            if (timeText.text == "0�b")
            {
                //player�������c���Ă���ꍇ
                if (player_obj.activeSelf && !flg)
                {
                    flg = true;
                    timeText.gameObject.SetActive(false);
                    clearText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
            else
            {
                //player��Hp��0�ɂȂ����ꍇ
                if (player.hptext.text == "HP�@0/100" && !flg)
                {
                    flg = true;
                    player.healthbar.gameObject.SetActive(false);
                    player.hptext.gameObject.SetActive(false);
                    gameOverText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
                if (!flg)
                {
                    countdown -= Time.timeScale / 60;//���Ԃ̃J�E���g�_�E��(�J�E���g�_�E���������������߁�60����)
                    int cntdown = (int)countdown;
                    timeText.text = cntdown.ToString() + "�b";
                    timeText.gameObject.SetActive(true);
                }
            }

        }
    }

    //GameOverManager����
    public void GameOverManager()
    {
        gameOverText.gameObject.SetActive(true);//gameoverText�\��
        MissionText.gameObject.SetActive(false);//Mission�e�L�X�g��\��
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


        //gamescene5�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�G��S�ł����悤!\n" +
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


        //gamescene5�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            MissionText.text = "�G��|���A�Ō�܂Ő����c�낤!";
        }
    }

    //SceneChange�p
    public void SceneChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SceneManager.LoadScene("GameScene1");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("GameScene2");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SceneManager.LoadScene("GameScene5");
    }
}