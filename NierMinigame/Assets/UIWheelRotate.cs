using UnityEngine;

public class UIWheelRotate : MonoBehaviour
{
  public float rotationSpeed = 75f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.Rotate(0f, 0f, rotationSpeed * -Time.deltaTime);
    }
}
