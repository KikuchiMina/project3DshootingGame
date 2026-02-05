using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;
    public float fSpan = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid = GetComponent<Rigidbody>();
    }

    float fFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        this.animator.SetTrigger("FlyingFWD");

        this.fFire += Time.deltaTime;

        if (this.fSpan < this.fFire)
        {
            this.fFire = 0.0f;
            Debug.Log("aaaa");
            animator.SetTrigger("Drakaris");
        }
    }
}
