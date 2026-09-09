using UnityEngine;

public class DefaultEnemyShooting : MonoBehaviour
{
    public Transform player;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    public float fireCooldown = 2f;
    private float nextFireTime = 0f;

    [Range(-1f, 1f)]
    public float shootThreshold = 0.8f;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No object with the 'Player' tag was found!");
        }
    }

    void Update()
    {
        TryShoot();
    }

    void TryShoot()
    {
        if (player == null) return;

        if (Time.time < nextFireTime) return;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        float dot = Vector3.Dot(transform.forward, directionToPlayer);

        if (dot >= shootThreshold)
        {
            Shoot(directionToPlayer);
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
    }
}