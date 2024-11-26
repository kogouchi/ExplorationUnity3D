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
    private int flg = 0;//flg�؂�ւ�

    // Start is called before the first frame update
    void Start()
    {
        startButton = startButton.GetComponent<Button>();//button�擾
        endButton = endButton.GetComponent<Button>();//button�擾
        endButton = s1Button.GetComponent<Button>();//s1button�擾
        endButton = s2Button.GetComponent<Button>();//s2button�擾
        endButton = s3Button.GetComponent<Button>();//s3button�擾
        endButton = s4Button.GetComponent<Button>();//s4button�擾
        EventSystem.current.SetSelectedGameObject(null);//�S�Ẵt�H�[�J�X������
        startButton.Select();//startButton�Ƀt�H�[�J�X����
        s1Button.Select();//s1Button�Ƀt�H�[�J�X����
    }

    // Update is called once per frame
    void Update()
    {
        //TitleScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "TitleScene") TitleChange();//Title�؂�ւ�
        //MapScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "MapScene") MapChange();//Map�؂�ւ�
    }

    //Title�؂�ւ�
    public void TitleChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            endButton.Select();//endButton�Ƀt�H�[�J�X����
            flg = 1;
            Debug.Log("�I���{�^���I��");
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            startButton.Select();//startButton�Ƀt�H�[�J�X����
            flg = 0;
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
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���I��
#else
        Application.Quit();//�Q�[���I��
#endif
            }
        }
    }

    //Map�؂�ւ�
    public void MapChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            endButton.Select();//endButton�Ƀt�H�[�J�X����
            flg = 1;
            Debug.Log("�I���{�^���I��");
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            startButton.Select();//startButton�Ƀt�H�[�J�X����
            flg = 2;
            Debug.Log("�J�n�{�^���I��");
        }
    }
}