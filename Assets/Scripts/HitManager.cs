using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public HitPlayer player;     // プレイヤー
    public HitEnemy enemy;       // 敵
    public HitBoss boss;         // ボス
    public HitBullet bullet;     // 弾

    public enum HITOBJECT
    {
        HITOBJECT_PLAYER = 0,      // プレイヤーの死亡演出
        HITOBJECT_ENEMY,           // 敵の死亡演出
        HITOBJECT_BOSS,            // ボスの死亡演出
        HITOBJECT_BULLET,          // 弾の死亡演出
        HITOBJECT_MAX
    };

    // 死亡時関数の呼び出し
    public void SetHitObject(HITOBJECT objectType)
    {
        switch (objectType)
        {
            // プレイヤーの死亡時処理
            case HITOBJECT.HITOBJECT_PLAYER:
                if (player != null)
                {
                    player.SetHitPlayer();
                }
                break;

            // エネミーの死亡時処理
            case HITOBJECT.HITOBJECT_ENEMY:
                if (enemy != null)
                {
                    enemy.SetHitEnemy();
                }
                break;

            // ボスの死亡時処理
            case HITOBJECT.HITOBJECT_BOSS:
                if (boss != null)
                {
                    boss.SetHitBoss();
                }
                break;

            // 弾の死亡時処理
            case HITOBJECT.HITOBJECT_BULLET:
                if (bullet != null)
                {
                    bullet.SetHitBullet();
                }
                break;

            // 例外処理
            default:
                Debug.Log("そんなヒット時処理は無いですよ！");
                break;
        }
    }
}
