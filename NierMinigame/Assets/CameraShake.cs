using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public FollowPlayer followPlayer;

    private bool isShaking = false;

    public void ShakeCamera(float duration, float severity, bool vertical, bool horizontal)
    {
        if (!isShaking)
            StartCoroutine(Shake(duration, severity, vertical, horizontal));
    }

    private IEnumerator Shake(float duration, float severity, bool vertical, bool horizontal)
    {
        Debug.Log("SHAKING CAMERA" + duration + severity);
        isShaking = true;

        float timer = 0f;

        while (timer < duration)
        {
            Vector3 shake = Vector3.zero;

            if (horizontal)
                shake.x = Random.Range(-1f, 1f) * severity;

            if (vertical)
                shake.y = Random.Range(-1f, 1f) * severity;

            followPlayer.shakeOffset = shake;

            timer += Time.deltaTime;
            yield return null;
        }

        followPlayer.shakeOffset = Vector3.zero;
        isShaking = false;
    }
}
