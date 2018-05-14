using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WalkerScript : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target, m_StartPoint;
    private NavMeshAgent m_NavMeshAgent;
    [SerializeField]
    private GameObject Bullet_Emitter;
    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private GameObject Speler;
    [SerializeField]
    private float Bullet_Forward_Force;
    float timer;
    private bool WalkerStart = true;
    bool WalkerDuring = false;

    RaycastHit m_RayHit;

    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.SetDestination(m_StartPoint.position);
    }

    private float Distance(Vector3 objectA, Vector3 objectb)
    {
        return Vector3.Distance(objectA, objectb);
    }
    void Update()
    {
        if (WalkerDuring == true)
        {
            if (timer >= 10)
            {
                m_NavMeshAgent.SetDestination(m_StartPoint.position);
                timer = 0;
                WalkerDuring = false;
            }
        }

        //field of view dingen
        Vector3 targetDir = m_Target.position - transform.position;

        float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));


        //&& angleToPlayer >= -60 && angleToPlayer <= 60
        //Debug.Log(m_RayHit.collider.name);
            //Debug.DrawLine(transform.position, m_RayHit.point, Color.green);
        
    }
    private void FixedUpdate()
    {
        Vector3 Direction = (m_Target.position - transform.position).normalized;
        if (Physics.Raycast(transform.position, Direction, out m_RayHit, 15f))
        {
            if (m_RayHit.collider.tag == "Player")
            {
                m_NavMeshAgent.SetDestination(m_Target.position);
                if (Distance(transform.position, m_Target.position) < 15f)
                {
                    timer += 1 * Time.deltaTime;
                    if (timer >= 1)
                    {
                        GameObject Temporary_Bullet_Handler;
                        Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                        Rigidbody Temporary_RigidBody;
                        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                        Destroy(Temporary_Bullet_Handler, 25f);
                        timer = 0;
                    }
                }
            }
            else
            {
                WalkerDuring = true;
            }
        }
        Debug.DrawRay(transform.position, Direction * 15f, Color.red);
    }
}

