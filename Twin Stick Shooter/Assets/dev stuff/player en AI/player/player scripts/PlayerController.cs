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

<<<<<<< HEAD
    //camera
=======
    [SerializeField]
>>>>>>> 1d2e3ff83f0341c04c16a1d66e290a3d109bcd55
    private Camera MainCamera;

    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private GameObject Bullet_Emitter;
    [SerializeField]
    private GameObject Crosshairs;
    [SerializeField]
    private float Bullet_force;
    float timer;
    [SerializeField]
    private int MaxShells;
    [SerializeField]
    bool PistolActive;
    [SerializeField]
    bool MachineGunActive;
    [SerializeField]
    bool ShotgunActive;

    [SerializeField]
<<<<<<< HEAD
    bool SubMachineGunActive;

    
    
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        MainCamera = FindObjectOfType<Camera>();
        health.initialize();    

=======
    private Text PistolAmmoCount;

    int PistolAmmo;
    int MachineGunAmmo;

    bool ShotgunFired;
	void Start ()
    {
        PlayerRigid = GetComponent<Rigidbody>();
        //MainCamera = FindObjectOfType<Camera>();

        PistolAmmo = 12;
        MachineGunAmmo = 30;

        //Cursor.visible = false;

        Time.timeScale = 1.0f;
>>>>>>> 1d2e3ff83f0341c04c16a1d66e290a3d109bcd55
	}
    

    // Update is called once per frame
    void Update ()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentHealth -= 10;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentHealth += 10;
        }
       
=======
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PistolActive = true;
            ShotgunActive = false;
            MachineGunActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PistolActive = false;
            ShotgunActive = false;
            MachineGunActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PistolActive = false;
            ShotgunActive = true;
            MachineGunActive = false;
        }
        //infinite ammo
        if (Input.GetKeyDown(KeyCode.J))
        {
            PistolAmmo = int.MaxValue;
            MachineGunAmmo = int.MaxValue;
        }

>>>>>>> 1d2e3ff83f0341c04c16a1d66e290a3d109bcd55
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
            Crosshairs.transform.position = (new Vector3(pointToLook.x, Crosshairs.transform.position.y, pointToLook.z));
        }
<<<<<<< HEAD
        print(timer);
        
        
=======
>>>>>>> 1d2e3ff83f0341c04c16a1d66e290a3d109bcd55
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        PlayerRigid.velocity = MoveVelocity;
        if (PistolActive == true)
        {
            Pistol();
        }
        if (ShotgunActive == true)
        {
            Shotgun();
        }
        if (MachineGunActive == true)
        {
            SubMachineGun();   
        }
    }
    public void Pistol()
    {
        PistolAmmoCount.text = "Pistol: " + PistolAmmo;
        if (Input.GetKeyDown(KeyCode.R))
        {
            PistolAmmo = 12;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (PistolAmmo > 0)
            {
                if (timer >= 0.2)
                {
                    PistolAmmo--;
                    Shoot();
                }
            }
        }
    }
    public void SubMachineGun()
    {
        PistolAmmoCount.text = "Machine gun: " + MachineGunAmmo;
        if (Input.GetKeyDown(KeyCode.R))
        {
            MachineGunAmmo = 30;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (MachineGunAmmo > 0)
            {
                if (timer >= 0.2)
                {
                    MachineGunAmmo--;
                    Shoot();
                }
            }
        }
    }
    public void Shotgun()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timer >= 0.5f)
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

<<<<<<< HEAD
                    Destroy(Temporary_Bullet_Handler, 5f);
                    timer = 0;
                }
            }
        }
    }
   
    

=======
                Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

                Destroy(Temporary_Bullet_Handler, 5f);
                timer = 0;
                ShotgunFired = true;
  
            }
        }
    }
    public void Shoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * Bullet_force);

        Destroy(Temporary_Bullet_Handler, 5f);
        timer = 0;
    }
>>>>>>> 1d2e3ff83f0341c04c16a1d66e290a3d109bcd55
}
