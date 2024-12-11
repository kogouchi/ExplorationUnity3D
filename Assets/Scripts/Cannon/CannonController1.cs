using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��C������]����
public class CannonController1 : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    public SubCameraController1 scc;//SubCameraController�Q��
    public CameraManager cameraManager;//CameraManager�Q��
    public GameObject corePos;//corePos�擾
    public AudioClip audioClip;//��CSE
    private AudioSource audioSource;//������������
    private GameObject createCore;//core�̓��ꕨ
    public Quaternion rot;//rotation�擾
    public float speed = 300f;//��C�e�̑���
    //public float minAngles = -25.0f, maxAngles = 25.0f;//�p�x�͈�
    //private float ray = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
    }

    // Update is called once per frame
    void Update()
    {
        CoreMove();//Core���ˏ���

        //��C�̈ړ�����(+�p�x�̕ύX���s���\��)
        if (scc.flg == true && !player.gameObject.activeSelf)
        {
            rot = transform.localRotation;//rotation�擾
            //������
            transform.Rotate(
                0,//Input.GetAxis("Vertical"),
                Input.GetAxis("Horizontal"),
                0);
            //�L�[���ƂɊ��蓖�Ă�(W�L�[��S�L�[�̂�)
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(rot.x - 0.8f, 0, 0);
                Debug.Log("W�L�[�������ꂽ");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(rot.x + 0.8f, 0, 0);
                Debug.Log("S�L�[�������ꂽ");
            }
            cameraManager.TimeManager();
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
            //�����Đ�
            audioSource.PlayOneShot(audioClip);
            Destroy(createCore, 10.0f);
        }
    }
}
