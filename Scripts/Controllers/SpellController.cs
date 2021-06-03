using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{

    Rigidbody rb;

    float speed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 desireVelocity = transform.forward * speed;
        Vector3 deltaVelocity = desireVelocity - rb.velocity;
        deltaVelocity.y = 0;
        rb.AddForce(deltaVelocity, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider != null)
        {
            if (other.collider.CompareTag("Player"))
            {
                other.collider.GetComponent<PlayerControll>().TakeDamage(10);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
