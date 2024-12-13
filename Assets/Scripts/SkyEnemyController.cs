using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemyController : MonoBehaviour
{
    public int cnt = 0;
    public GameObject particleEffect;//���񂾎��̃G�t�F�N�g�擾
    public AudioClip audioClip;//�����i�[
    private AudioSource audioSource;//������������
    private bool effectflg = false;//effect�t���O

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator EnemyActive()
    {
        Destroy(gameObject, 0.2f);
        yield return new WaitForSeconds(5.0f);//displayDelay���҂�
    }

    //�I�u�W�F�N�g���Փ˂�����
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            //Debug.Log("�G�l�~�[��|����");
            //�G�t�F�N�g��1�x�̂ݍĐ�
            if (effectflg == false)
            {
                Instantiate(particleEffect, transform.position, transform.rotation);//Effect�Đ�
                effectflg = true;
            }
            StartCoroutine(EnemyActive());//�R���[�`���J�n
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
    }
}
