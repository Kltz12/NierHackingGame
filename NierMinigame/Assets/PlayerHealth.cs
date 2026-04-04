using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;

    public GameObject PlayerAtHealth2P1;
    public GameObject PlayerAtHealth2P2;
     public GameObject PlayerAtHealth1P1;
    public GameObject PlayerAtHealth1P2;


    void Start()
    {
        PlayerAtHealth2P1.gameObject.SetActive(true);
        PlayerAtHealth2P2.gameObject.SetActive(true);
        PlayerAtHealth1P1.gameObject.SetActive(true);
        PlayerAtHealth1P2.gameObject.SetActive(true);
    }

    void Update()
    {
        if (health == 3)
        {
            PlayerAtHealth2P1.gameObject.SetActive(true);
            PlayerAtHealth2P2.gameObject.SetActive(true);
            PlayerAtHealth1P1.gameObject.SetActive(true);
            PlayerAtHealth1P2.gameObject.SetActive(true);
        }

        if (health == 2)
        {
            PlayerAtHealth2P1.gameObject.SetActive(false);
            PlayerAtHealth2P2.gameObject.SetActive(false);
        }

         if (health == 1)
        {
            PlayerAtHealth1P1.gameObject.SetActive(false);
            PlayerAtHealth1P2.gameObject.SetActive(false);
        }

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
