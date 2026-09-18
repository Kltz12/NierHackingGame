using UnityEngine;
using System.Collections;

public class MoveMenu : MonoBehaviour
{
    [SerializeField] private RectTransform menuContainer;
    [SerializeField] private float moveDistance = 400f;
    [SerializeField] private float moveDuration = 0.75f;

    [Header("Cogs")]
    [SerializeField] private UIWheelRotate[] cogs;

    private Vector2 startPosition;
    private Vector2 levelSelectPosition;

    private void Start()
    {
        startPosition = menuContainer.anchoredPosition;
        levelSelectPosition = startPosition + Vector2.up * moveDistance;
    }

    public void ToLVLSelect()
    {
        StartCoroutine(MoveMenuTo(levelSelectPosition));
    }

    public void ToMainMenu()
    {
        StartCoroutine(MoveMenuTo(startPosition));
    }

    private IEnumerator MoveMenuTo(Vector2 targetPosition)
    {
        // Start cogs
        foreach (UIWheelRotate cog in cogs)
        {
            cog.StartRotating();
        }

        Vector2 currentPosition = menuContainer.anchoredPosition;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / moveDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            menuContainer.anchoredPosition = Vector2.Lerp(
                currentPosition,
                targetPosition,
                t
            );

            yield return null;
        }

        menuContainer.anchoredPosition = targetPosition;

        // Stop cogs when movement is finished
        foreach (UIWheelRotate cog in cogs)
        {
            cog.StopRotating();
        }
    }
}