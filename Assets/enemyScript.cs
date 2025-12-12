using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float spd;

    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform, transform.up);
        transform.Translate(transform.forward * -spd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerAttack")
        {
            Destroy(gameObject);
        }
    }
}
