using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    public string PlayerTag = "Player";         // プレイヤーのタグ
    public string EnemyTag = "Enemy";           // 敵のタグ
    public string BossTag = "Boss";             // ボスのタグ
    public string BulletTag = "Bullet";         // 弾のタグ

    // タグの種類
    public enum TAGTYPE
    {
        TAGTYPE_PLAYER = 0,     // プレイヤーのタグ
        TAGTYPE_ENEMY,          // 敵のタグ
        TAGTYPE_BOSS,           // ボスのタグ
        TAGTYPE_BULLET,         // 弾のタグ
        TAGTYPE_MAX
    };

    public string GetTagName(TAGTYPE type)
    {
        switch(type)
        {
            // プレイヤー
            case TAGTYPE.TAGTYPE_PLAYER:
                return PlayerTag;

            // 敵
            case TAGTYPE.TAGTYPE_ENEMY:
                return EnemyTag;

            // ボス
            case TAGTYPE.TAGTYPE_BOSS:
                return EnemyTag;

            // 弾
            case TAGTYPE.TAGTYPE_BULLET:
                return BulletTag;

            // 例外
            default:
                Debug.Log("そんなタグタイプは存在しないわ。");
                return null;
        }
    }
}
