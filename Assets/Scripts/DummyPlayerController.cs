using UnityEngine;

public class DummyPlayerController : MonoBehaviour
{
    private Rigidbody dummyRb;
    private float dummyForce = 30000.0f;
    // Start is called before the first frame update
    void Start()
    {
        dummyRb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        dummyRb.AddForce(Vector3.up * dummyForce * Time.deltaTime);
    }

    public void Fire()
    {
        dummyRb.AddExplosionForce(dummyForce, transform.position, 30.0f);
    }
}
