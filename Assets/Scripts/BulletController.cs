using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");//ヒエラルキーの"player"を検索し取得

    }

    // Update is called once per frame
    void Update()
    {
        //1Fごとに等速で移動
        transform.Translate(0, -0.03f, 0);

        //画面外に出たらオブジェクトを破棄
        if (transform.position.x < -50)
            Destroy(gameObject);//破棄

    }
}
