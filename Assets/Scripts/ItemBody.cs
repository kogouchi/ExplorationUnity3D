using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item�̍폜�{Item��������
public class ItemBody : MonoBehaviour
{
    private MeshRenderer mr;//MeshRenderer�擾
    private SphereCollider col;//SphereCollider�擾

    public float displayDelay = 10.0f;//�\���܂ł̎���
    private bool activeflg = true;//�R���[�`�����J��Ԃ��Ȃ����߂̃t���O

    #region �Q�l�T�C�g
    // ���b�V���̎擾�Ɣ�\���̏�����
    // https://futabazemi.net/unity/meshrenderer-change
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();//MeshRenderer�擾
        col = GetComponent<SphereCollider>();//Collider�擾
    }

    // Update is called once per frame
    void Update()
    {
        //Item����\�����t���O��false�ł���ꍇ
        if (activeflg == false) StartCoroutine(ItemActive());//�R���[�`���J�n
    }

    public IEnumerator ItemActive()
    {
        activeflg = true;//activeflg��true
        yield return new WaitForSeconds(displayDelay);//displayDelay���҂�
        mr.enabled = true;//Mesh��\��
        col.enabled = true;//Collider��\��
    }

    //�I�u�W�F�N�g���m���ڐG������
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            activeflg = false;//activeflg��false
            mr.enabled = false;//Mesh��\��
            col.enabled = false;//Collider��\��
        }
    }
}
