using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        //Step 3 scoreText.text = "Score: " + score;
        updateScore(0);
    }

    public void updateScore(int scoreToadd)
    {
        score += scoreToadd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //Step 4 updateScore(5);
        }
    }


    void Update()
    {
        
    }
}
