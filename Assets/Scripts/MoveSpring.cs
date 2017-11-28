using UnityEngine;
using System.Collections;

public class MoveSpring : MonoBehaviour
{

    public SpringJoint2D spring;


    void Awake()
    {

        spring = this.gameObject.GetComponent<SpringJoint2D>(); //"spring" is the SpringJoint2D component that I added to my object

        spring.connectedAnchor = gameObject.transform.position;//i want the anchor position to start at the object's position

    }


    void OnMouseDown()
    {

        spring.enabled = true;//reativa a SpringJoint2D cada vez que clica no obj e desabilita qd solta clique do mouse voaa na direcao q estava mexendo o mouse

    }


    void OnMouseDrag()
    {

        if (spring.enabled = true)
        {

            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//pega posicao do cursor

            spring.connectedAnchor = cursorPosition; //a ancora pega posicao do cursor


        }
    }


    void OnMouseUp()
    {

        spring.enabled = false;//desabilita a spring

    }

}
