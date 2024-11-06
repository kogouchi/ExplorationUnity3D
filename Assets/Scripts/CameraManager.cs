using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainCamera��CameraManager���A�^�b�`+TipsText��ǉ�
//TipsText�̃A�N�e�B�u�A��A�N�e�B�u���̏���
public class CameraManager : MonoBehaviour
{
    public GameObject tipsText;//TipsText�̎擾

    #region �Q�l�T�C�g
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tipsText.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TipsTextManager();//TipsTextManager�̌Ăяo��

    }

    //TipsTextManager����
    public void TipsTextManager()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //UItext����\���̏ꍇ
            if (tipsText.activeSelf)
            {
                tipsText.SetActive(false);
                Time.timeScale = 1.0f;
                //Debug.Log("�Q�[���Đ�");
            }
            else
            {
                tipsText.SetActive(true);
                Time.timeScale = 0.0f;
                //Debug.Log("�Q�[����~");
            }
        }
    }
}