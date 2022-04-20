using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy2 : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] GameObject _explosion;

    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, - _speed * Time.deltaTime, 0));

        if (transform.position.y <= -5.50f)
        {
            float RandomX = Random.Range(-8.5f, 8.5f);
            transform.position = new Vector3(RandomX, 6.30f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            if(other != null)
            {
                _player.ScorePlayer(15);
                Destroy(other.gameObject);
                Instantiate(_explosion, transform.position, Quaternion.identity);

                Destroy(this.gameObject, .2f);

            }
        }

        if (other.tag == "Player")
        {
            if(other != null)
            {
                _player.TakeDamagePlayer();

                Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject, 0.2f);
            }
        }
    }
}
