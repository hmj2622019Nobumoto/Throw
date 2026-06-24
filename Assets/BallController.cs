using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isHeld { get; private set; } = false;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Catch(Transform holdPoint)
    {
        isHeld = true;
        rb.isKinematic = true;
        rb.Sleep();
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Throw(Vector3 direction, float force)
    {
        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.WakeUp();
        rb.AddForce(direction *  force, ForceMode.Impulse);
        //Debug.Log($"ˆÊ’u: {transform.position} •ûŒü: {direction} —Í: {force}");
    }
}
