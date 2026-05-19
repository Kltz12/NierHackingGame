using UnityEngine;

public class EnemyCoreHealth : MonoBehaviour
{
    public float health = 7;

    [SerializeField] private WinLoseManager WinloseManager;

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
        WinloseManager.GameWon();
        Destroy(gameObject);

    }
}
