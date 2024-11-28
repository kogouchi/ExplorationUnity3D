using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

public class MapController : MonoBehaviour
{
    //�e�{�^���̊i�[
    public Button s1button;
    public Button s2button;
    public Button s3button;
    public Button s4button;

    public AudioClip[] audioClips;//�����i�[
    private AudioSource audioSource;//�������߂̉������������

    //�t���O�p
    private int buttonflg = 0;
    private bool keyflg = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
        s1button.Select();//�t�H�[�J�X�ύX
    }

    // Update is called once per frame
    void Update()
    {
        MapChange();
    }

    //Map�؂�ւ�
    public void MapChange()
    {
        //S�L�[�������ꂽ�ꍇ(flg�Ń{�^���̈ʒu��ύX+flg��4�������ꍇ�������Ȃ�)
        if (Input.GetKeyDown(KeyCode.S) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 0:
                    s2button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
                case 1:
                    s3button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
                case 2:
                    s4button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg++;
                    break;
            }
            Debug.Log(buttonflg);
        }
        else keyflg = false;

        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 3:
                    s3button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
                case 2:
                    s2button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
                case 1:
                    s1button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    buttonflg--;
                    break;
            }
            Debug.Log(buttonflg);
        }
        else keyflg = false;

        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space) && keyflg == false)
        {
            keyflg = true;
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == 0) SceneManager.LoadScene("GameScene1");//GameScene1�ɐ؂�ւ�
            if (buttonflg == 1) SceneManager.LoadScene("GameScene2");//GameScene2�ɐ؂�ւ�
            if (buttonflg == 2) SceneManager.LoadScene("GameScene3");//GameScene3�ɐ؂�ւ�
            if (buttonflg == 3) SceneManager.LoadScene("GameScene4");//GameScene4�ɐ؂�ւ�
        }
        else keyflg = false;

        //R�L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.R) && keyflg == false)
        {
            keyflg = true;
            if (buttonflg == 0) SceneManager.LoadScene("TitleScene");//TitleScene�ɐ؂�ւ�
        }
        else keyflg = false;
    }
}
