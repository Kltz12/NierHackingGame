using UnityEngine;

public class TrailController : MonoBehaviour
{
    public Rigidbody playerRb;
    public ParticleSystem trailParticles;

    public float moveThreshold = 0.1f;
    public float emissionRate = 30f;

    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.ShapeModule shape;

    void Start()
    {
        emission = trailParticles.emission;
        shape = trailParticles.shape;

        emission.rateOverTime = 0f;
    }

    void Update()
    {
        Vector3 velocity = playerRb.linearVelocity;

        if (velocity.magnitude > moveThreshold)
        {
            emission.rateOverTime = emissionRate;

            // Rotate only emission direction
            Vector3 dir = -velocity.normalized;
            shape.rotation = Quaternion.LookRotation(dir).eulerAngles;
        }
        else
        {
            emission.rateOverTime = 0f;
        }
    }
}
