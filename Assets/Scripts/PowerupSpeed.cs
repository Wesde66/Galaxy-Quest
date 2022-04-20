using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    Player _player;

    [SerializeField] float _speed;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, - _speed * Time.deltaTime, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision != null)
            {
                _player.TurboSpeed();

                Destroy(this.gameObject, 0.2f);
            }
        }
    }
}
