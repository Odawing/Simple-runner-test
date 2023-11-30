using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Player player;

    private Vector2 firstPressPos;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                firstPressPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                player.sideMoveVec.x = touch.position.x - firstPressPos.x;
            }
        }
    }
}