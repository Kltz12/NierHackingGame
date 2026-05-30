using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public GameObject impactVFXPrefab;

    public float minX = -12.5f;
    public float maxX = 12.5f;
    public float minZ = -12.5f;
    public float maxZ = 12.5f;

    public float vfxHeight = 0.02f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") ||
            other.CompareTag("Shield") ||
            other.CompareTag("Lava"))
        {
            Vector3 hitPoint = transform.position;

            // XZ clamp (fixes out-of-bounds issue)
            hitPoint.x = Mathf.Clamp(hitPoint.x, minX, maxX);
            hitPoint.z = Mathf.Clamp(hitPoint.z, minZ, maxZ);

            // Y lock (fixes floating height issue)
            hitPoint.y = vfxHeight;

            Instantiate(impactVFXPrefab, hitPoint, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}