using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _GameOver = false;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _GameOver == true)
        {

            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    public void StopAction()
    {
        _GameOver = true;
        Time.timeScale = 0;
    }

    public void SecondLevelActivate()
    {
        
     
    }


}
