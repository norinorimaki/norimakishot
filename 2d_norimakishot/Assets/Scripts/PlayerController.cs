using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Animator animator;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed; 
        }

        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }

        bool flipSprite = spriteRenderer.flipX ? (move.x > 0.00f) : (move.x < 0.00f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;   
        }

        targetVelocity = move * maxSpeed;
        
        //AnimatorのtagにSpeedっていうやつを作ったことで、アニメーションの切り替わりを制御している
        animator.SetFloat("Speed", Mathf.Abs(move.x));

    }
}