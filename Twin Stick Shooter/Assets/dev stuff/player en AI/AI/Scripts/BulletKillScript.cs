using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillScript : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //RaycastHit hit;
        //Physics.Raycast(transform.position, transform.forward * 10f, out hit);
        //Debug.DrawRay(transform.position, transform.forward * 0.25f, Color.red);
        //if (hit.collider.tag == "Enemy")
        //{
        //    Destroy(gameObject);
        //    print("enemy geraakt");
        //}
    }
}
