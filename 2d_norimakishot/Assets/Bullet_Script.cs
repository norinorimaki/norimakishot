using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.2f, 0, 0);

        if (transform.position.x > 30)
        {
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
}
