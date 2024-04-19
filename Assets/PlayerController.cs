using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float friction;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (moveDir == Vector3.zero)
        {
            Vector3 newVel = Vector3.Lerp(Vector3.zero, rb.velocity, friction);
            newVel.y = rb.velocity.y;
            rb.velocity = newVel;
        }
        rb.AddForce(moveDir * acceleration);
        Vector2 clampedVel = Vector2.ClampMagnitude(new Vector2(rb.velocity.x, rb.velocity.z), maxSpeed);
        rb.velocity = new Vector3(clampedVel.x, rb.velocity.y, clampedVel.y);
    }
}
