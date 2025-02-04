using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyEffect再生用
public class EffectController : MonoBehaviour
{
    private ParticleSystem effects;

    // Start is called before the first frame update
    void Start()
    {
        effects = gameObject.GetComponent<ParticleSystem>();
        effects.Play();//エフェクト再生
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);//1.5秒後削除
    }
}
