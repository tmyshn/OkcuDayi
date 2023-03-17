using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    bool hashit=false;

    void Start()
    {
        rigidbody2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hashit)
        {
            float angle = Mathf.Atan2(rigidbody2d.velocity.y, rigidbody2d.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hashit= true;
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.isKinematic = true;
        
    }
}
