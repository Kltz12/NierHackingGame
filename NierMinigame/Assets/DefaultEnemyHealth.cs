using UnityEngine;

public class DefaultEnemyHealth : MonoBehaviour
{
    public float health = 5;

    void Update()
    {
        if (health <= 0)
        {
            EnemyDead();
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

    public void EnemyDead()
    {
        Destroy(gameObject);
    }
}
