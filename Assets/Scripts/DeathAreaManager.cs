using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DeathArea処理
public class DeathAreaManager : MonoBehaviour
{
    public PlayerController player;//player取得
    private float ray = 0.5f;//検知範囲

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit使用
        RaycastHit[] hits = Physics.SphereCastAll(
        transform.position,
        ray,
        Vector3.forward);

        //現在の検知したオブジェクトの表記
        foreach (var hit in hits)
        {
            //Debug.Log($"検出されたobj{hit.collider.name}");
            if (hit.collider.tag == "Player" && player.hp != 0)
            {
                player.hp -= 1.0f;
                Debug.Log("Playerと接触");
            }
            else Debug.Log("Playerが離れた");
        }
    }
}
