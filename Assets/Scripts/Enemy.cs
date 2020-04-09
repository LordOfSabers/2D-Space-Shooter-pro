using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    private float _speed = 4;

    [SerializeField]
    private Player _playerScript;

    private Animator _enemyDeathAnim;

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
        
        
        if(_playerScript == null)
        {
            Debug.LogError("Error Enemy::Player is NULL");
        }
        

        _enemyDeathAnim = GetComponent<Animator>();
       
       
        if(_enemyDeathAnim == null)
        {
            Debug.LogError("Error Enemy::Animator IS Null");
        }
        

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Laser")
        {          
            Destroy(other.gameObject);
            _playerScript.Scorecontroller(100);

            _enemyDeathAnim.SetTrigger("OnEnemyDeath");

            Destroy(this.gameObject, 2.35f);
        }
        else if(other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();       
            }

            _enemyDeathAnim.SetTrigger("OnEnemyDeath");

            Destroy(this.gameObject,2.35f);
        }   
    }

    private IEnumerator Destroy()
    {
        while (true)
        {
            _enemyDeathAnim.SetTrigger("OnEnemyDeath");
            yield return new WaitForSeconds(3);
            
        }
    }
}
