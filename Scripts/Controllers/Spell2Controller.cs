using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2Controller : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControll>().TakeDamage(10);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
