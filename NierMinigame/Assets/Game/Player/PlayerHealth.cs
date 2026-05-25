using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;

    public float damage = 1;

    public GameObject PlayerAtHealth2P1;
    public GameObject PlayerAtHealth2P2;
    public GameObject PlayerAtHealth1P1;
    public GameObject PlayerAtHealth1P2;

    public bool IsInvincible = false;
    public float InvincibleTime = 3.0f;

    private float invincibleTimer;

    [SerializeField] private WinLoseManager WinloseManager;

    [SerializeField] private PlayerHitVFX hitVFX;

    void Start()
    {
        PlayerAtHealth2P1.SetActive(true);
        PlayerAtHealth2P2.SetActive(true);
        PlayerAtHealth1P1.SetActive(true);
        PlayerAtHealth1P2.SetActive(true);
    }

    void Update()
    {
        // Health visuals
        if (health == 3)
        {
            PlayerAtHealth2P1.SetActive(true);
            PlayerAtHealth2P2.SetActive(true);
            PlayerAtHealth1P1.SetActive(true);
            PlayerAtHealth1P2.SetActive(true);
        }

        if (health == 2)
        {
            PlayerAtHealth2P1.SetActive(false);
            PlayerAtHealth2P2.SetActive(false);
        }

        if (health == 1)
        {
            PlayerAtHealth1P1.SetActive(false);
            PlayerAtHealth1P2.SetActive(false);
        }

        if (health <= 0)
        {
            PlayerDead();
        }

        // Invincibility timer
        if (IsInvincible)
        {
            BeInvincible();
        }
    }

   private void OnTriggerEnter(Collider other)
{
    if (IsInvincible)
    {
        if (other.CompareTag("EnemyBullet"))
            Destroy(other.gameObject);

        return;
    }

    if (other.CompareTag("EnemyBullet") || other.CompareTag("Lava"))
    {
        IsInvincible = true;
        invincibleTimer = InvincibleTime;

        health -= damage;
        hitVFX.PlayHitEffect();

        if (other.CompareTag("EnemyBullet"))
            Destroy(other.gameObject);

        Debug.Log("Player got hit");
    }
}

    

    private void BeInvincible()
    {
        invincibleTimer -= Time.deltaTime;

        if (invincibleTimer <= 0f)
        {
            IsInvincible = false;
        }
    }

    public void PlayerDead()
    {
        WinloseManager.GameLost();
        Destroy(gameObject);
    }
}
