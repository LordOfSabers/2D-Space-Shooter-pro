using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //For player Function
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _speed = 8.0f;
    private int _score = 0;
    private SpawnManager _spawnManager;
    [SerializeField]
    private UIManager _canvas;

    //For weapon logic
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _laserOffset = 1.2f;
    [SerializeField]
    private float _reloadTime = 1.5f;
    [SerializeField]
    private int _ammoCount = 4;
    private float _canfire = -1f;
    private float _canfireaxis = -1f;


    //For Triple Shot powerup 
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    //For Shields powerup
    private bool _isShieldsActive = false;
    [SerializeField]
    private GameObject _Shield;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);//set player starting postion

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//obtain the spawn manager

        //null check
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Calculatemovment();

        /*
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            FireLaser();
        }
        */
        if(Input.GetAxis("Fire1") > 0.9f && Time.time > _canfireaxis && Time.time > _canfire)
        {
            FireLaser();
            _canfireaxis = Time.time + 0.15f;
        }

    }

    //For movement Calculation
    void Calculatemovment()
    {
        //Clamps Vertical movement
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -9.1f, 1.5f), 0);

        //Creates screen wrap
        if (transform.position.x >= 20.8f)
        {
            transform.position = new Vector3(-20.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -20.8f)
        {
            transform.position = new Vector3(20.5f, transform.position.y, 0);
        }

        //Captures input and process it into movement
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

    }

    //Triple Shot time limit Coroutine
    private IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(7.5f);
        _isTripleShotActive = false;
         
    }

    //fire weapon Logic
    void FireLaser()
    {
      
        
        //check to see if power up is active
        if(_isTripleShotActive == true)
        {
            _ammoCount--; //Lower ammo amount by 1
            //Create 3 lasers
            Instantiate(_tripleShotPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);
        }        
        else if(_isTripleShotActive == false)
        {
            _ammoCount--; //Lower ammo amount by 1
            //Create 1 laser
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + _laserOffset, 0), Quaternion.identity);
        }

        //Ckeck if out of ammo
        if (_ammoCount <= 0)
        {
            _ammoCount = 4; //refill ammo
            _canfire = Time.time + _reloadTime; //set reload time so player can not fire until reloaded
        }



    }

    //Tripleshot powerup turn on logic
    public void TripleShotActive()
    {
        _isTripleShotActive = true;// turn on the tripleshot

        StartCoroutine(TripleShotPowerDownRoutine());//start tripleshot power down start
    }

    //Speed powerup turn on logic
    public void SpeedPowerActive()
    {
        StartCoroutine(SpeedPowerDownRoutine());//this coroutine does everything
    }

    //speed powerup logic
    IEnumerator SpeedPowerDownRoutine()
    {
        _speed *= 2;//doubles speed
        yield return new WaitForSeconds(8.0f);//duration of powerup
        _speed /= 2;//halves speed
    }

    //Shield powerup start logic
    public void ActivateShields()
    {
        _Shield.SetActive(true);//turns on shield animation
        _isShieldsActive = true;//prevents 1 Damage(); from running all the way
    }

    public void Scorecontroller(int Value)
    {
        _score += Value;
        _canvas.UpdateScore(_score);
    }

    //lives and shield logic
    public void Damage()
    {
        //checks if shield powerup is collected
        if(_isShieldsActive == true) 
        {
            _isShieldsActive = false;//turns off shield powerup
            _Shield.SetActive(false);//turns off shield animation
            return;
        }

        _lives--;//this variable tracks how may "lives" the player has.
        _canvas.UpdateLivesUI(_lives);

        //this destroys the player and stops object spawning if the player runs out of lives
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
           
        }  
    }
}
