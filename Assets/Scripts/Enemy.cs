using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4;
    [SerializeField]
    private GameObject _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
      
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

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Laser")
        {
            var hit = _spawnManager.transform.GetComponent<SpawnManager>();
            Destroy(other.gameObject);
            hit.Shot();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();
            var hit = _spawnManager.transform.GetComponent<SpawnManager>();
            hit.Shot();

            if (player != null)
            {
                player.Damage();       
            }


            Destroy(this.gameObject);
        }   
    }
}
