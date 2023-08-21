using UnityEngine;
using UnityEngine.UI;

public class OverScreen : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Image icon;

    private Rect rect = new Rect(0, 0, 1, 1);

    private Rect canvasRect;

    public void SetTarget(Transform setTarget)
    {
        target = setTarget;
    }

    void Start()
    {
        // UIÇ™ÇÕÇ›èoÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
        canvasRect = ((RectTransform)icon.canvas.transform).rect;
        canvasRect.Set(
            canvasRect.x + icon.rectTransform.rect.width * 0.5f,
            canvasRect.y + icon.rectTransform.rect.height * 0.5f,
            canvasRect.width - icon.rectTransform.rect.width,
            canvasRect.height - icon.rectTransform.rect.height
        );
    }

    void FixedUpdate()
    {
        var viewport = Camera.main.WorldToViewportPoint(target.position);
        if (rect.Contains(viewport))
        {
            icon.enabled = false;
        }
        else
        {
            icon.enabled = true;

            // âÊñ ì‡Ç≈ëŒè€Çí«ê’
            viewport.x = Mathf.Clamp01(viewport.x);
            viewport.y = Mathf.Clamp01(viewport.y);
            icon.rectTransform.anchoredPosition = Rect.NormalizedToPoint(canvasRect, viewport);
        }
    }
}