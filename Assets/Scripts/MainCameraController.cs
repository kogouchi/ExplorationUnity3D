using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

//サブカメラが起動している場合の不必要オブジェクトの処理
public class MainCameraController : MonoBehaviour
{
    public GameObject player;//Player取得
    private Vector3 offset;//Cameraとの距離

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
