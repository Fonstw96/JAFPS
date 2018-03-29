using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {Patrol, Chase };

public class EnemyFollow : MonoBehaviour
{
    public float fMovementSpeed = .2f;
    public float fTurnMin = 1.7f;
    public float fTurnMax = 4.8f;
    
    private State currentState = State.Patrol;
    private float fTurnTimer;

    private Collider clTarget;
    private Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        if (myAnimator == null)
            print("Enemy has no animator");
    }

    void Update()
    {
        if (currentState == State.Patrol)
            Patrol();
        else
            Chase();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Please don't attack walls
        if (other.tag == "Player")
        {
            currentState = State.Chase;
            myAnimator.SetBool("ChaseMode", true);

            clTarget = other;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Please don't be calmed down by walls
        if (other.tag == "Player")
        {
            currentState = State.Patrol;
            myAnimator.SetBool("ChaseMode", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myAnimator.SetTrigger("Attack");
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHP(-1);
        }
        else if (collision.gameObject.tag == "Wall")
            transform.Rotate(0, 180, 0);
    }

    private void Patrol()
    {
        if (fTurnTimer < Time.time)
        {
            transform.Rotate(0, Random.Range(.1f, 365f), 0);

            fTurnTimer = Time.time + Random.Range(fTurnMin, fTurnMax);
        }

        transform.position += transform.forward * fMovementSpeed / 5 * Time.deltaTime;
    }

    private void Chase()
    {
        // For readability
        Transform tTarget = clTarget.transform;

        // Actual movement
        transform.LookAt(new Vector3(tTarget.position.x, transform.position.y, tTarget.position.z));
        transform.position += transform.forward * fMovementSpeed * Time.deltaTime;
    }
}
