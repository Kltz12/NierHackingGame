using UnityEngine;
using System.Collections;

public class UIWheelRotate : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private bool RotatingLeft = true;

    [Header("Startup")]
    [SerializeField] private float startingSpeed = 5f;
    [SerializeField] private float accelerationDuration = 0.5f;

    [Header("Shutdown")]
    [SerializeField] private float decelerationDuration = 0.5f;

    private RectTransform rectTransform;
    private float currentSpeed;
    private bool isRotating = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!isRotating)
            return;

        float direction = RotatingLeft ? -1f : 1f;

        rectTransform.Rotate(
            0f,
            0f,
            currentSpeed * direction * Time.deltaTime
        );
    }

    public void StartRotating()
    {
        if (isRotating)
            return;

        StartCoroutine(StartUpCogs());
    }

    public void StopRotating()
    {
        if (!isRotating)
            return;

        StartCoroutine(SlowDownCogs());
    }

    private IEnumerator StartUpCogs()
    {
        isRotating = true;
        currentSpeed = startingSpeed;

        float elapsed = 0f;

        while (elapsed < accelerationDuration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / accelerationDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            currentSpeed = Mathf.Lerp(
                startingSpeed,
                rotationSpeed,
                t
            );

            yield return null;
        }

        currentSpeed = rotationSpeed;
    }

    private IEnumerator SlowDownCogs()
    {
        float startingSpeed = currentSpeed;
        float elapsed = 0f;

        while (elapsed < decelerationDuration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / decelerationDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            currentSpeed = Mathf.Lerp(
                startingSpeed,
                0f,
                t
            );

            yield return null;
        }

        // Completely stopped
        currentSpeed = 0f;
        isRotating = false;

        // Reverse direction for the next transition
        RotatingLeft = !RotatingLeft;
    }
}
