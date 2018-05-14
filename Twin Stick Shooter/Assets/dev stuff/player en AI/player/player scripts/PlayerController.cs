using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    private Rigidbody PlayerRigid;

    // player health 
    [SerializeField]
    private Stat health;
   

    //player input
    private Vector3 MoveInput;
    private Vector3 MoveVelocity;

    //camera
    private Camera MainCamera;

    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private GameObject Bullet_Emitter;
    [SerializeField]
    private float Bullet_force;
    float timer;
    [SerializeField]
    private int MaxShells;
    [SerializeField]
    bool PistolActive;
    [SerializeField]
    bool ShotgunActive;
    [SerializeField]
    bool SubMachineGunActive;

    
    
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        MainCamera = FindObjectOfType<Camera>();
        health.initialize();    

	}
    

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentHealth -= 10;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentHealth += 10;
        }
       
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
            Bullet_Emitter.transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        print(timer);
        
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        PlayerRigid.velocity = MoveVelocity;
        if (PistolActive == true)
        {
           if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (timer >= 0.2)
                {
                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                    Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                    Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                    Destroy(Temporary_Bullet_Handler, 5f);
                    timer = 0;
                }

            }
        }
        if (ShotgunActive == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (timer >= 1)
                {
                    GameObject Temporary_Bullet_Handler = null;
                    Rigidbody Temporary_RigidBody = null;
                    for (int i = 0; i < MaxShells; i++)
                    {
                        Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
                        Temporary_Bullet_Handler.transform.rotation = new Quaternion(180, 0, 0, 0);
                        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                        Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                        Destroy(Temporary_Bullet_Handler, 5f);
                    }
                    timer = 0;
                }

            }
        }
        if (SubMachineGunActive == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (timer >= 0.2)
                {
                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                    Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                    Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                    Destroy(Temporary_Bullet_Handler, 5f);
                    timer = 0;
                }
            }
        }
    }
   
    

}
