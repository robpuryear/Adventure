﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MapMovementController moveController;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        moveController = GetComponent<MapMovementController>();
        moveController.moveActionCallback += OnMove;
        moveController.tileActionCallback += OnTile;

        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    void OnMove()
    {
        animator.speed = 1;
    }

    void OnTile(int type)
    {
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir.y = -1;
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir.x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir.y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir.x = -1;
        }

        if(dir.x != 0 || dir.y != 0)
        {
            moveController.MoveInDirection(dir);
        }
    }
}
