using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    

    void Update()
    {
        
    }

    public void DebugAngle(Vector2 direction)
    {
        shotPoint.right = direction;
        Debug.Log(direction);
        Debug.Log(direction);
    }

    public void Shoot(float launchForce,Vector2 direction)
    {
        shotPoint.right = direction;
        this.launchForce = launchForce;
        GameObject newArrow= Instantiate(arrow,shotPoint.position,shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = -shotPoint.right * launchForce;

    }
 

}
