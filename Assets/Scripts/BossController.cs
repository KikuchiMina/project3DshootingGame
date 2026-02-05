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

        if (fAttackSpan <= 0)
        {// 攻撃スパンカウンターが0以下になった時
            //Debug.Log("Attack");

            // 攻撃モーションを再生
            this.animator.SetTrigger("Drakaris");
            fAttackSpan = fResetAttackSpan;   // 攻撃スパンカウンターをリセット
        }
        else
        {
            fAttackSpan--;
        }

        Debug.Log(fAttackSpan);
    }
}
