using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionManager : MonoBehaviour
{
    public TagManager tagManager;
    public DeadManager deadManager;
    public int Life = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(tagManager == true)
        {
            Debug.Log("TagManagerの取得成功！");
            // タグの名前を取得
            string playerTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_PLAYER);
            string EnemyTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_ENEMY);
            string BossTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_BOSS);
            string BulletTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_BULLET);

            Debug.Log(playerTag);
            Debug.Log(EnemyTag);
            Debug.Log(BossTag);
            Debug.Log(BulletTag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 共有式当たり判定
    private void OnTriggerEnter(Collider other)
    {
        string TagName;             // タグ名
        TagName = gameObject.tag;   // 当たった本人のタグを確認

        // タグの名前を取得
        string playerTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_PLAYER);
        string EnemyTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_ENEMY);
        string BossTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_BOSS);
        string BulletTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_BULLET);

        if (string.Equals(TagName, playerTag))
        { // 本人がプレイヤーの場合
            if (string.Equals(EnemyTag, other.gameObject.tag)
                || string.Equals(BossTag, other.gameObject.tag))
            { // 当たった対象が敵もしくはボスだった場合
                this.Life--;        // 体力減少
                Debug.Log("Playerがヒット！");
                Debug.Log(this.Life);
                if (this.Life <= 0)
                { // 0以下になったら死亡時処理
                    deadManager.SetDeadObject(DeadManager.DEADOBJECT.DEADOBJECT_PLAYER);
                }
            }
        }
        else if (string.Equals(TagName, EnemyTag))
        { // 本人が敵の場合
            if (string.Equals(playerTag, other.gameObject.tag)
                || string.Equals(BulletTag, other.gameObject.tag))
            { // 当たった対象がプレイヤーもしくは弾だった場合
                this.Life--;        // 体力減少
                Debug.Log("Enemyがヒット！");
                Debug.Log(this.Life);
                if (this.Life <= 0)
                { // 0以下になったら死亡時処理
                    deadManager.SetDeadObject(DeadManager.DEADOBJECT.DEADOBJECT_ENEMY);
                }
            }
        }
        else if (string.Equals(TagName, BossTag))
        { // 本人がボスの場合
            if (string.Equals(BulletTag, other.gameObject.tag))
            { // 当たった対象がプレイヤーもしくは弾だった場合
                Debug.Log("Bossがヒット！");
                this.Life--;        // 体力減少
                Debug.Log(this.Life);
                if (this.Life <= 0)
                { // 0以下になったら死亡時処理
                    deadManager.SetDeadObject(DeadManager.DEADOBJECT.DEADOBJECT_BOSS);
                }
            }
        }
        else if (string.Equals(TagName, BulletTag))
        { // 本人が弾の場合
            if (string.Equals(EnemyTag, other.gameObject.tag)
                || string.Equals(BossTag, other.gameObject.tag))
            { // 当たった対象が敵もしくはボスだった場合
                Debug.Log("Bulletがヒット！");
                this.Life--;        // 体力減少
                Debug.Log(this.Life);
                if (this.Life <= 0)
                { // 0以下になったら死亡時処理
                    deadManager.SetDeadObject(DeadManager.DEADOBJECT.DEADOBJECT_BULLET);
                }
            }
        }
    }
}
