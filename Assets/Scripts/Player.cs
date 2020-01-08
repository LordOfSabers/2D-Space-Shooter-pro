using System.Collections;
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
        //get left and right key press
        float _Horizontal = Input.GetAxis("Horizontal");
        //get up and down key press
        float _Vertical = Input.GetAxis("Vertical");
        //move player at _speed * time.deltatime
        transform.Translate(new Vector3(_Horizontal, _Vertical, 0) * _speed * Time.deltaTime);




    }
}
