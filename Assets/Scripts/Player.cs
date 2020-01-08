﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {       
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);




    }
}
