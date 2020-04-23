using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private bool _stopSpawning = true;
   

    // Start is called before the first frame update
    void Start()
    {
        _stopSpawning = true;
        
    }
    
    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false)
        {
            float _randomX = Random.Range(-19.5f, 19.5f);
            float _randomwait = Random.Range(0.5f, 3.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(_randomX, 14.3f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_randomwait);
           
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while(_stopSpawning == false)
        {
            int _randomPowerup = Random.Range(0, 3);
            float _randomX = Random.Range(-19.5f, 19.5f);
            float _randomspawn = Random.Range(7.5f, 15.0f);
            GameObject newpowerup = Instantiate(_powerups[_randomPowerup], new Vector3(_randomX, 14.3f, 0), Quaternion.identity);
            yield return new WaitForSeconds(_randomspawn);
        }
    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
    
    public void StartWave()
    {
        _stopSpawning = false;
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

}

