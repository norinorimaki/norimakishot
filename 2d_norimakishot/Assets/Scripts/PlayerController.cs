using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    [SerializeField]public float wallKickStrength = 4;
    public Animator animator;
    [SerializeField]private int maxDoubleJumpTimes = 3;
    private int doubleJumpTimes = 0;
    [SerializeField]private bool isTouchingWall;
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

        if (move.x > 0.00f){
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if(wallKickStrength>0){
            wallKickStrength = -1 * wallKickStrength;
            }
        }

        else if (move.x < 0.00f){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            wallKickStrength = Mathf.Abs(wallKickStrength);
        }
        
        if(!grounded && Input.GetButtonDown("Jump") && doubleJumpTimes<maxDoubleJumpTimes){
                velocity.y = jumpTakeOffSpeed;
                doubleJumpTimes ++ ;
        } 
        if(grounded){
            doubleJumpTimes = 0;
        }
        if(!grounded && move.x != 0 && isTouchingWall && Input.GetButtonDown("Jump")){
            velocity.y = jumpTakeOffSpeed;
            
        }

        targetVelocity = move * maxSpeed;

        animator.SetFloat("Speed", Mathf.Abs(move.x));

    }
}