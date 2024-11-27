using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p
using UnityEngine.EventSystems;//�t�H�[�J�X�ύX���g�p

public class ScenesController : MonoBehaviour
{
    public Button startButton;//startButton�̎擾
    public Button endButton;//endButton�̎擾
    public Button s1Button;//s1Button�̎擾
    public Button s2Button;//s2Button�̎擾
    public Button s3Button;//s3Button�̎擾
    public Button s4Button;//s4Button�̎擾
    private int flg = 0;//flg�؂�ւ�(Title�Astage�̉�ʐ؂�ւ����p)

    // Start is called before the first frame update
    void Start()
    {
        startButton = startButton.GetComponent<Button>();//button�擾
        endButton = endButton.GetComponent<Button>();//button�擾
        s1Button = s1Button.GetComponent<Button>();//s1button�擾
        s2Button = s2Button.GetComponent<Button>();//s2button�擾
        s3Button = s3Button.GetComponent<Button>();//s3button�擾
        s4Button = s4Button.GetComponent<Button>();//s4button�擾
        EventSystem.current.SetSelectedGameObject(null);//�S�Ẵt�H�[�J�X������
        //TitleScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "TitleScene")
            startButton.Select();//startButton�Ƀt�H�[�J�X����
        //MapScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "MapScene")
            s1Button.Select();//s1Button�Ƀt�H�[�J�X����
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Title�؂�ւ�
    public void TitleChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            flg = 1;
            endButton.Select();//endButton�Ƀt�H�[�J�X����
            Debug.Log("�I���{�^���I��");
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = 0;
            startButton.Select();//startButton�Ƀt�H�[�J�X����
            Debug.Log("�J�n�{�^���I��");
        }
        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0)
                SceneManager.LoadScene("MapScene");//MapScene�ɐ؂�ւ�
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��(�Q�[���G���W���ŋN����)
#else
            Application.Quit();//�Q�[���I��(�r���h�ŋN����)
#endif
            }
        }
    }

    //Map�؂�ւ�
    public void MapChange()
    {
        //S�L�[�������ꂽ�ꍇ(flg�Ń{�^���̈ʒu��ύX+flg��4�������ꍇ�������Ȃ�)
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (flg)
            {
                case 0:
                    s2Button.Select();//s2Button�Ƀt�H�[�J�X����
                    flg++;
                    Debug.Log("s2�{�^���I��");
                    break;
                case 1:
                    s3Button.Select();//s3Button�Ƀt�H�[�J�X����
                    flg++;
                    Debug.Log("s3�{�^���I��");
                    break;
                case 2:
                    s4Button.Select();//s4Button�Ƀt�H�[�J�X����
                    flg++;
                    Debug.Log("s4�{�^���I��");
                    break;
            }
            Debug.Log(flg);
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch(flg)
            {
                case 3:
                    s3Button.Select();//s3Button�Ƀt�H�[�J�X����
                    flg--;
                    Debug.Log("s3�{�^���I��");
                    break;
                case 2:
                    s2Button.Select();//s2Button�Ƀt�H�[�J�X����
                    flg--;
                    Debug.Log("s2�{�^���I��");
                    break;
                case 1:
                    s1Button.Select();//s1Button�Ƀt�H�[�J�X����
                    flg--;
                    Debug.Log("s1�{�^���I��");
                    break;
            }
            Debug.Log(flg);
        }
        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0) SceneManager.LoadScene("GameScene1");//GameScene1�ɐ؂�ւ�
            if (flg == 1) SceneManager.LoadScene("GameScene2");//GameScene2�ɐ؂�ւ�
            if (flg == 2) SceneManager.LoadScene("GameScene3");//GameScene3�ɐ؂�ւ�
            if (flg == 3) SceneManager.LoadScene("GameScene4");//GameScene4�ɐ؂�ւ�
        }
    }
}