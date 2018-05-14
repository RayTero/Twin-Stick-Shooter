using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorScript : MonoBehaviour
{

    [SerializeField]
    private Animator Door;

    bool PlayerAtDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerAtDoor = true;
        }
    }
    // Use this for initialization
    void Start()
    {
        Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAtDoor == true)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
                Door.SetBool("Close", true);
            //}
        }
    }
}
