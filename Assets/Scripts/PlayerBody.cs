using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//HP�̕\����UI�����g�p

/// <summary>
/// Unity��ł��邱�� Player
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class PlayerBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public Slider healthBar;//hp�o�[�̎擾
    public float hp = 10.0f;//�ő�hp
    private Transform mytransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            //GravityAttractor.cs��Attract�֐�����
            attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��

        healthBar.value = hp;//�o�[��value��hp�Ƃ���
        if (hp == 0) Destroy(gameObject);//�v���C���[�폜
    }

    //�I�u�W�F�N�g���m���ڐG������
    private void OnCollisionEnter(Collision collision)
    {
        //�G�l�~�[�ɓ��������ꍇ
        if (collision.gameObject.name == "Enemy") hp -= 1.0f;
    }
}
