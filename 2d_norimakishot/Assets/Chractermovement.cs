using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chractermovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    public GameObject Norimaki_Prefab;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
     var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

    if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Norimaki_Prefab, transform.position, Quaternion.identity);
        }
    }
}
