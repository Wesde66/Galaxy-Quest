using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawner : MonoBehaviour
{
    [SerializeField] GameObject _smallEnemyPrefab;
    [SerializeField] GameObject _smallEnemy2;
    [SerializeField] GameObject _EnemyMain;
    [SerializeField] GameObject[] _powerUps;

    GameManager _gameover;

    bool _Level1Active = true;
    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine(SmallEnemy());
        StartCoroutine(SmallEnemy2());
        StartCoroutine(PowerUps());
        StartCoroutine(EnemyMain());

        _gameover = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameover == null)
        {
            Debug.Log("GameManager in level1 spawner is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1Over()
    {
        _Level1Active = false;
        _gameover.StopAction();
    }

    IEnumerator EnemyMain()
    {
        yield return new WaitForSeconds(30);

        while (_Level1Active == true)
        {
            Instantiate(_EnemyMain, new Vector3(-2.62f, 6.45f, 0), Quaternion.identity);
            yield return new WaitForSeconds(30);
        }

    }

    IEnumerator SmallEnemy()
    {
        


        yield return new WaitForSeconds(1);
        
        while (_Level1Active == true)
        {
            float rSec = Random.Range(1,4);
            float _SpawnPointPos = Random.Range(-8.30f, 8.30f);
            Vector3 SpawnPoint = new Vector3(_SpawnPointPos, 5.70f, 0);
            Instantiate(_smallEnemyPrefab, SpawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(rSec);
        }

        
    }

    IEnumerator SmallEnemy2()
    {
        yield return new WaitForSeconds(10);

        while (_Level1Active == true)
        {
            float rSec = Random.Range(5, 10);
            float _SpawnPointPos = Random.Range(-8.30f, 8.30f);
            Vector3 SpawnPoint = new Vector3(_SpawnPointPos, 5.70f, 0);
            Instantiate(_smallEnemy2, SpawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(rSec);
        }
    }

    IEnumerator PowerUps()
    {
        yield return new WaitForSeconds(10);

        while (_Level1Active == true)
        {
            float rSec = Random.Range(10, 15);
            int RandomPowerUp = Random.Range(0, 3);
            float SpawnPointPos = Random.Range(-8.30f, 8.30f);
            Vector3 SpawnPoint = new Vector3(SpawnPointPos, 5.70f, 0);

            Instantiate(_powerUps[RandomPowerUp], SpawnPoint, Quaternion.identity);

            yield return new WaitForSeconds(rSec);
        }
    }
}
