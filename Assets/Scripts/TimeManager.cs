using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeText;    //時間表示用テキスト
    public float limit = 60.0f;    //制限時間
    public GameObject text;    //ゲームオーバー表示用テキスト
    public GameObject player;    //プレイヤー格納用
    private bool isGameOver = false;    //ゲームオーバー判定

    void Start()
    {
        timeText.text = "Time:" + limit + "秒";
    }

    void Update()
    {
        //時間制限がきたとき
        if (limit < 0)
        {
            //ゲームオーバーを表示する
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);
            isGameOver = true;            //ゲームオーバー
            return;
        }

        //時間をカウントダウンする
        limit -= Time.deltaTime;
        timeText.text = "Time:" + limit.ToString("f1") + "秒";
    }
}
