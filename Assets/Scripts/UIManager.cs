using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UISystem�ɒǉ�
//��������e�L�X�g�̕\��
public class UIManager : MonoBehaviour
{
    public GameObject Uiobj;

    #region �Q�l�T�C�g
    //https://futabazemi.net/unity/spacekey_obj_change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Uiobj.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("F�L�[�������ꂽ");

            //UItext����\���̏ꍇ
            if (Uiobj.activeSelf)
            {
                Uiobj.SetActive(false);
                Time.timeScale = 1.0f;
                Debug.Log("�Q�[���Đ�");
            }
            else
            {
                Uiobj.SetActive(true);
                Time.timeScale = 0.0f;
                Debug.Log("�Q�[����~");
            }
        }
    }
}