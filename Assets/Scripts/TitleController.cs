using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�e�L�X�g�\���Ŏg�p
using UnityEngine.SceneManagement;//�V�[���Ŏg�p

public class TitleController : MonoBehaviour
{
    //�e�{�^���̊i�[
    public Button sbutton;
    public Button ebutton;

    public AudioClip[] audioClips;//�����i�[
    private AudioSource audioSource;//�������߂̉������������
    //�t���O�p
    private bool buttonflg = false;
    private bool keyflg = false;

    // Start is called before the first frame updates
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X�擾
        sbutton.Select();//�t�H�[�J�X�ύX
    }

    // Update is called once per frame
    void Update()
    {
        TitleChange();
    }

    //Title�؂�ւ�
    public void TitleChange()
    {
        //S�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonflg = false;
            ebutton.Select();
            audioSource.PlayOneShot(audioClips[1]);
        }
        //W�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonflg = true;
            sbutton.Select();
            audioSource.PlayOneShot(audioClips[1]);
        }
        //�X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClips[0]);
            if (buttonflg == true)
                SceneManager.LoadScene("MapScene");//MapScene�ɐ؂�ւ�
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��(�Q�[���G���W���ŋN����)
#else
            Application.Quit();//�Q�[���I��(�r���h�ŋN����)
#endif
            }
        }
    }
}
