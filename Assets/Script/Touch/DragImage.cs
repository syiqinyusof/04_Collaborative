using UnityEngine;
using UnityEngine.EventSystems;

public class DragImage : MonoBehaviour, IDragHandler
{
    private RectTransform imageRectTransform;
    private Canvas canvas;

    void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas.renderMode == RenderMode.WorldSpace)
        {
            imageRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else
        {
            imageRectTransform.anchoredPosition += eventData.delta;
        }
    }
}
