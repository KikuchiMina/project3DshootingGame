using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;
    public GameObject bullet;
    float MoveForce;
    public float fAttackSpan = 1200;
    float fResetAttackSpan = 0;
    int BossHP = 50;
    int nCounterHit = 0;
    int nCounterAttackMotion = 600;

    private int MotionType = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid = GetComponent<Rigidbody>();

        fResetAttackSpan = fAttackSpan;
    }

    // Update is called once per frame
    void Update()
    {
        if (fAttackSpan > 0)
        {
            this.animator.SetTrigger("FlyingFWD");
        }

        fAttackSpan--;

        if (fAttackSpan <= 0)
        {// 攻撃スパンカウンターが0以下になった時

            Debug.Log("Attack");

            // 攻撃モーションを再生
            this.animator.SetTrigger("Drakaris");

            fAttackSpan = fResetAttackSpan;   // 攻撃スパンカウンターをリセット

            MotionType = 0; // モーションタイプを切り替え待機状態に
        }

        //if (MotionType == 0)
        //{
        //    nCounterAttackMotion--;

        //    if (nCounterAttackMotion <= 0)
        //    {
        //        MotionType = 1; // モーションタイプを飛行状態に
        //        nCounterAttackMotion = 600; // 攻撃モーション中のカウンター

        //    }
        //}

        if (nCounterHit >= BossHP)
        {// 弾が当たった回数がHP以上になったら  

        }

    }

    void OnTriggerEnterEnter(Collider collision)
    {
        if (collision.name == bullet.name)
        {
            nCounterHit++;
        }
    }
}
