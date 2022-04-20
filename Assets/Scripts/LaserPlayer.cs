using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayer : MonoBehaviour
{
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);

        Destroy(this.gameObject, 4f);
    }
}
