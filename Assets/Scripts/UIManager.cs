using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] Text ScoreText;
    [SerializeField] Text GameOver;
    [SerializeField] Text InfoText;
    [SerializeField] Sprite [] _LivesSprite;
    [SerializeField] Image _currentLives;

    GameManager _gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

        ScoreText.text = "Score :";
        GameOver.enabled = false;
        InfoText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreTextUpdate(int TextScore)
    {
        ScoreText.text = "Score : " + TextScore.ToString();

        if (TextScore <= 600)
        {
            _gamemanager.SecondLevelActivate();
        }
    }

    public void UpdateLives(int CurrentLives)
    {
        _currentLives.sprite = _LivesSprite[CurrentLives];

        if (CurrentLives == 0)
        {
            GameOver.enabled = true;
            InfoText.enabled = true;
        }
        else if(CurrentLives >= 1)
        {
            GameOver.enabled = false;
            InfoText.enabled = false;
        }
    }

    
}
