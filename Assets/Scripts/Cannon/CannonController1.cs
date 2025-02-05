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
    public SystemManager systemManager;//SystemManager�Q��
    public AudioClip audioClip;//��CSE
    private AudioSource audioSource;//������������
    private GameObject createCore;//core�̓��ꕨ
    public float speed = 300f;//��C�e�̑���

    #region �Q�l�T�C�g
    // �I�u�W�F�N�g�ɉ�]����p�x�𐧌�����
    // https://mono-pro.net/archives/9044
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���������Ă���ꍇ
        if (!systemManager.clearText.activeInHierarchy &&
            !systemManager.GameoverText.activeInHierarchy)
        {
            CoreMove();
            CannonMove();
        }
    }

    /// <summary>
    /// Core���ˏ���
    /// </summary>
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

    /// <summary>
    /// ��C���쏈��
    /// </summary>
    void CannonMove()
    {
        //��C���쏈��
        if (scc.flg == true && !player.gameObject.activeSelf)
        {
            Vector3 currentangle = transform.localEulerAngles;//���݂̊p�x���擾
            if (currentangle.x > 180) currentangle.x = currentangle.x - 360;//�p�x��-180�`180�͈͓̔��ɂȂ�悤�ɕ␳
            if (currentangle.y > 180) currentangle.y = currentangle.y - 360;//�p�x��-180�`180�͈͓̔��ɂȂ�悤�ɕ␳
            Debug.Log(currentangle);
            currentangle.x = Mathf.Clamp(currentangle.x, -45, 0);//-45�`45�͈͓̔��ɐ���
            currentangle.y = Mathf.Clamp(currentangle.y, -45, 45);//-45�`45�͈͓̔��ɐ���
            transform.localEulerAngles = new Vector3(currentangle.x, currentangle.y, 0);

            //�L�[�̊��蓖��----------------------------------------------------
            Quaternion quaternion = transform.localRotation;//rotation�擾
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);//AD�L�[
            //WS�L�[(��L��AD�L�[�Ɠ��l�Ȑݒ�ɂ���ƁAW�L�[�Ŋp�x�����ɉ����邽�ߌX�Őݒ�)
            if (Input.GetKey(KeyCode.W)) transform.Rotate(quaternion.x - 0.8f, 0, 0);
            else if (Input.GetKey(KeyCode.S)) transform.Rotate(quaternion.x + 0.8f, 0, 0);
            //------------------------------------------------------------------

            cameraManager.TimeManager();//��C���쒆�ł��������Ԃ��J�E���g�_�E��������
        }
    }
}
