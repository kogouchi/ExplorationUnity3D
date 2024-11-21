using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    private GameObject mainCamera;//���C���J�����i�[�p
    private GameObject subCamera;//�T�u�J�����i�[�p
    public bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g�̐ݒ�
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("SubCamera");
        subCamera.SetActive(false);//�T�u�J������\��
    }

    // Update is called once per frame
    void Update()
    {
        CameraChange();
    }

    void CameraChange()
    {
        //�v���C���[�ƃR���C�_�[�����������ꍇ�{�T�u�J�����쓮
        if (flg == true)
        {
            //�T�u�J�����\��
            subCamera.SetActive(true);
            mainCamera.SetActive(false);
            //�I�u�W�F�N�g��~
            player.gameObject.SetActive(false);
            player.flg = true;

        }
        //Q�L�[�������ꂽ�ꍇ
        if(Input.GetKeyDown(KeyCode.Q) && flg == true)
        {
            Debug.Log("Q push");
            //�I�u�W�F�N�g�쓮
            player.gameObject.SetActive(true);
            player.flg = false;
            flg = false;
            //���C���J�����\��
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
            //isTrigger�I�t
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    //�I�u�W�F�N�g���Փ˂�����
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")       
           flg = true;
    }

    //�I�u�W�F�N�g�����ꂽ��
    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            //isTrigger�I��
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
