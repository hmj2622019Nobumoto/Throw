using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private float throwForce = 25f;
    [SerializeField] private float catchRadius = 3.0f;

    private CharacterController controller;
    private Transform cameraTransform;
    private float xRotation = 0f;
    private Rigidbody caughtBall = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // handleMovement();
        //HandleLook();
        if (
    }
}
