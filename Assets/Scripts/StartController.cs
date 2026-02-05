using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public float fadeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Canvasの存在確認
        Canvas canvas = Object.FindAnyObjectByType<Canvas>();
        if(canvas == null)
        { // 無い場合は終了
            Debug.Log("Canvaが作成されていません！");
            return;
        }

        // パネルを新規作成
        GameObject fadePanel = new GameObject("FadePanel", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));

        // 親子関係とサイズの設定
        fadePanel.transform.SetParent(canvas.transform, false);

        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero; // 全画面に広げる
        rectTransform.anchoredPosition = Vector2.zero;

        // パネルの見た目（色・画像）の設定
        Image PanelImage = fadePanel.GetComponent<Image>();
        PanelImage.color = new Color(0, 0, 0, 1); // 黒画面
        PanelImage.enabled = true;

        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        GameObject fadePanel = GameObject.Find("FadePanel");
        Image panelImage = fadePanel.GetComponent<Image>();
        Color startColor = panelImage.color;        // フェードパネルの開始色を取得
        Color endColor = new Color(0, 0, 0, 0);     // フェードパネルの最終色を設定
        float elapsedTime = 0.0f;                   // 経過時間を初期化

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                            // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);      // フェードの進行度を計算
            panelImage.color = Color.Lerp(startColor, endColor, t);   // パネルの色を変更してフェードイン
            yield return null;                                        // 1フレーム待機
        }

        panelImage.color = endColor;  // フェードが完了したら最終色に設定
        panelImage.enabled = false;   // パネルを未使用に
    }
}
