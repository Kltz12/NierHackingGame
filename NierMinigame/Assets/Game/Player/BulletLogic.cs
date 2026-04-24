using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
