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
    public SkyEnemyController[] skyEnemy;//SkyEnemyController�̎Q��
    public GameObject player_obj;//player�擾
    public GameObject enemy_obj;//enemmy�擾
    public GameObject tipsTextKey;//tipsTextKey�̎擾
    public GameObject tipsText;//TipsText�̎擾(F�L�[�������ꂽ��̉�ʎ擾)
    public Text MissionText;//missiontext�擾
    public Text clearText;//cleartext�擾
    public Text gameOverText;//gameovertext�擾
    public Text timeText;//timetext�擾
    public float countdown = 60;//�J�E���g�_�E��
    private bool flg = false;
    private bool eflg = false;
    private bool tipsFlg = false;//tips�e�L�X�g�p(�Q�[���N���A�A�Q�[���I�[�o�[�ȊO�̎���false)

    #region �Q�l�T�C�g
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //����
        //�e�I�u�W�F�N�g���擾�����̂��A���̒l��p���ăe�L�X�g�\���ύX
        //�R�[�h��ǂ����遫
        //�錾�{C���Q�Ɓ{������ �� update�������C#�ōs��
        //�܂��A�e���ꂼ���C#���͕�����悤�ɕύX������
        //���ŏI�I�ɂ̓J�����Ɏ������鐫���Ȃ����߁A��̃I�u�W�F�N�g�Ɏ�������

        Application.targetFrameRate = 60;//�t���[�����[�g�̐ݒ�
        
        //tips�e�L�X�g��\��
        tipsText.SetActive(true);//Tips�̕\��
        Time.timeScale = 0.0f;//�Q�[����~
        TipsTextSeting();//�e�L�X�g�̐ݒ�
        MissionTextSeting();//�e�L�X�g�̐ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        //SceneChange();//SceneChange�p(�R�}���h�p)

        //gamescene1�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene1")
        {
            if(tipsFlg == false)
                TipsTextManager();//TipsTextManager�̌Ăяo��

            //player����\���̏ꍇ
            if (!player_obj.activeInHierarchy)
            {
                tipsFlg = true;//�e�L�X�g�L�[����s��
                GameOverManager();
            }
            //enemy����\���̏ꍇ
            if (!enemy_obj.activeInHierarchy)
            {
                tipsFlg = true;//�e�L�X�g�L�[����s��
                clearText.gameObject.SetActive(true);//ClearText�\��
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
            SkyEnemy();
        }

        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
        {
            TipsTextManager();//TipsTextManager�̌Ăяo��
            TimeManager();//TimeManager�̌Ăяo��
            SkyEnemy();
        }
    }

    public void SkyEnemy()
    {
        if (skyEnemy[0] == false && skyEnemy[1] == false && skyEnemy[2] == false && skyEnemy[3] == false &&
            skyEnemy[4] == false && skyEnemy[5] == false && skyEnemy[6] == false)
        {
            eflg = true;
            Debug.Log("�G�l�~�[�����ׂē|����");
            clearText.gameObject.SetActive(true);//ClearText�\��
            Time.timeScale = 0.0f;
        }
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
    }

    //TipsTextManager����
    public void TipsTextManager()
    {
        //tipsTextKey���\�����̏ꍇ
        //if(tipsTextKey.activeInHierarchy)
        if (player.hp >= 0)
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
            if (timeText.text == "�������� �c��0�b")
            {
                //player�������c���Ă���ꍇ�{flg(���v���i��ł���ꍇ)
                if (player_obj.activeSelf && flg == false &&
                    SceneManager.GetActiveScene().name == "GameScene2")
                {
                    flg = true;
                    tipsFlg = true;//�e�L�X�g�L�[����s��
                    timeText.gameObject.SetActive(false);
                    clearText.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
            //player�������c���Ă��Ȃ��ꍇ
            else
            {
                //player��Hp��0�ɂȂ����ꍇ�{flg(���v���i��ł���ꍇ)
                if (player.hptext.text == "HP�@0/100" && flg == false)
                {
                    Debug.Log("hp 0");
                    flg = true;
                    player.healthbar.gameObject.SetActive(false);
                    player.hptext.gameObject.SetActive(false);
                    GameOverManager();
                    Time.timeScale = 0.0f;
                }
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
                "�G��댯�ȃG���A���������悤!\n" +
                "�Ō�܂Ő����c�낤!";
        }
        //gamescene3�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�������Ԃ��\�������!\n" +
                "��C�ł��ׂĂ̓G��r�ł��悤!";
        }        
        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
        {
            Text Mtext = children[1].gameObject.GetComponent<Text>();
            Mtext.text = "�y�~�b�V�����z\n" +
                "�댯�ȃG���A���瓦���悤!\n" +
                "��C�ł��ׂĂ̓G��r�ł��悤!\n" +
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
        //gamescene4�������ꍇ
        if (SceneManager.GetActiveScene().name == "GameScene4")
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
            SceneManager.LoadScene("GameScene4");
    }
}