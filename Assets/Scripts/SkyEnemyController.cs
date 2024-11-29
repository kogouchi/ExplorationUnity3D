using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemyController : MonoBehaviour
{
    public int cnt = 0;
    public AudioClip audioClip;//�����i�[
    private AudioSource audioSource;//������������

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�I�u�W�F�N�g���Փ˂�����
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            //Debug.Log("�G�l�~�[��|����");
            Destroy(gameObject, 0.6f);
            audioSource.PlayOneShot(audioClip);
            Destroy(collision.gameObject);
        }
    }
}
