using UnityEngine;
using UnityEngine.EventSystems;

public class FreeCamController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float shiftMultiplier = 2.5f;
    public float lookSpeed = 2.5f;
    public float zoomSpeed = 10f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotationX = rot.y;
        rotationY = rot.x;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= shiftMultiplier;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;

        if (Input.GetKey(KeyCode.E)) moveY = 1;
        if (Input.GetKey(KeyCode.Q)) moveY = -1;

        Vector3 move = transform.right * moveX + transform.forward * moveZ + transform.up * moveY;
        transform.position += move * currentSpeed * Time.deltaTime;
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * lookSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY = Mathf.Clamp(rotationY, -89f, 89f);

            transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
        }

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.position += transform.forward * scroll * zoomSpeed;
        }
    }
}