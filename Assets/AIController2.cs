using UnityEngine;
using System.Collections;
public class AIController2 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float throwSpeed = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                other.transform.position = transform.position + transform.forward * 1.0f;

                Vector3 direction = Vector3.zero;
                direction.y += 0.2f;

                rb.linearVelocity = Vector3.zero;
                rb.AddForce(direction * throwSpeed, ForceMode.Impulse);
            }
        }
    }
}
