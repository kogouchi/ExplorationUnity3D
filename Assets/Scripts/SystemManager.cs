using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

public class SystemManager : MonoBehaviour
{
    public GameObject clearText;//Clear�e�L�X�g
    public GameObject endText;//End�e�L�X�g
    public AudioSource audioSource;//�������߂̉������������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(clearText.activeInHierarchy)
        {
            audioSource.Stop();//�I�[�f�B�I�\�[�X�̒�~
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("MapScene");//MapScene�ɐ؂�ւ�
        }

        if (endText.activeInHierarchy)
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

        //F1�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");//TitleScene�ɐ؂�ւ�
        }
    }
}
