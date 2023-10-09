using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Public
    public Transform playerTarget;
    public float stopDistance = 5;
    public FireBulletOnActivate gun;
    public Transform playerHead;

    //Private 
    private NavMeshAgent agent;
    private Animator animator;
    private Quaternion localRotationGun;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("XR Origin").transform;
        playerHead = Camera.main.transform;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        SetupRagdoll();

        localRotationGun = gun.spawnPoint.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Destination of our agent
        agent.SetDestination(playerTarget.position); //no for generating our enemies in run time with prepah 

        //Check Distance 
        float distance = Vector3.Distance(playerTarget.position, transform.position);

        if(distance < stopDistance)
        {
            agent.isStopped = true;
            animator.SetBool("Shoot", true);

            AimAtPlayer();
        }
    }

    private void AimAtPlayer()
    {
        Vector3 playerPosition = playerTarget.position;
        playerPosition.y = transform.position.y;
        transform.LookAt(playerPosition);
    }

    public void ThrowGun()
    {
        gun.spawnPoint.localRotation = localRotationGun;

        gun.transform.parent = null;
        Rigidbody rb = gun.GetComponent<Rigidbody>();

        rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
        rb.angularVelocity = Vector3.zero;
    }

    //Math that goes behing to calculating the projection when the enemy is hit and gun jumsps toward your direction
    Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        //Calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }

    public void ShootEnemy()
    {
        Vector3 playerHeadPosition = playerHead.position - Random.Range(0, 0.4f) * Vector3.up;

        gun.spawnPoint.forward = (playerHeadPosition - gun.spawnPoint.position).normalized;
        gun.FireBullet();
    }

    //Disable th RB at the start of the game so we do not enable the ragdoll 
    public void SetupRagdoll()
    {
        //loop all the RB children of this game object
        foreach(var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }

    //enable is kinematic for all rb
    public void Dead(Vector3 hitPosition)
    {
        //it adds a little explosive force due to the part eaten by the body to make it more realistic
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
        }

        //get all physics items in a radius of 0.3 around the 8th position point 
        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }

        ThrowGun();
        animator.enabled = false;
        agent.enabled = false;
        this.enabled = false;

    }
}
