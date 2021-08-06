using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : canMove
{
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor( new Vector3(x, y, 0) );

    if(x != 0 || y != 0) animator.SetBool("moving", true); else animator.SetBool("moving", false);
    }
}
