using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        // Save the initial offset (your current nice position)
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Follow player without rotating
        transform.position = player.position + offset;
    }
}