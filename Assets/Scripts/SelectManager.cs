using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private Animator animRed = null;
    private Animator animGreen = null;
    private Animator animBlue = null;
    public GameObject Sphere;               // 球体
    //public GameObject playerRed;            // プレイヤーを格納するための変数
    //public GameObject playerGreen;
    //public GameObject playerBlue;
    //public Animation animationIdleRed;      // アニメーションを格納
    //public Animation animationIdleGreen;
    //public Animation animationIdleBlue;
    //public Animation animationTakeOffRed;
    //public Animation animationTakeOffGreen;
    //public Animation animationTakeOffBlue;
    int SelectPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        ////変数animIdleに、Animatorコンポーネントを設定する
        //animRed = playerRed.GetComponent<Animator>();
        //animGreen = playerGreen.GetComponent<Animator>();
        //animBlue = playerBlue.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectPlayer--;

            // 0未満は0にする
            if (SelectPlayer < 0)
            {
                SelectPlayer = 0;
            }
        }
        // 右に移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectPlayer++;

            // 2以上は2にする
            if (2 < SelectPlayer)
            {
                SelectPlayer = 2;
            }
        }

        // 現在のポジションを代入
        Vector3 pos = Sphere.transform.position;

        switch (SelectPlayer)
        {
            case 0:
                pos.x = -10.0f; // x座標変更
                break;
            case 1:
                pos.x = 0.0f; // x座標変更
                break;
            case 2:
                pos.x = 10.0f;                      // x座標変更
                break;
        }

        // 変更後の座標を代入
        Sphere.transform.position = pos;

        //switch (horizontalKey)
        //{
        //    case -1:
        //        this.animRed.SetTrigger("idle01");
        //        this.animGreen.SetTrigger("Idle01");
        //        this.animBlue.SetTrigger("Idle");
        //        break;
        //    case 0:
        //        this.animRed.SetTrigger("Take Off");
        //        this.animGreen.SetTrigger("Idle01");
        //        this.animBlue.SetTrigger("Idle");
        //        break;
        //    case 1:
        //        this.animRed.SetTrigger("Idle01");
        //        this.animGreen.SetTrigger("Take Off");
        //        this.animBlue.SetTrigger("Idle");
        //        break;
        //    case 2:
        //        this.animRed.SetTrigger("Idle01");
        //        this.animGreen.SetTrigger("Idle01");
        //        this.animBlue.SetTrigger("Take Off");
        //        break;
        //}

        // 画面遷移(ゲーム画面へ)
        if (Input.GetKeyDown(KeyCode.Return))
        {// ENTERが押された場合
            // SampleKey2 という名前のキーに int 型の値 20 を保存する
            PlayerPrefs.SetInt("Player", SelectPlayer);
            PlayerPrefs.Save();
        }
    }
}
