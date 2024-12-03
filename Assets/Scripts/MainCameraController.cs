using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

//�T�u�J�������N�����Ă���ꍇ�̕s�K�v�I�u�W�F�N�g�̏���
public class MainCameraController : MonoBehaviour
{
    //�i�[�������(�t�B�[���h��œ�������)
    public PlayerController player;
    private Vector3 pos;//�ʒu���W
    private Vector3 trQ;//��]���W

    // Start is called before the first frame update
    void Start()
    {
        //Camera�ʒu���W��Player�ɕύX
        pos = player.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
        trQ = player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera�ʒu���W��Player�ɕύX
        pos = player.transform.position;
        pos.y = 14.0f;
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
