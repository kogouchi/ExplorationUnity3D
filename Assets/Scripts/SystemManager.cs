using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

public class SystemManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //F1�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("TitleScene");//TitleScene�ɐ؂�ւ�
        }
    }
}
