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
    private int buttonflg = 0;//�e�{�^���̔ԍ��U�蕪���p
    private bool keyflg = false;//�{�^����������Ă��邩�ǂ����p
    private static bool startflg = false;//����̂ݎ��s����p

    #region �Q�l�T�C�g
    // �l�����n��
    // https://qiita.com/Akarinnn/items/00f58b7cbc7c5d659d92
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
        s1button.Select();//�t�H�[�J�X�ύX
        Cursor.visible = false;//�}�E�X�J�[�\���̔�\��
        
        //�����x�̂ݎ��s
        if(startflg == false)
        {
            //Debug.Log("������");
            startflg = true;
            s1button.interactable = true;
            s2button.interactable = false;
            s3button.interactable = false;
            s4button.interactable = false;
        }
        else
        {
            //Debug.Log("2�ڂ̃X�e�[�W�ȍ~");
            //�N���A���邲�Ƃɒl���Ă�(CameraManager.cs���Q��)
            s1button.interactable = true;
            s2button.interactable = CameraManager.s2;
            s3button.interactable = CameraManager.s3;
            s4button.interactable = CameraManager.s4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MapChange();
    }

    /// <summary>
    /// �X�e�[�W�I�����̃L�[�̊��蓖��
    /// </summary>
    public void MapChange()
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
                    if(s2button.interactable == false) s1button.Select();
                    else
                    {
                        s2button.Select();//�t�H�[�J�X�ύX
                        audioSource.PlayOneShot(audioClips[1]);
                        s2button.interactable = true;
                        buttonflg = 1;
                    }
                    break;
                case 1:
                    if(s3button.interactable == false) s2button.Select();
                    else
                    {
                        s3button.Select();//�t�H�[�J�X�ύX
                        audioSource.PlayOneShot(audioClips[1]);
                        s3button.interactable = true;
                        buttonflg = 2;
                    }
                    break;
                case 2:
                    if(s4button.interactable == false) s3button.Select();
                    else
                    {
                        s4button.Select();//�t�H�[�J�X�ύX
                        audioSource.PlayOneShot(audioClips[1]);
                        s4button.interactable = true;
                        buttonflg = 3;
                    }
                    break;
            }
        }

        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W) && keyflg == false)
        {
            keyflg = true;
            switch (buttonflg)
            {
                case 3:
                    s3button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    s3button.interactable = true;
                    buttonflg = 2;
                    break;
                case 2:
                    s2button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    s2button.interactable = true;
                    buttonflg = 1;
                    break;
                case 1:
                    s1button.Select();//�t�H�[�J�X�ύX
                    audioSource.PlayOneShot(audioClips[1]);
                    s1button.interactable = true;
                    buttonflg = 0;
                    break;
            }
        }

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

        //R�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.R) && keyflg == false)
        {
            keyflg = true;
            if (buttonflg == 0 || buttonflg == 1 || buttonflg == 2 || buttonflg == 3) 
                SceneManager.LoadScene("TitleScene");//TitleScene�ɐ؂�ւ�
        }
    }
}
