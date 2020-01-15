using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            float _randomX = Random.Range(-19.5f, 19.5f);
            float _randomwait = Random.Range(1.0f, 5.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(_randomX, 14.3f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_randomwait);
            Debug.Log("New Foe Incoming");
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
