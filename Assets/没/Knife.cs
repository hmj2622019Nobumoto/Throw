using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float embedDepth = 0.1f;

    private Rigidbody rb;
    private bool isStuck = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStuck && rb.linearVelocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isStuck) return;

        string hitTag = collision.gameObject.tag;

        if (hitTag.StartsWith("target"))
        {
            StickKnife(collision);

            //ProcessScore(hittag);
        }
    }

    private void StickKnife(Collision collision)
    {
        isStuck = true;

        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position += transform.forward * embedDepth;

        transform.SetParent(collision.transform);
    }

    private void ProcessScore(string tag)
    {
        switch (tag)
        {
            case "Target_Center":
                Debug.Log("Center 100");
                break;
            case "Target_Middle":
                Debug.Log("Middle 50");
                break;
            default:
                Debug.Log("Outside 10");
                break;
        }
    }
}
