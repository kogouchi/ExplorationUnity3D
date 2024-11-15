using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//�A�C�e���ڐG����(Raycast���g�p)
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemy�̎擾
    public float ray = 2.5f;//���m�͈�
    public float movepeed = 5.0f;//�ړ��X�s�[�h

    // Start is called before the first frame update
    void Start()
    {
        //�ʒu�ݒ�(enemy�{�̂̈ʒu)
        transform.position = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�ʒu���̍X�V�i���enemy�{�̂̈ʒu�j
        transform.position = enemy.transform.position;

        //RaycastHit�g�p
        RaycastHit[] hits = Physics.SphereCastAll(
        transform.position,
        ray,
        Vector3.forward);

        //���݂̌��m�����I�u�W�F�N�g�̕\�L
        foreach (var hit in hits)
        {
            //Debug.Log($"���o���ꂽobj{hit.collider.name}");
            if(hit.collider.tag == "Item")
            {
                //enemy��item�֒Ǐ]����
                enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position, //enemy�ʒu���W
                hit.transform.position,//���m����Item�^�O�̈ʒu���W
                movepeed * Time.deltaTime);
                //Debug.Log("item�Q�b�g");
            }
        }
    }
}
