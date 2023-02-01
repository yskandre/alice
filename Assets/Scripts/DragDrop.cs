using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] Canvas canvas;
    public int id;
    [SerializeField] string shortText;
    public TextMeshProUGUI textField;
    private string fullText;
    private RectTransform self;
    private Vector2 initialSize;
    private Vector2 initialPos;
    private CanvasGroup canvasGroup;
    public bool slotted = false;

    private void Awake()
    {
        self = GetComponent<RectTransform>();
        initialSize = self.sizeDelta;
        initialPos = self.anchoredPosition;
        fullText = textField.text;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        slotted = false;
        SimplifyText();
        self.sizeDelta = initialSize;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!slotted)
        {
            textField.text = fullText;
            textField.alignment = TextAlignmentOptions.Center;
        }
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        self.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void SimplifyText()
    {
        if (shortText != "") textField.text = shortText;
        textField.alignment = TextAlignmentOptions.Center;
    }

    public void ResetState(){
        self = GetComponent<RectTransform>();
        self.sizeDelta = initialSize;
        self.anchoredPosition = initialPos;
        textField.text = fullText;
        GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }
}
