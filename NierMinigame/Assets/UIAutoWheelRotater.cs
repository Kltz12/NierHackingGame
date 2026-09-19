using UnityEngine;

public class UIAutoWheelRotater : MonoBehaviour
{
    public float RotationSpeed = 45f;
    public bool RotatingLeft = true;

    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RotatingLeft)
        {
          rectTransform.Rotate(0f,0f,RotationSpeed * -Time.deltaTime);
        }
        else
        {
            rectTransform.Rotate(0f,0f,RotationSpeed * Time.deltaTime);
        }
    }
}
