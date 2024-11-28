using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

//��C������]����
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    public SubCameraController scc;//SubCameraController�Q��
    public GameObject corePos;//corePos�擾
    private GameObject createCore;//core�̓��ꕨ
    public Quaternion rot;//rotation�擾
    public float speed = 300f;//��C�e�̑���
    public float minAngles = -25.0f, maxAngles = 25.0f;//�p�x�͈�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CoreMove();//Core���ˏ���

        //�p�x�̐���
        if (player.flg)
        {
            rot = transform.rotation;//rotation�擾
            transform.Rotate(
                Input.GetAxis("Vertical"), 
                Input.GetAxis("Horizontal"), 
                0);
        }
    }

    //Core���ˏ���
    void CoreMove()
    {
        //Space�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space) && scc.flg == true)
        {
            //core���C���X�^���X�����Ĕ���
            createCore = Instantiate(corePos) as GameObject;
            //createCore�̈ʒu���W�̐ݒ�
            createCore.transform.position = corePos.transform.position;
            //createCore�̕\��
            createCore.SetActive(true);
            //MeshRenderer�̕\��
            createCore.GetComponent<MeshRenderer>().enabled = true;

            //���˃x�N�g��
            Vector3 force;
            //���˂̌����Ƒ��x������
            force = corePos.transform.forward * speed;
            //rigidbody�ɗ͂������Ĕ���
            createCore.GetComponent<Rigidbody>().AddForce(force);
            Destroy(createCore, 10.0f);
        }
    }
}