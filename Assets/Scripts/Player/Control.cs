using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    public SpriteControl spritecontrol;
    public bool isDraging;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDraging)
        {
            spritecontrol.SetVelocity(Input.GetAxis("Horizontal"));

            if (Input.GetButtonDown("Jump")) spritecontrol.SetJump();
        }
    }
}

