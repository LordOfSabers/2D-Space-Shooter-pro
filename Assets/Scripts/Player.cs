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
        Calculatemovment();
    }

    void Calculatemovment()
    {

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.4f, 1.5f), 0);

        if (transform.position.x >= 12f)
        {
            transform.position = new Vector3(-11.9f, transform.position.y, 0);
        }
        else if (transform.position.x <= -12f)
        {
            transform.position = new Vector3(11.9f, transform.position.y, 0);
        }

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

    }
}
