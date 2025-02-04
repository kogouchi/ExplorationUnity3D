using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���Ŏg�p
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p

public class SystemManager : MonoBehaviour
{
    public GameObject tipsText;//tips�e�L�X�g
    public GameObject clearText;//Clear�e�L�X�g
    public GameObject GameoverText;//GameOvew�e�L�X�g
    public GameObject settingText;//Setting�e�L�X�g
    public AudioSource audioSource;//�������߂̉������������
    public AudioClip[] audioClips;//�����i�[
    public Button playbutton;//������{�^��
    public Button restartbutton;//���g���C�{�^��
    public Button endbutton;//end�{�^��

    private int buttonflg = 0;//�e�{�^���̔ԍ��U�蕪���t���O(�����Ȃ̂�int)
    private bool keyflg = false;//�{�^����������Ă��邩�ǂ����t���O

    // Start is called before the first frame update
    void Start()
    {
        settingText.SetActive(false);//�ݒ��ʔ�\��
        playbutton.Select();//�n�߂ɑI������Ă���
    }

    // Update is called once per frame
    void Update()
    {
        if(!tipsText.activeInHierarchy)
        {
            SettingManager();
            SelectChange();
        }

        if (clearText.activeInHierarchy)
        {
            audioSource.Stop();//�I�[�f�B�I�\�[�X�̒�~
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("MapScene");//MapScene�ɐ؂�ւ�
        }
        if (GameoverText.activeInHierarchy)
        {
            audioSource.Stop();//�I�[�f�B�I�\�[�X�̒�~
            //if (Input.GetKeyDown(KeyCode.Space))
            //    SceneManager.LoadScene("MapScene");//MapScene�ɐ؂�ւ�
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (SceneManager.GetActiveScene().name == "GameScene1")
                    SceneManager.LoadScene("GameScene1");//GameScene1�ɐ؂�ւ�
                if (SceneManager.GetActiveScene().name == "GameScene2")
                    SceneManager.LoadScene("GameScene2");//GameScene2�ɐ؂�ւ�
                if (SceneManager.GetActiveScene().name == "GameScene3")
                    SceneManager.LoadScene("GameScene3");//GameScene3�ɐ؂�ւ�
                if (SceneManager.GetActiveScene().name == "GameScene4")
                    SceneManager.LoadScene("GameScene4");//GameScene4�ɐ؂�ւ�
            }
        }
    }

    /// <summary>
    /// �ݒ��ʂ̕\��
    /// </summary>
    void SettingManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playbutton.Select();//�N���Ƌ��ɃZ���N�g�ꏊ�����Z�b�g
            settingText.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    
    /// <summary>
    /// �{�^���Z���N�g
    /// </summary>
    void SelectChange()
    {
        //�L�[�������ꂽ�ꍇ
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) keyflg = false;

        //S�L�[�������ꂽ�ꍇ(flg�Ń{�^���̈ʒu��ύX+flg��4�������ꍇ�������Ȃ�)
        if (Input.GetKeyDown(KeyCode.S) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 0:
                    restartbutton.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    restartbutton.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    endbutton.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    endbutton.interactable = true;
                    buttonflg = 2;
                    break;
            }
        }

        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 2:
                    restartbutton.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    restartbutton.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    playbutton.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    playbutton.interactable = true;
                    buttonflg = 0;
                    break;
            }
        }

        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space) && keyflg == false)
        {
            keyflg = true;
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == 0)
            {
                settingText.SetActive(false);
                Time.timeScale = 1.0f;
            }
            if (buttonflg == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);//���݂̃V�[���ă��[�h
            if (buttonflg == 2) SceneManager.LoadScene("TitleScene");//TitleScene�ɐ؂�ւ�
        }
    }
}
