using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private int _enemies = 0;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void Shot()
    {
        _enemies--;
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    //spawn game objects every 4 to 9 seconds
    //create coroutine of type IRnumerator -- Yield Events
    
    IEnumerator SpawnRoutine()
    {
        
        //while (_enemies < 15)
            //instantiate Enemy Prefab
            //Yield wait for 4 to 9 seconds
            //add 1 to _enemies
        while(_enemies < 50)
        {
            float _randomX = Random.Range(-19.5f, 19.5f);
            float _randomwait = Random.Range(1.0f, 5.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(_randomX, 14.3f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            _enemies++;
            yield return new WaitForSeconds(_randomwait);
            Debug.Log("New Foe Incoming");
        }

        StartCoroutine(SpawnRoutine());
    }


}
