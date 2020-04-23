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

    private PolygonCollider2D _collider2d;
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
            Debug.LogError("Error Enemy::Animator is NULL");
        }

        _collider2d = GetComponent<PolygonCollider2D>();

        if(_collider2d == null)
        {
            Debug.LogError("Error Enemy::PlygonCollider2D is NULL");
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
        
        if(other.CompareTag("Laser"))
        {
            _speed = 0;
            Destroy(other.gameObject);
            _playerScript.Scorecontroller(100);

            _enemyDeathAnim.SetTrigger("OnEnemyDeath");
            _collider2d.enabled = false;

            Destroy(this.gameObject, 2.35f);
        }
        else if(other.CompareTag("Player"))
        {
            
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();       
            }

            _speed = 0;
            _enemyDeathAnim.SetTrigger("OnEnemyDeath");
            _collider2d.enabled = false;

            Destroy(this.gameObject, 2.35f);
        }   
    }
}
