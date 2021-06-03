using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    float speedMov = 5.0f;
    public int life = 100;
    public int controller;

    float fireRate1;
    float fireCd1 = 2;
    float fireRate2;
    float fireCd2 = 4;


    public Transform fireSpot;
    public GameObject spellShoot;
    public GameObject spellShield;
    public Material capsule;

    Rigidbody rb;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(Attack());
    }

    void FixedUpdate()
    {
        Move();
    }

    public void SetController(int num)
    {
        controller = num;
    }

    void Move()
    {
        float vertical = Input.GetAxisRaw("Joy" + controller + "LeftStickVertical");
        float horizontal = Input.GetAxisRaw("Joy" + controller + "LeftStickHorizontal");

        //float vertical = Input.GetAxisRaw("Vertical");
        //float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(-horizontal, 0, vertical).normalized;
        if (direction.x != 0 || direction.z != 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, 0.5f);
        }

        Vector3 desireVelocity = transform.forward * direction.magnitude * speedMov;
        Vector3 deltaVelocity = desireVelocity - rb.velocity;
        deltaVelocity.y = 0;
        rb.AddForce(deltaVelocity, ForceMode.VelocityChange);

        anim.SetFloat("Speed", direction.magnitude, 0.05f, Time.deltaTime);
    }

    IEnumerator Attack()
    {
        if (Input.GetAxisRaw("Joy" + controller + "Button3") == 1 && Time.time >= fireRate1)
        {
            anim.SetTrigger("Attack");
            fireRate1 = Time.time + fireCd1;
            speedMov = 0;
            yield return new WaitForSeconds(0.5f);
            Instantiate(spellShoot, fireSpot.position, fireSpot.rotation);
            yield return new WaitForSeconds(0.5f);
            speedMov = 5;
        }

        if (Input.GetAxisRaw("Joy" + controller + "Button2") == 1 && Time.time >= fireRate2)
        {
            fireRate2 = Time.time + fireCd2;
            speedMov = 0;
            Instantiate(spellShield, transform.position, transform.rotation);
            yield return new WaitForSeconds(1);
            speedMov = 5;
        }

    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
