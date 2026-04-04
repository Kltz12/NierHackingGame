using UnityEngine;

public class DestroyableBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
