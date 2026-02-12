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
    public bool IsCanFade = false;
    public bool IsReturnFade = true;
    private GameObject fadePanel;
    private bool IsFadeing = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && IsReturnFade == true && IsCanFade == true)
        {
            CallCoroutine();
        }
    }

    //追加した部分
    public void CallCoroutine()
    {
        fadePanel = GameObject.Find("FadePanel");
        if (fadePanel == false)
        { // パネルが存在しなかった場合
          // Canvasの存在確認
            Canvas canvas = Object.FindAnyObjectByType<Canvas>();
            if (canvas == null)
            { // 無い場合は終了
                Debug.Log("Canvaが作成されていません！");
                return;
            }

            fadePanel = new GameObject("FadePanel", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));

            // 親子関係とサイズの設定
            fadePanel.transform.SetParent(canvas.transform, false);

            RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero; // 全画面に広げる
            rectTransform.anchoredPosition = Vector2.zero;

            // パネルの見た目（色・画像）の設定
            Image PanelImage = fadePanel.GetComponent<Image>();
            PanelImage.color = new Color(0, 0, 0, 0); // 黒画面
            PanelImage.enabled = true;


            Debug.Log("フェード用のパネルの生成が成功しました！");
            return;
        }

        if (fadePanel.GetComponent<Image>().color.a > 0.0f)
        {
            Debug.Log("フェード中です！");
            return;
        }

        PanelImage = fadePanel.GetComponent<Image>();

        StartCoroutine(FadeOutAndLoadScene());
        IsFadeing = true;
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
