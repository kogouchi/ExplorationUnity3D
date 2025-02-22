using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerAnimationObjectにつける→Playerの箱を作っているようなもの
public class PlayerAnimationController : MonoBehaviour
{
    private GameObject player;//Player本体(箱の中身)

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
