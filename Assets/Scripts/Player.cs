using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _laserOffset = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Calculatemovment();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);
        }

        //if space is pressed
        //Instantiate prefab

    }

    void Calculatemovment()
    {

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -9.1f, 1.5f), 0);

        if (transform.position.x >= 20.8f)
        {
            transform.position = new Vector3(-20.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -20.8f)
        {
            transform.position = new Vector3(20.5f, transform.position.y, 0);
        }

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

    }
}
