using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour {

    [SerializeField]
    private GameObject Speler;
    [SerializeField]
    private GameObject lift;

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Camera LiftCamera;

    Vector3 speed;
    bool OnLift;
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Speler.transform.SetParent(transform);
            ActivateLift();
            MainCamera.enabled = false;
            LiftCamera.enabled = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Speler.transform.parent = null;
            OnLift = false;
            MainCamera.enabled = true;
            LiftCamera.enabled = false;
        }
    }
    // Use this for initialization
    void Start ()
    {
        speed.y = 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OnLift == true)
        {
            transform.position -= speed;
        }
    }

    public void ActivateLift()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnLift = true;
        }
    }
}
