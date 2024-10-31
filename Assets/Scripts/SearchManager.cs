using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

//Enemy�A�C�e���E���͈�
public class SearchManager : MonoBehaviour
{
    public GameObject enemy;//enemy�̎擾
    public bool searchflag = false;//�T���t���O

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit[] hits = Physics.SphereCastAll(
       transform.position,
       3.0f,
       Vector3.forward);

        //Debug.Log($"���o���ꂽ�R���C�_�[��:{this.Length}");

        //���݂̌��m�����I�u�W�F�N�g�̕\�L
        //if(searchflag)
        foreach (var hit in hits)
        {
            //Debug.Log($"���o���ꂽobj{hit.collider.name}");
            if(hit.collider.tag == "Item")
            {
                //enemy��item�֒Ǐ]����
                enemy.transform.position =
                        Vector3.MoveTowards(
                enemy.transform.position, 
                hit.transform.position,
                5.0f * Time.deltaTime );
                Debug.Log("item�Q�b�g");
            }
        }
    }
}
