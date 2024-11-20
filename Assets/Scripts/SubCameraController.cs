using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    private GameObject mainCamera;//���C���J�����i�[�p
    private GameObject subCamera;//�T�u�J�����i�[�p
    private bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("SubCamera");
        mainCamera.SetActive(false);//���C���J������\��
        subCamera.SetActive(true);//�T�u�J�����\��
        //subCamera.SetActive(false);//�T�u�J������\��
    }

    // Update is called once per frame
    void Update()
    {
        CameraChange();
    }

    void CameraChange()
    {
        //�X�y�[�X�������ꂽ�ꍇ
        if (Input.GetKey("space") || flg == true)
        {
            //�T�u�J�����\��
            mainCamera.SetActive(false);
            player.flg = true;
            subCamera.SetActive(true);
        }
        else
        {
            //���C���J�����\��
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
            flg = false;
        }
    }

    //�I�u�W�F�N�g���Փ˂����Ƃ�
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player������");
            flg = true;
        }
    }
}
