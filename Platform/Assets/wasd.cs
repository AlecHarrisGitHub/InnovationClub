﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{   

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            transform.position = transform.position + new Vector3(-1f,0f,0f);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position = transform.position + new Vector3(1f,0f,0f);
        }
        if (Input.GetKeyDown("w"))
        {
            transform.position = transform.position + new Vector3(0f,1f,0f);
        }
        if (Input.GetKeyDown("s"))
        {
            transform.position = transform.position + new Vector3(0f,-1f,0f);
        }
    }
}