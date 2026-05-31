using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactVFX : MonoBehaviour
{
    public GameObject impactQuad;

    [Header("Particles")]
    public GameObject pixelPrefab;
    public int pixelCount = 8;

    [Tooltip("Half size of the square spawn area")]
    public float spawnHalfSize = 0.8f;

    public float pixelHeightOffset = 0.1f;

    [Header("Ring / Lines")]
    public GameObject impactRing;
    public GameObject impactLines;

    [Header("Timing")]
    public float squareTime = 2f;
    public float pixelLifeTime = 3f;
    public float lineDuration = 0.2f;

    private List<GameObject> spawnedPixels = new List<GameObject>();

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        // STEP 1: square
        impactQuad.SetActive(true);

        // STEP 2: structured pixel field
        SpawnPixels();

        // STEP 3: square disappears
        yield return new WaitForSeconds(squareTime);
        impactQuad.SetActive(false);

        // STEP 4: pixel scrambling
        yield return StartCoroutine(ShufflePixels(2, 1f));

        // STEP 5: pixels → ring
        yield return StartCoroutine(RemovePixels());
        impactRing.SetActive(true);

        yield return new WaitForSeconds(pixelLifeTime);
        impactRing.SetActive(false);

        // STEP 6: ring → lines
        impactLines.SetActive(true);

        yield return new WaitForSeconds(lineDuration);

        Destroy(gameObject);
    }

    void SpawnPixels()
    {
        for (int i = 0; i < pixelCount; i++)
        {
            // Square field position
            float x = Random.Range(-spawnHalfSize, spawnHalfSize);
            float z = Random.Range(-spawnHalfSize, spawnHalfSize);

            // Slight center bias (important for NieR-like feel)
            float bias = Random.Range(0.6f, 1f);

            Vector3 spawnPos = transform.position + new Vector3(
                x * bias,
                pixelHeightOffset,
                z * bias
            );

            GameObject pixel = Instantiate(
                pixelPrefab,
                spawnPos,
                pixelPrefab.transform.rotation,
                transform
            );

            spawnedPixels.Add(pixel);
        }
    }

    IEnumerator ShufflePixels(int times, float interval)
    {
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(interval);

            foreach (GameObject pixel in spawnedPixels)
            {
                if (pixel == null) continue;

                float x = Random.Range(-spawnHalfSize, spawnHalfSize);
                float z = Random.Range(-spawnHalfSize, spawnHalfSize);

                float bias = Random.Range(0.6f, 1f);

                Vector3 newPos = transform.position + new Vector3(
                    x * bias,
                    pixelHeightOffset,
                    z * bias
                );

                pixel.transform.position = newPos;
            }
        }
    }

    IEnumerator RemovePixels()
    {
        foreach (GameObject pixel in spawnedPixels)
        {
            if (pixel != null)
                Destroy(pixel);
        }

        spawnedPixels.Clear();

        yield return null;
    }
}