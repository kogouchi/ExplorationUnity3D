using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public GameObject enemy;//enemy�擾

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�I�u�W�F�N�g���Փ˂�����
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("enemy��|����");
            Destroy(enemy);
            Destroy(gameObject);
        }
    }
}
