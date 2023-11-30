using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove = true;

    public float forwardSpeed, sideSpeed;

    public Vector3 sideMoveVec;

    private Rigidbody body;
    private Collider coll;
    private Animator animator;

    private SplineFollower splineFollower;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        splineFollower = GetComponentInParent<SplineFollower>();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        // Movement
        sideMoveVec *= Time.deltaTime * sideSpeed;
        var rotatedVec = splineFollower.transform.rotation * sideMoveVec;

        body.velocity = rotatedVec;
        splineFollower.followSpeed = forwardSpeed;

        animator.SetFloat("posX", sideMoveVec.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!canMove) return;

        if (collision.collider.CompareTag("Obstacle"))
        {
            Death();
        }
    }

    public void OnRoadEnd()
    {
        canMove = false;
        body.isKinematic = true;
        coll.enabled = false;

        animator.Play("Dance");

        GameManagerScr.Instance.OnEndLevel();
    }

    public void Death()
    {
        canMove = false;
        body.isKinematic = true;
        coll.enabled = false;
        splineFollower.enabled = false;

        animator.Play("Death");

        GameManagerScr.Instance.OnPlayerDeath();
    }
}
