using UnityEngine;
using UnityEngine.Events;

public class CoreShieldManager : MonoBehaviour
{
    [Header("Shield Object")]
    public GameObject shieldObject;

    [Header("Called When All Enemies Are Dead")]
    public UnityEvent onAllEnemiesDefeated;

    private bool shieldDisabled = false;

    void Update()
    {
        // Prevent running multiple times
        if (shieldDisabled)
            return;

        // Find all active enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If no enemies remain
        if (enemies.Length == 0)
        {
            shieldDisabled = true;
            DestroyShield();
        }
    }

    public void DestroyShield()
    {
        shieldObject.SetActive(false);

    }
}