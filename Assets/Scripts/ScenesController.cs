using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p
using UnityEngine.EventSystems;//�t�H�[�J�X�ύX���g�p

//Title��Map�̐؂�ւ��{�eSound�ݒ�
public class ScenesController : MonoBehaviour
{
    public Button[] button;
    private int flg = 0;//flg�؂�ւ�(Title�Astage�̉�ʐ؂�ւ����p)

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);//�S�Ẵt�H�[�J�X������
        //TitleScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "TitleScene")
            button[0].Select();//�t�H�[�J�X�ύX
        //MapScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "MapScene")
            button[2].Select();//�t�H�[�J�X�ύX
    }

    // Update is called once per frame
    void Update()
    {
        TitleChange();
        MapChange();
    }

    //Title�؂�ւ�
    public void TitleChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            flg = 0;
            button[1].Select();
            Debug.Log(flg);
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = 1;
            button[0].Select();
            Debug.Log(flg);
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
                    button[3].Select();//�t�H�[�J�X�ύX
                    flg++;
                    break;
                case 1:
                    button[4].Select();//�t�H�[�J�X�ύX
                    flg++;
                    break;
                case 2:
                    button[5].Select();//�t�H�[�J�X�ύX
                    flg++;
                    break;
            }
            Debug.Log(flg);
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (flg)
            {
                case 3:
                    button[4].Select();//�t�H�[�J�X�ύX
                    flg--;
                    break;
                case 2:
                    button[3].Select();//�t�H�[�J�X�ύX
                    flg--;
                    break;
                case 1:
                    button[2].Select();//�t�H�[�J�X�ύX
                    flg--;
                    break;
            }
            Debug.Log(flg);
        }
        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == 0) SceneManager.LoadScene("GameScene1");//GameScene1�ɐ؂�ւ�
            if (flg == 1) SceneManager.LoadScene("GameScene2");//GameScene2�ɐ؂�ւ�
            if (flg == 2) SceneManager.LoadScene("GameScene3");//GameScene3�ɐ؂�ւ�
            if (flg == 3) SceneManager.LoadScene("GameScene4");//GameScene4�ɐ؂�ւ�
        }
    }
}