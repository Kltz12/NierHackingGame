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
        string[] tags =
        {
            "Enemy",
            "EnemyBullet",
            "EnemyCore"
        };

        foreach (string tag in tags)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
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
