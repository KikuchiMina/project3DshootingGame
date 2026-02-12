using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public GameObject target;
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
    public void SetHitObject(HITOBJECT objectType, string targetname)
    {
        target = GameObject.Find(targetname);

        switch (objectType)
        {
            // プレイヤーの死亡時処理
            case HITOBJECT.HITOBJECT_PLAYER:
                player = target.GetComponent<HitPlayer>();
                if (player != null)
                {
                    player.SetHitPlayer();
                }
                break;

            // エネミーの死亡時処理
            case HITOBJECT.HITOBJECT_ENEMY:
                enemy = target.GetComponent<HitEnemy>();

                if (enemy != null)
                {
                    enemy.SetHitEnemy();
                }
                break;

            // ボスの死亡時処理
            case HITOBJECT.HITOBJECT_BOSS:
                boss = target.GetComponent<HitBoss>();

                if (boss != null)
                {
                    boss.SetHitBoss();
                }
                break;

            // 弾の死亡時処理
            case HITOBJECT.HITOBJECT_BULLET:
                bullet = target.GetComponent<HitBullet>();

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
