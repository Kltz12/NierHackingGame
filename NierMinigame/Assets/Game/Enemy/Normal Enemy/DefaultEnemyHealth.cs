using UnityEngine;

public class DefaultEnemyHealth : MonoBehaviour
{
    public float health = 5;

    [Header("Hit VFX")]
    public GameObject hitVFXPrefab;
    public float vfxHeightOffset = 0.02f;

    void Update()
    {
        if (health <= 0)
        {
            EnemyDead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            SpawnHitVFX(other.transform.position);

            health -= 1;

            Destroy(other.gameObject);
        }
    }

    void SpawnHitVFX(Vector3 hitPosition)
    {
        hitPosition.y += vfxHeightOffset;

        Instantiate(
            hitVFXPrefab,
            hitPosition,
            Quaternion.identity
        );
    }

    public void EnemyDead()
    {
        Destroy(transform.root.gameObject);
    }
}
