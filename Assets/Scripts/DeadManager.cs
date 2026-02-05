using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadManager : MonoBehaviour
{
    public DeadPlayerController player;     // プレイヤー
    public DeadEnemyController enemy;       // 敵
    public DeadBulletController bullet;     // 弾

    public enum DEADOBJECT
    {
        DEADOBJECT_PLAYER = 0,      // プレイヤーの死亡演出
        DEADOBJECT_ENEMY,           // 敵の死亡演出
        DEADOBJECT_BULLET,          // 弾の死亡演出
        DEADOBJECT_MAX
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 死亡時関数の呼び出し
    public void SetDeadObject(DEADOBJECT objectType)
    {

    }
}
