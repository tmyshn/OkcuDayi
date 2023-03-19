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

    public Animator animator;

    private Bow bow;
    [SerializeField]
    private float powerDistance = 0;


    public Charstates charstates;


    void Start()
    {
        bow=GetComponent<Bow>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        

        if (Input.GetMouseButtonDown(0))
        {
           if(charstates==Charstates.IsIdle)
            {
                StartCoroutine(ToReady());
            }
            
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

           
            if(charstates==Charstates.IsReady)
            {
                StartCoroutine(ToIdle());
            }
   

        }
   
    }

    private void LateUpdate()
    {


        if (charstates==Charstates.IsReady)
        {
            // bowarm.up = lastPosition - firstPosition;
            bowarm.up = Vector3.Lerp(bowarm.up,lastPosition-firstPosition,20*Time.deltaTime);
            lefthanddirection = bowtransform.position - arrowarm.position;
            arrowarm.up = -lefthanddirection;
            arrowarm.localEulerAngles = new Vector3(0, 0, arrowarm.localEulerAngles.z + 30);
            arrow.localEulerAngles = new Vector3(0, 0, 150);
            
        }

        // arrowarm.up = lastPosition - firstPositionasda;
    }


    private IEnumerator ToReady()
    {
        animator.SetTrigger("ToAttackStart");
        firstPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        charstates = Charstates.IsPrepare;
        yield return new WaitForSeconds(0.50f);
        charstates= Charstates.IsReady;
        animator.enabled = false;

    }

    private IEnumerator ToIdle()
    {
      
        bow.Shoot(powerDistance, lastPosition - firstPosition);
        animator.enabled = true;
        charstates = Charstates.IsEnd;
        animator.SetTrigger("ToAttackEnd");
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("ToAttackIdle");
        charstates= Charstates.IsIdle;


    }







}

public enum Charstates
{
    IsIdle,
    IsPrepare,
    IsReady,
    IsEnd,

}
