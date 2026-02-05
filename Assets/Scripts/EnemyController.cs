using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    float span = 0.8f;
    float delta = 0.0f;
    double curve = 0.0f;
    double spin = 0.008;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = transform.position;
        if(p1.y < 0)
        {
            spin *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        curve += spin;
        float waves = (float)Math.Sin(curve) * 0.02f;
        transform.Translate(0, waves, 0.05f);
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            waves *= -1;
            delta = 0.0f;
        }

        //画面外に出たらオブジェクトを破棄
        if (transform.position.x < -50)
            Destroy(gameObject);//破棄

    }
}
