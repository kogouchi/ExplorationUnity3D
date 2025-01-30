using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

//Text�̃A�N�e�B�u�A��A�N�e�B�u���̏���
//GameOverText�̕\���AClearText�̕\��
//���t���b�V�����[�g��ݒ�i�ݒ肷�邱�ƂŌy���Ȃ�炵���j
public class CameraManager : MonoBehaviour
{
    public PlayerController player;//�uPlayerController�v�̎Q��
    public EnemyController enemy;//�uEnemyController�v�̎Q��
    public SkyEnemyController[] skyEnemy;//SkyEnemyController�̎Q��
    public GameObject player_obj;//player�擾
    public GameObject enemy_obj;//enemmy�擾
    public Text tipsTextKey;//tipsTextKey�̎擾
    public GameObject tipsText;//TipsText�̎擾(F�L�[�������ꂽ��̉�ʎ擾)
    public Text MissionText;//missiontext�擾
    public Text clearText;//cleartext�擾
    public Text gameOverText;//gameovertext�擾
    public Text timeText;//timetext�擾
    public float countdown = 60;//�J�E���g�_�E��
    private bool flg = false;
    private bool eflg = false;//skyenemy���ׂē|���������true
    private bool tipsflg = false;//�Q�[���I�[�o�[�A�N���A��������ture

    #region �Q�l�T�C�g
    // �L�[���������тɐ؂�ւ���
    // https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g�̐ݒ�
        Cursor.visible = false;//�}�E�X�J�[�\���̔�\��

