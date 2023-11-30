using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public Rigidbody body;

    private void FixedUpdate()
    {
        body.velocity = Mathf.Sin(Time.timeSinceLevelLoad * speed) * maxDistance * transform.right;
    }
}