using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    private Rigidbody PlayerRigid;

    private Vector3 MoveInput;
    private Vector3 MoveVelocity;

    private Camera MainCamera;

    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private GameObject Bullet_Emitter;
    [SerializeField]
    private float Bullet_force;
    int timer;
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        MainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        MoveVelocity = MoveInput * moveSpeed;

        Ray CameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        Plane worldPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (worldPlane.Raycast(CameraRay, out rayLength))
        {
            Vector3 pointToLook = CameraRay.GetPoint(rayLength);
            Debug.DrawLine(CameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        print(timer);
    }

    private void FixedUpdate()
    {
        PlayerRigid.velocity = MoveVelocity;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            timer++;
            if (timer >= 1)
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                Destroy(Temporary_Bullet_Handler, 25f);
                timer = 0;
            }

        }
    }
}
