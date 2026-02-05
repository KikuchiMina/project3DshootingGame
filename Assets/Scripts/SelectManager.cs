using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private Animator animRed = null;
    private Animator animGreen = null;
    private Animator animBlue = null;
    public GameObject playerRed;       // プレイヤーを格納するための変数
    public GameObject playerGreen;     // プレイヤーを格納するための変数
    public GameObject playerBlue;      // プレイヤーを格納するための変数
    private float horizontalKey = -1;

    // Start is called before the first frame update
    void Start()
    {
        //変数animIdleに、Animatorコンポーネントを設定する
        animRed = playerRed.GetComponent<Animator>();
        animGreen = playerGreen.GetComponent<Animator>();
        animBlue = playerBlue.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalKey--;

            // 0未満は0にする
            if (horizontalKey < 0)
            {
                horizontalKey = 0;
            }
        }
        // 右に移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalKey++;

            // 2以上は2にする
            if (2 < horizontalKey)
            {
                horizontalKey = 2;
            }
        }

        switch (horizontalKey)
        {
            case -1:
                this.animRed.SetTrigger("Idle01");
                this.animGreen.SetTrigger("Idle01");
                this.animBlue.SetTrigger("Idle");
                break;
            case 0:
                this.animRed.SetTrigger("Take Off");
                this.animGreen.SetTrigger("Idle01");
                this.animBlue.SetTrigger("Idle");
                break;
            case 1:
                this.animRed.SetTrigger("Idle01");
                this.animGreen.SetTrigger("Take Off");
                this.animBlue.SetTrigger("Idle");
                break;
            case 2:
                this.animRed.SetTrigger("Idle01");
                this.animGreen.SetTrigger("Idle01");
                this.animBlue.SetTrigger("Take Off");
                break;
        }

        // ENTERが押された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 画面遷移(ゲーム画面へ)
        }
    }
}
