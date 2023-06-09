using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public float dampingCoefficient = 5f;
    public float lookSensitivity = 1f;
    Vector3 velocity;

    private float rotHorizontal = 0f;
    private float rotVertical = 0f;

    void Start()
    {
        rotHorizontal = transform.eulerAngles.y;
        rotVertical = transform.eulerAngles.x;
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // Camera movement
            Vector3 movement = default;
            if (Input.GetKey(KeyCode.A))
            {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += Vector3.back;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.forward;
            }
            Vector3 direction = transform.TransformVector(movement.normalized);
            velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime) + direction * movementSpeed;
            transform.position += velocity * Time.deltaTime;

            // Camera rotation
            rotVertical -= lookSensitivity * Input.GetAxis("Mouse Y");
            rotHorizontal += lookSensitivity * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(rotVertical, rotHorizontal, 0f);

            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Cursor.lockState = CursorLockMode.None;
            }

        }
        else 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}
