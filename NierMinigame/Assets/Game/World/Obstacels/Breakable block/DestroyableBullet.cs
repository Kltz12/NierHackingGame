using UnityEngine;

public class DestroyableBullet : MonoBehaviour
{
    public GameObject bulletHitPrefab;

    public float vfxHeight = 0.02f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Vector3 hitPoint = transform.position;
            hitPoint.y = vfxHeight;

            Instantiate(bulletHitPrefab, hitPoint, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}