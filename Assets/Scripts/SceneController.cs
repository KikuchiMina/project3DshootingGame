using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName;
    public Image PanelImage;
    public float fadeDuration = 1.0f;
    private GameObject fadePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            fadePanel = GameObject.Find("FadePanel");
            if (fadePanel == false)
            { // パネルが存在しなかった場合
                Debug.Log("フェード用のパネルの生成がされていないです！");
                return;
            }

            PanelImage = fadePanel.GetComponent<Image>();

            CallCoroutine();
        }
    }

    //追加した部分
    public void CallCoroutine()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        PanelImage.enabled = true;                 // パネルを有効化
        float elapsedTime = 0.0f;                 // 経過時間を初期化
        Color startColor = PanelImage.color;       // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
            PanelImage.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     // 1フレーム待機
        }

        PanelImage.color = endColor;  // フェードが完了したら最終色に設定
        SceneManager.LoadScene(sceneName);
    }
}
