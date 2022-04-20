using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float _speed;
    [SerializeField] int _maxLives = 3;

    [SerializeField] GameObject _laser;
    [SerializeField] GameObject _thrusters;
    [SerializeField] GameObject _LeftHurt;
    [SerializeField] GameObject _RightHurt;
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _ShieldsUpSprite;
    [SerializeField] GameObject _TrippleShotPrefab;
    [SerializeField] float _turbo = 1;

    SpriteRenderer _playerSprite;
    Level1Spawner _level1Spawner;
    UIManager _UIManager;

    bool _shieldsup = false;
    bool _TrippleShotActive = false;
    int _currentLives;
    int _scorePlayer;

    private bool _cooldown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentLives = _maxLives;

        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_UIManager == null)
        {
            Debug.Log("UIManager is null, player script");
        }

        _level1Spawner = GameObject.Find("Spawner").GetComponent<Level1Spawner>();
        if (_level1Spawner == null)
        {
            Debug.Log("Level1Spawner is null on player script");
        }

        _playerSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && !_cooldown)
        {
            attack();
            _cooldown = true;
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal")* (_speed *_turbo) * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * (_speed* _turbo) * Time.deltaTime;
        float X = Mathf.Clamp(transform.position.x, -8.36f, 8.36f);
        float Y = Mathf.Clamp(transform.position.y, -4.36f, 0);

        transform.position = new Vector3(X, Y, 0);

        transform.Translate(new Vector3(horizontal, vertical, 0));

    }

    public void ScorePlayer(int _score)
    {
        _scorePlayer += _score;
        _UIManager.ScoreTextUpdate(_scorePlayer);
    }

    public void TakeDamagePlayer()
    {

        if(_shieldsup == false)
        {

            _currentLives--;
            _UIManager.UpdateLives(_currentLives);

            if (_currentLives == 2)
            {

                _LeftHurt.gameObject.SetActive(true);
            }
            else if (_currentLives == 1)
            {
                _RightHurt.gameObject.SetActive(true);
            }
            else if (_currentLives <= 0)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);

                _playerSprite.enabled = false;
                _LeftHurt.SetActive(false);
                _RightHurt.SetActive(false);
                _thrusters.SetActive(false);
                

                StartCoroutine(GameOverwait());
            }

        }
        else
        {
            if (_shieldsup == true)
            {
                _shieldsup = false;
                _ShieldsUpSprite.SetActive(false);
            }
        }


    }

    public void TurboSpeed()
    {
        StartCoroutine(TurboOnOff());
    }

    IEnumerator TurboOnOff()
    {
        _turbo = 2;
        yield return new WaitForSeconds(5f);
        _turbo = 1;
    }

    void attack()
    {
        if(_TrippleShotActive == false)
        {
            Instantiate(_laser, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
            StartCoroutine(Cooldown());
        }
        else if( _TrippleShotActive == true)
        {
            Instantiate(_TrippleShotPrefab, transform.position + new Vector3(-1.3f, 0.5f, 0), Quaternion.identity);
            StartCoroutine(Cooldown());
        }

    }

    IEnumerator TrippleShotCountDown()
    {
        _TrippleShotActive = true;
        yield return new WaitForSeconds(5f);
        _TrippleShotActive = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.2f);
        _cooldown = false;
    }

    IEnumerator GameOverwait()
    {
        yield return new WaitForSeconds(1.5f);
        _level1Spawner.Level1Over();
    }

    public void TrippleLaserShot()
    {
        StartCoroutine(TrippleShotCountDown());
    }

    public void ShieldsUp()
    {
        _shieldsup = true;
        _ShieldsUpSprite.SetActive(true);
    }

    
}
