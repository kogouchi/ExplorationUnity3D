using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//大砲向き回転処理
public class CannonController1 : MonoBehaviour
{
    public PlayerController player;//PlayerController参照
    public SubCameraController1 scc;//SubCameraController参照
    public CameraManager cameraManager;//CameraManager参照
    public GameObject corePos;//corePos取得
    public AudioClip audioClip;//大砲SE
    private AudioSource audioSource;//音源入れるもの
    private GameObject createCore;//coreの入れ物
    public Quaternion rot;//rotation取得
    public float speed = 300f;//大砲弾の速さ
    //public float minAngles = -25.0f, maxAngles = 25.0f;//角度範囲
    //private float ray = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
    }

    // Update is called once per frame
    void Update()
    {
        CoreMove();//Core発射処理

        //大砲の移動処理(+角度の変更も行う予定)
        if (scc.flg == true && !player.gameObject.activeSelf)
        {
            rot = transform.localRotation;//rotation取得
            //旧操作
            transform.Rotate(
                0,//Input.GetAxis("Vertical"),
                Input.GetAxis("Horizontal"),
                0);
            //キーごとに割り当てる(WキーとSキーのみ)
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(rot.x - 0.8f, 0, 0);
                Debug.Log("Wキーが押された");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(rot.x + 0.8f, 0, 0);
                Debug.Log("Sキーが押された");
            }
            cameraManager.TimeManager();
        }

    }

    //Core発射処理
    void CoreMove()
    {
        //Spaceキーが押された時
        if (Input.GetKeyDown(KeyCode.Space) && scc.flg == true)
        {
            //coreをインスタンス化して発射
            createCore = Instantiate(corePos) as GameObject;
            //createCoreの位置座標の設定
            createCore.transform.position = corePos.transform.position;
            //createCoreの表示
            createCore.SetActive(true);
            //MeshRendererの表示
            createCore.GetComponent<MeshRenderer>().enabled = true;

            //発射ベクトル
            Vector3 force;
            //発射の向きと速度を決定
            force = corePos.transform.forward * speed;
            //rigidbodyに力を加えて発射
            createCore.GetComponent<Rigidbody>().AddForce(force);
            //音源再生
            audioSource.PlayOneShot(audioClip);
            Destroy(createCore, 10.0f);
        }
    }
}