        //tips�e�L�X�g��\��
        tipsText.SetActive(true);//Tips�̕\��
        Time.timeScale = 0.0f;//�Q�[����~
        TipsTextSeting();//�e�L�X�g�̐ݒ�
        //MissionTextSeting();//�e�L�X�g�̐ݒ�
        MissionText.enabled = false;//�~�b�V�����e�L�X�g�̔�\��
    }

    // Update is called once per frame
    void Update()
    {
        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            //tipsTextKey���\�����̏ꍇ
            if (player.hp >= 0 && tipsflg == false)
                TipsTextManager();//TipsTextManager�̌Ăяo��
            //enemy����\���̏ꍇ
            if (!enemy_obj.activeInHierarchy)
            {
                tipsflg = true;//tips��\��
                clearText.gameObject.SetActive(true);//ClearText�\��
            }
            if (tipsflg == true)
            {
                tipsTextKey.gameObject.SetActive(false);//tipsTextKey��\��
                MissionText.gameObject.SetActive(false);//missionText��\��
            }
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            //tipsTextKey���\�����̏ꍇ
            if (player.hp >= 0 && tipsflg == false)
                TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            if (tipsflg == true)
            {
                tipsTextKey.gameObject.SetActive(false);//tipsTextKey��\��
                MissionText.gameObject.SetActive(false);//missionText��\��
            }
        }
        //gamescene3�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            //tipsTextKey���\�����̏ꍇ
            if (player.hp >= 0 && tipsflg == false)
                TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            SkyEnemy();
            if (tipsflg == true)
            {
                tipsTextKey.gameObject.SetActive(false);//tipsTextKey��\��
                MissionText.gameObject.SetActive(false);//missionText��\��
            }
            if (eflg == true)
            {
                Debug.Log("�G�l�~�[�����ׂē|����");
                clearText.gameObject.SetActive(true);//ClearText�\��
                Time.timeScale = 0.0f;
            }
        }
        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
        {
            //tipsTextKey���\�����̏ꍇ
            if (player.hp >= 0 && tipsflg == false)
                TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            SkyEnemy();
            if (tipsflg == true)
            {
                tipsTextKey.gameObject.SetActive(false);//tipsTextKey��\��
                MissionText.gameObject.SetActive(false);//missionText��\��
            }
            if(eflg == true)
            {
                Debug.Log("�G�l�~�[�����ׂē|����");
                clearText.gameObject.SetActive(true);//ClearText�\��
                Time.timeScale = 0.0f;
            }
        }
    }

    public void SkyEnemy()
    {
        //�J�E���g��0�ɂȂ����ꍇ
        if (timeText.text == "�������� �c��0�b")
        {
            //player�������c���Ă���ꍇ�{flg(���v���i��ł���ꍇ)
            if (player_obj.activeSelf && eflg == false)
            {
                GameOverManager();
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            if (skyEnemy[0] == false && skyEnemy[1] == false && skyEnemy[2] == false && skyEnemy[3] == false &&
                skyEnemy[4] == false && skyEnemy[5] == false && skyEnemy[6] == false)
            {
                eflg = true;
                tipsflg = true;//tips��\��
                Debug.Log("�G�l�~�[�����ׂē|����");
            }
        }
    }

    //TipsTextManager����
    public void TipsTextManager()
    {
        //F�L�[�������ꂽ�ꍇ+�e�L�X�g�L�[�����
        if (Input.GetKeyDown(KeyCode.F))
        {
            //UItext����\���̏ꍇ
            if (tipsText.activeSelf)
            {
                tipsText.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                tipsText.SetActive(true);
                Time.timeScale = 0.0f;
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
            Debug.Log(player.hptext.text);

            //�J�E���g��0�ɂȂ����ꍇ
            if (timeText.text == "�������� �c��0�b")
            {
                //player�������c���Ă���ꍇ�{flg(���v���i��ł���ꍇ)
                if (player_obj.activeSelf && flg == false &&
                    SceneManager.GetActiveScene().name == "GameScene2")
                {
                    flg = true;
                    tipsflg = true;//tips��\��
                    timeText.gameObject.SetActive(false);
                    clearText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
            //player��Hp��0�ɂȂ����ꍇ�{flg(���v���i��ł���ꍇ)
            if (player.hptext.text == "HP�@0/100" && flg == false)
            {
                flg = true;
                player.healthbar.gameObject.SetActive(false);
                player.hptext.gameObject.SetActive(false);
                GameOverManager();
                Time.timeScale = 0.0f;
            }
            //flg(���v���i��ł���ꍇ)
            if (flg == false)
            {
                countdown -= Time.timeScale / 60;//���Ԃ̃J�E���g�_�E��(�J�E���g�_�E���������������߁�60����)
                int cntdown = (int)countdown;
                timeText.text = "�������� �c��" + cntdown.ToString() + "�b";
                timeText.gameObject.SetActive(true);
            }

        }
    }

    //GameOverManager����
    public void GameOverManager()
    {
        tipsflg = true;//tips��\��
        gameOverText.gameObject.SetActive(true);//gameoverText�\��
        MissionText.gameObject.SetActive(false);//Mission�e�L�X�g��\��
    }


    /// <summary>
    /// TipsTextSeting����
    /// </summary>
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
        UItext.text = "������@\n�ړ��L�[�@ADWS";

        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "���̃A�C�e���Ńp���[�A�b�v!\n" +
                "�G���v���C���[�̕���������ΐF�ɕω�!\n" +
                "�F�̏�ԂœG�ɓːi����ƁA�G��|�����!\n" +
                "�p���[�A�b�v���ēG��|����!!";
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�������Ԃ��\�������!\n" +
                "�G��댯�ȃG���A���������悤!\n" +
                "�Ō�܂Ő����c�낤!";
        }
        //gamescene3�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�������Ԃ��\�������!\n" +
                "��C�ŁA���ׂĂ̓G��r�ł��悤!";
        }        
        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�댯�ȃG���A���瓦���悤!\n" +
                "��C�ŁA���ׂĂ̓G��r�ł��悤!\n" +
                "�Ō�܂Ő����c�낤!";
        }

        //�Sstage����
        Text Ftext = children[2].gameObject.GetComponent<Text>();
        Ftext.text = "F�L�[�ŕ���";
    }

    /// <summary>
    /// MissionTextSeting����
    /// </summary>
    public void MissionTextSeting()
    {
        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            if (player.power < enemy.power)
                MissionText.text = "�A�C�e�����E���ăp���[�A�b�v!";
            //else
            //    MissionText.text = "�ːi���ēG��|����!";
        }
        //gamescene2�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            MissionText.text = "�Ō�܂Ő����c�낤!";
        }
        //gamescene3�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            MissionText.text = "�G��|���A�Ō�܂Ő����c�낤!";
        }
        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
        {
            MissionText.text = "�G��|���A�Ō�܂Ő����c�낤!";
        }
    }
}