using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//��C������]����
public class CannonController : MonoBehaviour
{
    public PlayerController player;//PlayerController�Q��
    public SubCameraController scc;//SubCameraController�Q��
    public GameObject corePos;//corePos�擾
    public Vector3 rot;//rotation�擾
    private float speed = 300f;//��C�e�̑���
    public float minAngles = -25.0f, maxAngles = 25.0f;//�p�x�͈�

    // Start is called before the first frame update
    void Start()
    {
        rot = Vector3.zero;//������
    }

    // Update is called once per frame
    void Update()
    {
        //Space�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space) && scc.flg == true)
        {
            //core���C���X�^���X�����Ĕ���
            GameObject createCore = Instantiate(corePos) as GameObject;
            createCore.GetComponent<MeshRenderer>().enabled = true;
            createCore.transform.position = corePos.transform.position;

            //���˃x�N�g��
            Vector3 force;
            //���˂̌����Ƒ��x������
            force = corePos.transform.forward * speed;
            //rigidbody�ɗ͂������Ĕ���
            createCore.GetComponent<Rigidbody>().AddForce(force);
            Destroy(createCore, 10.0f);
        }

        rot = gameObject.transform.localEulerAngles;//���݂�rotation�擾
        //�p�x�̐���
        if (player.flg)
        {
            if(minAngles < rot.y || rot.y < maxAngles)
                transform.Rotate(
                    Input.GetAxis("Vertical"), 
                    Input.GetAxis("Horizontal"), 
                    0);
        }
    }
}
