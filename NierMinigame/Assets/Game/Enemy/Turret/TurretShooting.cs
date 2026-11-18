using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;            
    public Transform[] directionTargets;     // aim direction aka, child objects

    public float bulletSpeed = 20f;
    public float fireRate = 1f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootAllDirections();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootAllDirections()
    {
        foreach (Transform target in directionTargets)
        {
            Shoot(target);
        }
    }

    void Shoot(Transform target)
    {
        Vector3 direction = (target.position - firePoint.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
    }
}
