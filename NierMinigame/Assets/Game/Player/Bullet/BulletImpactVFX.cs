using System.Collections;
using UnityEngine;

public class BulletImpactVFX : MonoBehaviour
{
    public GameObject impactQuad;
    public float flashDuration = 2f;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        impactQuad.SetActive(true);

        yield return new WaitForSeconds(flashDuration);

        Destroy(gameObject);
    }
}