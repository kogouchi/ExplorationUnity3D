using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyEffect�Đ��p
public class EffectController : MonoBehaviour
{
    private ParticleSystem effects;

    // Start is called before the first frame update
    void Start()
    {
        effects = gameObject.GetComponent<ParticleSystem>();
        effects.Play();//�G�t�F�N�g�Đ�
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);//1.5�b��폜
    }
}
