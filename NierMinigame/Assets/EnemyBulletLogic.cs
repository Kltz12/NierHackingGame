using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
    }
}