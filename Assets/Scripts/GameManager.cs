using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    void Start()
    {

    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        updateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate = spawnRate / difficulty;
    }

    public void updateScore(int scoreToadd)
    {
        score += scoreToadd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //Step 4 updateScore(5);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        
    }
}
