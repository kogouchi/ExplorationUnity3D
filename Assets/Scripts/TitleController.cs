using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;
using Unity.VisualScripting;//�V�[���Ŏg�p

public class TitleController : MonoBehaviour
{
    public Button sbutton;
    public Button ebutton;
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        //TitleScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "TitleScene")
            sbutton.Select();//�t�H�[�J�X�ύX
    }

    // Update is called once per frame
    void Update()
    {
        TitleChange();
    }

    //Title�؂�ւ�
    public void TitleChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            flg = false;
            ebutton.Select();
            Debug.Log(flg);
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = true;
            sbutton.Select();
            Debug.Log(flg);
        }
        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flg == true)
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
}
