using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LevelButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Fill")]
    [SerializeField] private Slider fillSlider;
    [SerializeField] private float fillDuration = 0.5f;

    [Header("Top and Bottom Bars")]
    [SerializeField] private CanvasGroup topBar;
    [SerializeField] private CanvasGroup bottomBar;
    [SerializeField] private float barFadeDuration = 0.1f;

    [Header("Block")]
    [SerializeField] private CanvasGroup block;
    [SerializeField] private Image blockImage;
    [SerializeField] private Color hoveredBlockColor = new Color32(72, 69, 58, 255);
    [SerializeField] private float blockFadeDuration = 0.05f;

    [Header("Text")]
    [SerializeField] private CanvasGroup text;
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private Color hoveredTextColor = new Color32(72, 69, 58, 255);
    [SerializeField] private float textFadeDuration = 0.05f;

    private float targetFill = 0f;

    private bool isHovering = false;
    private bool blockHasChanged = false;
    private bool textHasChanged = false;

    private Color originalBlockColor;
    private Color originalTextColor;

    private void Start()
    {
        fillSlider.value = 0f;

        if (topBar != null)
            topBar.alpha = 0f;

        if (bottomBar != null)
            bottomBar.alpha = 0f;

        if (block != null)
            block.alpha = 1f;

        if (text != null)
            text.alpha = 1f;

        if (blockImage != null)
            originalBlockColor = blockImage.color;

        if (textComponent != null)
            originalTextColor = textComponent.color;
    }

    private void Update()
    {
        // =========================
        // Fill animation
        // =========================

        if (fillSlider != null)
        {
            fillSlider.value = Mathf.MoveTowards(
                fillSlider.value,
                targetFill,
                Time.deltaTime / fillDuration
            );
        }


        // =========================
        // Top and bottom bars
        // =========================

        float targetAlpha = targetFill > 0f ? 1f : 0f;

        if (topBar != null)
        {
            topBar.alpha = Mathf.MoveTowards(
                topBar.alpha,
                targetAlpha,
                Time.deltaTime / barFadeDuration
            );
        }

        if (bottomBar != null)
        {
            bottomBar.alpha = Mathf.MoveTowards(
                bottomBar.alpha,
                targetAlpha,
                Time.deltaTime / barFadeDuration
            );
        }


        // =========================
        // Block fade-out
        // =========================

        if (block != null && isHovering && !blockHasChanged)
        {
            block.alpha = Mathf.MoveTowards(
                block.alpha,
                0f,
                Time.deltaTime / blockFadeDuration
            );

            if (block.alpha <= 0f)
            {
                blockImage.color = hoveredBlockColor;
                block.alpha = 1f;

                blockHasChanged = true;
            }
        }


        // =========================
        // Text fade-out
        // =========================

        if (text != null && isHovering && !textHasChanged)
        {
            text.alpha = Mathf.MoveTowards(
                text.alpha,
                0f,
                Time.deltaTime / textFadeDuration
            );

            if (text.alpha <= 0f)
            {
                textComponent.color = hoveredTextColor;
                text.alpha = 1f;

                textHasChanged = true;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        targetFill = 1f;

        blockHasChanged = false;
        textHasChanged = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        targetFill = 0f;

        // Restore block
        if (block != null)
            block.alpha = 1f;

        if (blockImage != null)
            blockImage.color = originalBlockColor;

        // Restore text
        if (text != null)
            text.alpha = 1f;

        if (textComponent != null)
            textComponent.color = originalTextColor;

        blockHasChanged = false;
        textHasChanged = false;
    }
}