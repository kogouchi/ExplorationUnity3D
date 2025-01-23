using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンで使用

public class SystemManager : MonoBehaviour
{
    public GameObject clearText;//Clearテキスト
    public GameObject endText;//Endテキスト
    public AudioSource audioSource;//流すための音源を入れるもの

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(clearText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("MapScene");//MapSceneに切り替え
        }

        if (endText.activeInHierarchy)
        {
            audioSource.Stop();//オーディオソースの停止
            //if (Input.GetKeyDown(KeyCode.Space))
            //    SceneManager.LoadScene("MapScene");//MapSceneに切り替え
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (SceneManager.GetActiveScene().name == "GameScene1")
                    SceneManager.LoadScene("GameScene1");//GameScene1に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene2")
                    SceneManager.LoadScene("GameScene2");//GameScene2に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene3")
                    SceneManager.LoadScene("GameScene3");//GameScene3に切り替え
                if (SceneManager.GetActiveScene().name == "GameScene4")
                    SceneManager.LoadScene("GameScene4");//GameScene4に切り替え
            }
        }

        //F1キーが押された場合
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");//TitleSceneに切り替え
        }
    }
}
