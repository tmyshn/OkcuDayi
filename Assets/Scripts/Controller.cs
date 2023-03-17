using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 firstPosition;
    private Vector2 lastPosition;
    private Vector2 lefthanddirection;

    public Transform bowarm;
    public Transform arrowarm;
    public Transform bowtransform;
    public Transform arrow;

    private Bow bow;
    [SerializeField]
    private float powerDistance = 0;
    void Start()
    {
        bow=GetComponent<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
      
        

        if (Input.GetMouseButtonDown(0))
        {
            firstPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
   
        if (Input.GetMouseButton(0))
        {
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
         

            bow.DebugAngle(lastPosition - firstPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            powerDistance = (lastPosition - firstPosition).magnitude * 4;
            Debug.Log(powerDistance.ToString());

            bow.Shoot(powerDistance,lastPosition-firstPosition);
        }
   
    }

    private void LateUpdate()
    {

        bowarm.up = lastPosition - firstPosition;
        lefthanddirection = bowtransform.position-arrowarm.position;
        arrowarm.up = -lefthanddirection;
        arrow.localEulerAngles = new Vector3(0, 0, 180);

       // arrowarm.up = lastPosition - firstPositionasda;
    }
}
