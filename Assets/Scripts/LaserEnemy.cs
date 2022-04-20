using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField] float _speed;
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

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Player")
            {
                _player.TakeDamagePlayer();
                Instantiate(_explosion, transform.position, Quaternion.identity);

                Destroy(this.gameObject, .2f);
            }
        }
                
    }
}
