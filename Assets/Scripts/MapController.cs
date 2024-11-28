using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;
using Unity.VisualScripting;//�V�[���Ŏg�p

public class MapController : MonoBehaviour
{
    public Button s1button;
    public Button s2button;
    public Button s3button;
    public Button s4button;
    private int flg = 0;

    // Start is called before the first frame update
    void Start()
    {
        //MapScene�������ꍇ
        if (SceneManager.GetActiveScene().name == "MapScene")
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (flg)
            {
                case 0:
                    s2button.Select();//�t�H�[�J�X�ύX
                    flg++;
                    break;
                case 1:
                    s3button.Select();//�t�H�[�J�X�ύX
                    flg++;
                    break;
                case 2:
                    s4button.Select();//�t�H�[�J�X�ύX
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
                    s3button.Select();//�t�H�[�J�X�ύX
                    flg--;
                    break;
                case 2:
                    s2button.Select();//�t�H�[�J�X�ύX
                    flg--;
                    break;
                case 1:
                    s1button.Select();//�t�H�[�J�X�ύX
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
