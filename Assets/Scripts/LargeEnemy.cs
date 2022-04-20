using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] float _speed;
    [SerializeField] int _maxHealth;
    [SerializeField] LayerMask _mask;
    [SerializeField] Transform _player;
    [SerializeField] GameObject _smallExplosion;
    [SerializeField] GameObject _BigExplosion;
    [SerializeField] GameObject _EnemyLaser;
    Player _PlayerScore;

    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _PlayerScore = GameObject.Find("Player").GetComponent<Player>();
        _currentHealth = _maxHealth;

        StartCoroutine(LaserFire());
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
       
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f,8.5f),  Mathf.Clamp(transform.position.y, 2, 4), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Laser")
            {
                EnemyDamage();
                Instantiate(_smallExplosion, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject, 0.1f);
            }
        }
    }

    void EnemyDamage()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
        {
            Instantiate(_BigExplosion, transform.position, Quaternion.identity);
            _PlayerScore.ScorePlayer(25);

            Destroy(this.gameObject, .2f);
        }
    }

    IEnumerator LaserFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(_EnemyLaser, transform.position, Quaternion.identity);
            
        }

    }








}
