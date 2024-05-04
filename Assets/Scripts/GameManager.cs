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

    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        //Step 3 scoreText.text = "Score: " + score;
        updateScore(0);
        //Step 3 gameOver.gameObject.SetActive(true);
        isGameActive = true;
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
