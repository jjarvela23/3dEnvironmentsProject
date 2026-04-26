using UnityEngine;

public class BallFriction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        body.AddForce(new Vector3(0f, -40f, 0f), ForceMode.Acceleration);
    }
}
