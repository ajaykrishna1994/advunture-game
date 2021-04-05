using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
   
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWin;

    public GameObject titleScreen;
    public Button restartButton;
    public Button startButton;
    public Button exitButton;
    
    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

  


    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f; //  x value of the center of the left-most square
    private float minValueY = -3.75f; //  y value of the center of the bottom-most square
    public float timeLeft = 60f;
    public GameObject bulletPrefab;

   // public thing thingScript;

    // Start is called before the first frame update
    void Start()
    {
       // thingScript = GameObject.Find("thing").GetComponent<thing>();
        isGameActive = false;
    }
    public void StartGame()
    {
        restartButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        isGameActive = true;
      //  StartCoroutine(thingScript.Bullet());
        score = 0;
        UpdateScore(0);
       
        //  titleScreen.SetActive(false);

    }

   
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
       // scoreText.text = "score" + score;



    }
    public void GameOver()
    {
        Debug.Log("game over");
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void GameWin()
    {
       
        Debug.Log("game win");
        gameWin.gameObject.SetActive(true);
     
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
      
      
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }

   

}
