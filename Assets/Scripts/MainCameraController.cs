using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

//�T�u�J�������N�����Ă���ꍇ�̕s�K�v�I�u�W�F�N�g�̏���
public class MainCameraController : MonoBehaviour
{
    public GameObject player;//Player�擾
    private Vector3 offset;//Camera�Ƃ̋���

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
