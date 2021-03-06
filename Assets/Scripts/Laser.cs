﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _lazeroffsetdistance = 3.0f;
    [SerializeField]
    private float _speed;
    private float _playerPositionY;

    // Start is called before the first frame update
    void Start()
    {
        _playerPositionY = GameObject.Find("Player").transform.position.y;

        _speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
         Movementcontroller();
    }
    void Movementcontroller()
    {
        float lazerboost = _playerPositionY + _lazeroffsetdistance;
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        
        if (transform.position.y > 15.0f)
        {
       
           if(transform.parent != null)
           {
                Destroy(transform.parent.gameObject);        
           }
           else
           {
                Destroy(this.gameObject);
           }
            
        }
        else if (transform.position.y >= lazerboost && _speed != 12.0f)
        {
            _speed = 12.0f;
        }

        
        

    }
}

