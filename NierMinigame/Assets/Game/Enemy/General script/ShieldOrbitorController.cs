using UnityEngine;

public class ShieldOrbitController : MonoBehaviour
{
    public Transform center;
    public Transform shield1;
    public Transform shield2;

    public float radius = 2f;
    public float speed = 90f;

    private float angle;

    private Quaternion shield1InitialRot;
    private Quaternion shield2InitialRot;

    void Start()
    {
        // Store original rotations
        shield1InitialRot = shield1.rotation;
        shield2InitialRot = shield2.rotation;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        UpdateShield(shield1, angle, shield1InitialRot);
        UpdateShield(shield2, angle + 180f, shield2InitialRot);
    }

    void UpdateShield(Transform shield, float currentAngle, Quaternion initialRot)
    {
        float rad = currentAngle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;

        shield.position = center.position + offset;

        // Base rotation: face outward
        Quaternion lookRot = Quaternion.LookRotation(offset);

        // Combine with original rotation
        shield.rotation = lookRot * initialRot;
    }
}