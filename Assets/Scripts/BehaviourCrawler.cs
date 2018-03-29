using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourCrawler : EnemyBehaviour
{
    public float fTurnMin = 1.7f;
    public float fTurnMax = 4.8f;

    private float fTurnTimer;

    public override void Patrol()
    {
        if (fTurnTimer < Time.time)
        {
            transform.Rotate(0, Random.Range(.1f, 365f), 0);

            fTurnTimer = Time.time + Random.Range(fTurnMin, fTurnMax);
        }

        transform.position += transform.forward * fMovementSpeed / 5 * Time.deltaTime;
    }

    public override void Chase()
    {
        // For readability
        Transform tTarget = clTarget.transform;

        // Actual movement
        transform.LookAt(new Vector3(tTarget.position.x, transform.position.y, tTarget.position.z));
        transform.position += transform.forward * fMovementSpeed * Time.deltaTime;
    }
}
