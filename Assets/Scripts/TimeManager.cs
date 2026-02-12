using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;    //時間表示用テキスト
    public float limit = 30.0f;    //制限時間

    public SceneController Controller;  // ここでシーンコントローラーを取得
    public string DeadEndScene;           // 遷移するシーン名を指定

    void Start()
    {
        timeText.text = "Time:" + limit;
    }

    void Update()
    {
        //時間をカウントダウンする
        limit -= Time.deltaTime;
        timeText.text = "Time:" + limit.ToString("f1");

        //時間制限がきたとき
        if (limit <= 0)
        {
            Controller.sceneName = DeadEndScene;     // 遷移するシーン名を適用
            Controller.CallCoroutine();              // シーンを遷移
        }
    }
}
