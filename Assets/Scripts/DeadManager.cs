using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadManager : MonoBehaviour
{
    public DeadPlayerController player;     // プレイヤー
    public DeadEnemyController enemy;       // 敵
    public DeadBossController boss;         // ボス
    public DeadBulletController bullet;     // 弾

    public enum DEADOBJECT
    {
        DEADOBJECT_PLAYER = 0,      // プレイヤーの死亡演出
        DEADOBJECT_ENEMY,           // 敵の死亡演出
        DEADOBJECT_BOSS,            // ボスの死亡演出
        DEADOBJECT_BULLET,          // 弾の死亡演出
        DEADOBJECT_MAX
    };

    // 死亡時関数の呼び出し
    public void SetDeadObject(DEADOBJECT objectType)
    {
        switch(objectType)
        {
            // プレイヤーの死亡時処理
            case DEADOBJECT.DEADOBJECT_PLAYER:
                player.SetDeadPlayer();
                break;

            // エネミーの死亡時処理
            case DEADOBJECT.DEADOBJECT_ENEMY:
                enemy.SetDeadEnemy();
                break;

            // ボスの死亡時処理
            case DEADOBJECT.DEADOBJECT_BOSS:
                boss.SetDeadBoss();
                break;

            // 弾の死亡時処理
            case DEADOBJECT.DEADOBJECT_BULLET:
                bullet.SetDeadBullet();
                break;

            // 例外処理
            default:
                Debug.Log("そんな死亡時処理は無いですよ！");
                break;
        }
    }
}
