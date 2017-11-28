using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    [SerializeField]
    Vector3 posfinal;
    // Use this for initialization

    void Start()
    {
        posfinal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posatual = gameObject.transform.position;
        posatual = Vector3.Lerp(posatual, posfinal, 0.01f);
        gameObject.transform.position = posatual;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("<color=red>Fatal error:</color>");
            posfinal = gameObject.transform.position;
            posfinal.y += 2;
        }
    }
}
