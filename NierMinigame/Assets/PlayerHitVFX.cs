using System.Collections;
using UnityEngine;

public class PlayerHitVFX : MonoBehaviour
{
    [Header("Player Parts")]
    public Renderer[] playerRenderers;

    public Material normalMaterial;
    public Material blackMaterial;

    [Header("Camera Shake")]
    public CameraShake cameraShake;

    [Header("Timing")]
    public float flashTime = 0.1f;

    public void PlayHitEffect()
    {
        StopAllCoroutines();
        StartCoroutine(HitRoutine());
    }

    private IEnumerator HitRoutine()
    {
        // Turn ALL parts black
        SetMaterial(blackMaterial);

        // Camera shake
        if (cameraShake != null)
        {
            cameraShake.ShakeCamera(0.2f, 0.05f, true, true);
        }

        yield return new WaitForSeconds(flashTime);

        // Restore normal
        SetMaterial(normalMaterial);
    }

    private void SetMaterial(Material mat)
    {
        for (int i = 0; i < playerRenderers.Length; i++)
        {
            if (playerRenderers[i] != null)
            {
                playerRenderers[i].material = mat;
            }
        }
    }
}
