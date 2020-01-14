using System.Collections;
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
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //if bottom of screen move to top with new random X position
        if(transform.position.y <= -11.75f)
        {
            transform.position = new Vector3(Random.Range(-19.5f, 19.5f), Random.Range(12.75f, 19.0f), 0);
        }
    }
}
