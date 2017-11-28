using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingScript : MonoBehaviour
{
    public GameObject gameObjectTodrag; // refer to GO that will be dragged

    public Vector2 GOcenter; //GO center
    public Vector2 touchPosition; //touch or click position
    public Vector2 offset; //vector between touch point to object center 
    public Vector2 newGOCenter; // new center of GO 

    RaycastHit hit; //store hit object information
    public GameObject ancora;

    public bool draggingMode = false;

	//public LayerMask mask = 12;

    Rigidbody2D other;
    public RigidbodyConstraints2D constraints;
    // Use this for initialization

    Control ctl;
    SpriteControl spritecontrol;
    void Start()
    {
        ctl = GameObject.Find("perso").GetComponent<Control>();
        spritecontrol = GameObject.Find("perso").GetComponent<SpriteControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !spritecontrol.jump)
        {
            //CONVERT MOUSE CLICK POSITION TO A RAY 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ancora.transform.position = (ray.direction + ray.origin) * 10;
            //if ray hit a collider (NOT 2D) 
			if (Physics.Raycast(ray, out hit))
            {
                gameObjectTodrag = hit.collider.gameObject;
                GOcenter = gameObjectTodrag.transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - GOcenter;
                draggingMode = true;

            }

            //if ray hit a collider (NOT 3D) 
            RaycastHit2D hit2d =
            Physics2D.Raycast(ray.origin, ray.direction);

            if (hit2d)
            {
				spritecontrol.attackindex = 0;
                gameObjectTodrag = hit2d.collider.gameObject;
                GOcenter = gameObjectTodrag.transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - GOcenter;
                draggingMode = true;


                if (hit2d)
                {
                    if (hit2d.collider.gameObject.GetComponent<Rigidbody2D>())
                    {
                        other = hit2d.collider.gameObject.GetComponent<Rigidbody2D>();


                    }

                }


            }

        }

        //every frame when user hold on left button
        if (Input.GetMouseButton(0))
        {
            if (draggingMode)
            {


				spritecontrol.AttackAnim ();
				spritecontrol.estadoAnim = ESTADOANIM.ATTACK;

                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                // gameObjectTodrag.transform.position = new Vector3(newGOCenter.x, newGOCenter.y);
                ancora.transform.position = new Vector3(newGOCenter.x, newGOCenter.y);
                if (other)
                {
                    Vector3 dir = other.transform.position - ancora.transform.position;

                    other.AddForce(dir * -100);
                    other.drag = 10;
                }
                spritecontrol.SetVelocity(0);
                ctl.isDraging = true;
            }

        }
        //when mouse is released
        if (Input.GetMouseButtonUp(0))
        {
			spritecontrol.estadoAnim = ESTADOANIM.IDLE;
            other.drag = 0;
            other = null;
            draggingMode = false;
            ctl.isDraging = false;
        }


    }
}
