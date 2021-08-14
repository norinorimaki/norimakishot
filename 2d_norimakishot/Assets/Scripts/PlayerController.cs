using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Animator animator;

[Header("For Wall Sliding")]
    [SerializeField] float wallSlideSpeed = 0f;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    private bool isTouchingWall;
    private bool isWallSliding;

    void Awake()
    {
    
    }

    protected void CheckWorld(){
     isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);
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

        if (move.x > 0.00f){
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else if (move.x < 0.00f){
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        

        targetVelocity = move * maxSpeed;

        animator.SetFloat("Speed", Mathf.Abs(move.x));

    }
}