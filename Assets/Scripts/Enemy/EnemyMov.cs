using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

    public float moveSpeed;

    //bool audioonce = false;
    //bool breakaudioonce = false;


	// Use this for initialization
	void Start () {
        
       // aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
		
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Parede")
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }


        if (col.gameObject.name.Contains("Pedra"))
        {


            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }


    }
}
