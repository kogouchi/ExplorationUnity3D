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
    public SystemManager systemManager;//SystemManager参照
    public AudioClip audioClip;//大砲SE
    private AudioSource audioSource;//音源入れるもの
    private GameObject createCore;//coreの入れ物
    public float speed = 300f;//大砲弾の速さ

    #region 参考サイト
    // オブジェクトに回転する角度を制限する
    // https://mono-pro.net/archives/9044
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//オーディオソース取得
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが続いている場合
        if (!systemManager.clearText.activeInHierarchy &&
            !systemManager.GameoverText.activeInHierarchy)
        {
            CoreMove();
            CannonMove();
        }
    }

    /// <summary>
    /// Core発射処理
    /// </summary>
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

    /// <summary>
    /// 大砲操作処理
    /// </summary>
    void CannonMove()
    {
        //大砲操作処理
        if (scc.flg == true && !player.gameObject.activeSelf)
        {
            Vector3 currentangle = transform.localEulerAngles;//現在の角度を取得
            if (currentangle.x > 180) currentangle.x = currentangle.x - 360;//角度が-180～180の範囲内になるように補正
            if (currentangle.y > 180) currentangle.y = currentangle.y - 360;//角度が-180～180の範囲内になるように補正
            Debug.Log(currentangle);
            currentangle.x = Mathf.Clamp(currentangle.x, -45, 0);//-45～45の範囲内に制限
            currentangle.y = Mathf.Clamp(currentangle.y, -45, 45);//-45～45の範囲内に制限
            transform.localEulerAngles = new Vector3(currentangle.x, currentangle.y, 0);

            //キーの割り当て----------------------------------------------------
            Quaternion quaternion = transform.localRotation;//rotation取得
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);//ADキー
            //WSキー(上記のADキーと同様な設定にすると、Wキーで角度が下に下がるため個々で設定)
            if (Input.GetKey(KeyCode.W)) transform.Rotate(quaternion.x - 0.8f, 0, 0);
            else if (Input.GetKey(KeyCode.S)) transform.Rotate(quaternion.x + 0.8f, 0, 0);
            //------------------------------------------------------------------

            cameraManager.TimeManager();//大砲操作中でも制限時間をカウントダウンさせる
        }
    }
}
