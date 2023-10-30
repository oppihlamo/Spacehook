using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
public Camera mainCamera;
public LineRenderer _lineRenderer;
public DistanceJoint2D _distanceJoint;
public Rigidbody2D rb;
public float force;
private Vector3 MouseDir;
public Transform linePosition;
public bool isGrappling;


    void Start()
    {
        isGrappling = true;
        _distanceJoint.autoConfigureDistance =true;
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
       
    }


    void Update()
    {
      MouseDir = mainCamera.ScreenToWorldPoint(Input.mousePosition);
       
        if(isGrappling == true)
        {
            // creates a vector between player and mouse position
            if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           Vector2 mousepos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0,mousepos);
            _lineRenderer.SetPosition(1,transform.position);
            _distanceJoint.connectedAnchor = mousepos;
            _distanceJoint.enabled = true;
            linePosition.position = mousepos;     
        }
        // if mouse held, draws a line between mousepos and player
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _lineRenderer.SetPosition(1,transform.position);
            _lineRenderer.enabled = true;
        }
        // else removes the line and disables joints
        else if ( Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }

        if(_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1,transform.position);
        }
        // shortens lenght of rope when mouse held and W pressed
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
        {      
            Vector3 Direction = linePosition.position - transform.position;
            rb.velocity = new Vector2(Direction.x * force, Direction.y * force).normalized * force * Time.deltaTime;
            _distanceJoint.enabled = false;
        }
         
            if(Input.GetKeyUp(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
            {
            _distanceJoint.enabled = true;
            }
        }
        // increases lenght of rope when mouse held and S pressed
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
        {        
            Vector3 Direction = linePosition.position - transform.position;
            rb.velocity = new Vector2(Direction.x * force, Direction.y * force * -1).normalized * force * Time.deltaTime;
            _distanceJoint.enabled = false;
        }
         
           if(Input.GetKeyUp(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
           {
            _distanceJoint.enabled = true;
             
           }
        }
        }
