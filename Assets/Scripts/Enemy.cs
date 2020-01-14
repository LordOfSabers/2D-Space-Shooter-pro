﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= -11.75f)
        {
            transform.position = new Vector3(Random.Range(-19.5f, 19.5f), Random.Range(12.75f, 19.0f), 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is laser
        //destroy laser
        //destroy this.gameobject
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            //other.gameObject.GetComponent();
            //lives--


            Debug.Log("got'cha");
            //destroy this.gameobject
            Destroy(this.gameObject);
        }

       
    }
}
