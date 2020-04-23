using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField]
    private SpawnManager _spawnManagerCSS;
    [SerializeField]
    private float _speed = 10.5f;
    private float _xSpeed;
    private float _ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (_spawnManagerCSS == null)
        {
            Debug.LogError("Error ASS::SPAWN/CSS IS NULL");
        }

        transform.position = new Vector3(-20, 10, 0);
        _xSpeed = Random.Range(.5f, 10.6f);
        StartCoroutine(Moveright());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_xSpeed, _ySpeed, 0) * Time.deltaTime);

        transform.Rotate(0.0f, 0.0f, _speed * Time.deltaTime, Space.Self);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.1f, 10.5f), 0);

        //Creates screen wrap
        if (transform.position.x >= 20.8f)
        {
            transform.position = new Vector3(-20.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -20.8f)
        {
            transform.position = new Vector3(20.5f, transform.position.y, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            _spawnManagerCSS.StartWave();
            //spawn explosion
            //kill self

        }
        //if other is player
        {
            //damage player
            //slow down

        }

    }


    private IEnumerator Moveright()
    {
        yield return new WaitForSeconds(15.5f);
        _ySpeed = Random.Range(-5.0f, 5.0f);
        _xSpeed = Random.Range(-10.6f, -0.5f);
        StartCoroutine(MoveLeft());
    }

    private IEnumerator MoveLeft()
    {  
        yield return new WaitForSeconds(15.5f);
        _ySpeed = Random.Range(-5.0f, 5.0f);
        _xSpeed = Random.Range(10.6f, 0.5f);
        StartCoroutine(Moveright());
    }
}



