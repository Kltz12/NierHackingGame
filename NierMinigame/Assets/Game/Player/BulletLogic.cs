using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Shield" || other.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
    }
}
