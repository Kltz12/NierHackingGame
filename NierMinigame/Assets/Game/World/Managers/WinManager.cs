using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerShooting playerShooting;

    void Start()
    {
        canvas.SetActive(false);
    }

    public void GameWon()
    {
        DestroyAllEnemies();
        LockPlayerMovement();

        Invoke(nameof(ShowCanvas), 1f);
    }

    public void DestroyAllEnemies()
{
    // DEFAULT ENEMIES
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    foreach (GameObject enemy in enemies)
    {
        DefaultEnemyHealth health = enemy.GetComponent<DefaultEnemyHealth>();

        if (health != null)
        {
            health.EnemyDead();
        }
    }


    // ENEMY BULLETS
    GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

    foreach (GameObject bullet in bullets)
    {
        Destroy(bullet);
    }
}

    public void LockPlayerMovement()
    {
        playerController.isLocked = true;
        playerShooting.isLocked = true;
    }

    void ShowCanvas()
    {
    canvas.SetActive(true);
    }
}
