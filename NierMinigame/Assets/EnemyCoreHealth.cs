using UnityEngine;

public class EnemyCoreHealth : MonoBehaviour
{
    public float health = 7;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}
