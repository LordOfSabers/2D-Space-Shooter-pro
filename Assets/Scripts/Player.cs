using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _speed = 8.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _laserOffset = 1.2f;
    [SerializeField]
    private float _reloadTime = 1.5f;
    [SerializeField]
    private int _ammoCount = 4;
    private SpawnManager _spawnManager;
    private float _canfire = -1f;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isShieldsActive = false;
    


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
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

    private IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(7.5f);
        _isTripleShotActive = false;
         
    }

    void FireLaser()
    {
      
        

        if(_isTripleShotActive == true)
        {
            _ammoCount--;
            Instantiate(_tripleShotPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);
        }        
        else if(_isTripleShotActive == false)
        {
            _ammoCount--;
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);
        }

        

        if (_ammoCount <= 0)
        {
            _ammoCount = 4;
            _canfire = Time.time + _reloadTime;
        }



    }

    public void TripleSotActive()
    {
        _isTripleShotActive = true;

        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedPowerActive()
    {
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        _speed *= 2;
        yield return new WaitForSeconds(6.0f);
        _speed /= 2;
    }

    public void ActivateShields()
    {
        _isShieldsActive = true;
    }

    public void Damage()
    {
        //if shields are active
        //do nothing...
        //deactivate shields
        //return;
        if(_isShieldsActive == true)
        {
            _isShieldsActive = false;
            return;
        }

        
        _lives--;
        if(_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
           
        }  
    }
}
