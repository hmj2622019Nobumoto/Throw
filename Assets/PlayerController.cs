using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float throwForce = 12f;
    [SerializeField] private float catchRange = 2f;

    private Vector2 dragStart;
    private bool hasBall = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }
    // Update is called once per frame
    void Update()
    {
        TryAutoCatch();
        HandleThrowInput();
    }

    private void TryAutoCatch()
    {
        if (hasBall || ball == null || ball.isHeld) return;
        float dist = Vector3.Distance(transform.position, ball.transform.position);
        if (dist > catchRange)
        {
            ball.Catch(holdPoint);
            hasBall = true;
        }
    }

    private void HandleThrowInput()
    {
        if (!hasBall) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 throwDir = mainCamera.transform.forward;
            ball.Throw(throwDir.normalized, throwForce);
            hasBall= false;
        }   
    }
}
