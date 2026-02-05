using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    public string PlayerTag = "Player";         // プレイヤーのタグ
    public string EnemyTag = "Enemy";           // 敵のタグ
    public string BulletTag = "Bullet";         // 弾のタグ

    // タグの種類
    public enum TAGTYPE
    {
        TAGTYPE_PLAYER = 0,     // プレイヤーのタグ
        TAGTYPE_ENEMY,          // 敵のタグ
        TAGTYPE_BULLET,         // 弾のタグ
        TAGTYPE_MAX
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetTagName(TAGTYPE type)
    {
        switch(type)
        {
            case TAGTYPE.TAGTYPE_PLAYER:
                return PlayerTag;

            case TAGTYPE.TAGTYPE_ENEMY:
                return EnemyTag;

            case TAGTYPE.TAGTYPE_BULLET:
                return BulletTag;

            default:
                Debug.Log("そんなタグタイプは存在しないわ。");
                return null;
        }
    }
}
