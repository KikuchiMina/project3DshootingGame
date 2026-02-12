using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //1Fごとに等速で移動
        transform.Translate(0.1f, 0, 0);

        //画面外に出たらオブジェクトを破棄
        if (transform.position.x < -70 || 70 < transform.position.x)
            Destroy(gameObject);//破棄
    }
}
