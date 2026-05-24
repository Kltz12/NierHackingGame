using UnityEngine;

public class TrailController : MonoBehaviour
{
    public Rigidbody playerRb;
    public ParticleSystem trailParticles;

    public float moveThreshold = 0.1f;
    public float emissionRate = 30f;

    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        emission = trailParticles.emission;
        emission.rateOverTime = 0f;
    }

    void Update()
    {
        if (playerRb.linearVelocity.magnitude > moveThreshold)
        {
            emission.rateOverTime = emissionRate;
        }
        else
        {
            emission.rateOverTime = 0f;
        }
    }
}
