using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}
