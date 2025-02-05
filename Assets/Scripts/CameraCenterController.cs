using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterController : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public EnemyController enemy;

    public float movespeed = 10.0f;//�ړ����x
    public bool groundflg = false;//�n��flg
    public bool moveflg = false;

    private Rigidbody myrb;//Rigidbody�擾
    private Transform mytransform;//Transform�擾
    private Vector3 movedir;//�ړ��L�[�Ɏg�p

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();//Rigidbody�擾
        mytransform = transform;//Transform�擾
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();//�ړ�����
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    public void Move()
    {
        //�ړ�����
        movedir = new Vector3(
        Input.GetAxisRaw("Horizontal"),//AD
        0,
        Input.GetAxisRaw("Vertical")).normalized;//WS
        //normalized�Ńx�N�g���̐��K��(��΂��Ȃ��Ƃ����Ȃ��炵��)

        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, myrb);//���g��transform��rigidbody�̏���n��

        //�d�͏���
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
        //���X�P�[���ƈʒu���W�ɉe������Ȃ�
        myrb.MovePosition(myrb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
