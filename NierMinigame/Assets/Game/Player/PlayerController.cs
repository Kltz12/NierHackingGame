using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 5f;

    [SerializeField] private Camera cam;

    public bool isLocked = false;

    [Header("Arena Bounds")]
    [SerializeField] private float minX = -12.5f;
    [SerializeField] private float maxX = 12.5f;
    [SerializeField] private float minZ = -12.5f;
    [SerializeField] private float maxZ = 12.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        if (isLocked)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 movement = new Vector3(movementX, 0f, movementY);

        rb.linearVelocity = movement * speed;

        ClampPosition();

        RotateToMouse();
    }

    void ClampPosition()
    {
        Vector3 pos = rb.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        rb.position = pos;
    }

    void RotateToMouse()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y;

            Vector3 direction = (target - transform.position).normalized;

            if (direction != Vector3.zero)
            {
                transform.forward = -direction;
            }
        }
    }
}