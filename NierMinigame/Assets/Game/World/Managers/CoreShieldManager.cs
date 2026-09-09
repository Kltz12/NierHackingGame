using UnityEngine;
using UnityEngine.Events;

public class CoreShieldManager : MonoBehaviour
{
    public GameObject shieldObject;
    public UnityEvent onAllEnemiesDefeated;

    private bool shieldDestroyed = false;

    void Update()
    {
        if (shieldDestroyed)
            return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            DestroyShield();
        }
    }

    public void DestroyShield()
    {
        shieldDestroyed = true;

        if (shieldObject != null)
            shieldObject.SetActive(false);

        onAllEnemiesDefeated?.Invoke();
    }
}