using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No object with the 'Player' tag was found!");
        }
    }

    void Update()
    {
        if (Player == null) return;

        enemy.SetDestination(Player.position);
    }
}
