using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourFlutter : EnemyBehaviour
{
    public float fTurnMin = 5;

    private float fTurnTimer;

    public override void Patrol()
    {
        if (fTurnTimer < Time.time)
        {
            transform.Rotate(0, 180, 0);

            fTurnTimer = Time.time + fTurnMin;
        }

        transform.position -= transform.forward * fMovementSpeed / 3.5f * Time.deltaTime;
    }

    public override void Chase()
    {
        // For readability
        Transform tTarget = clTarget.transform;

        // Actual movement
        transform.LookAt(tTarget);
        transform.position += transform.forward * fMovementSpeed * Time.deltaTime;
    }
}
