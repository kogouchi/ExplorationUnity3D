using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerAnimationObject�ɂ��遨Player�̔�������Ă���悤�Ȃ���
public class PlayerAnimationController : MonoBehaviour
{
    private GameObject player;//Player�{��(���̒��g)

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("AniCube");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        this.transform.rotation = player.transform.rotation;
    }
}
