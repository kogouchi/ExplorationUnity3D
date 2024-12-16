using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerAnimationObject‚É‚Â‚¯‚é¨Player‚Ì” ‚ğì‚Á‚Ä‚¢‚é‚æ‚¤‚È‚à‚Ì
public class PlayerAnimationController : MonoBehaviour
{
    private GameObject player;//Player–{‘Ì(” ‚Ì’†g)

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
