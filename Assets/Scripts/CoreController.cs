using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemyController : MonoBehaviour
{

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
        if (collision.gameObject.tag == "Core")
        {
            Debug.Log("�G�l�~�[��|����");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
