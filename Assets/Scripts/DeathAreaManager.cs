using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DeathArea����
public class DeathAreaManager : MonoBehaviour
{
    public PlayerController player;//player�擾
    private float ray = 0.5f;//���m�͈�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit�g�p
        RaycastHit[] hits = Physics.SphereCastAll(
        transform.position,
        ray,
        Vector3.forward);

        //���݂̌��m�����I�u�W�F�N�g�̕\�L
        foreach (var hit in hits)
        {
            //Debug.Log($"���o���ꂽobj{hit.collider.name}");
            if (hit.collider.tag == "Player" && player.hp != 0)
            {
                player.hp -= 1.0f;
                Debug.Log("Player�ƐڐG");
            }
            else Debug.Log("Player�����ꂽ");
        }
    }
}
