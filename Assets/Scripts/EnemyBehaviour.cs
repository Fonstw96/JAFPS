using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float fMovementSpeed = 10.8f;
    public Collider clTarget;   // Please do not set this

    public virtual void Patrol()
    {
    }

    public virtual void Chase()
    {
    }
}
