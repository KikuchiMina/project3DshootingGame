using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionManager : MonoBehaviour
{
    public TagManager tagManager;
    public DeadManager deadManager;
    public int Life = 1;
    public bool IsRandom = false;

    // Start is called before the first frame update
    void Start()
    {
        if(tagManager == true)
        {
            Debug.Log("TagManagerの取得成功！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string TagName;             // タグ名
        TagName = gameObject.tag;   // 当たった本人のタグを確認

        // タグの名前を取得
        string playerTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_PLAYER);
        string EnemyTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_ENEMY);
        string BulletTag = tagManager.GetTagName(TagManager.TAGTYPE.TAGTYPE_BULLET);

        if(string.Equals(TagName, playerTag))
        { // 本人がプレイヤーの場合
            if(string.Equals(TagName, collision.gameObject.name))
            { // 当たった対象が敵だった場合
                this.Life--;
            }
        }
        else if(string.Equals(TagName, EnemyTag))
        { // 本人が敵の場合

        }
        else if (string.Equals(TagName, BulletTag))
        { // 本人が弾の場合

        }
    }
}
