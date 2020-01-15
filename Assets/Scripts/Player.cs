using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _laserOffset = 1.2f;
    [SerializeField]
    private float _reloadTime = 1.5f;
    [SerializeField]
    private int _ammoCount = 4;
    private float _canfire = -1f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Calculatemovment();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            FireLaser();
        }
 
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
    void FireLaser()
    {
        _ammoCount--;
        Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);

        if (_ammoCount <= 0)
        {
            _ammoCount = 4;
            _canfire = Time.time + _reloadTime;
        }

    }

    public void Damage()
    {
        _lives--;
        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }  
    }
}
