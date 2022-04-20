using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float _speed;

    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -_speed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision != null)
            {
                _player.ShieldsUp();

                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
