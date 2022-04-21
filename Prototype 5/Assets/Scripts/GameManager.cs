/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Variables

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive;

    private int score;

    private float spawnRate = 1.0f;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    #endregion

    #region Class

    IEnumerator SpawnTarget()
	{
		while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.RandomRange(0, targets.Count);

            Instantiate(targets[index]);


        }
	}

    public void UpdateScore(int scorePoint)
	{
        score += scorePoint;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
	{
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    #endregion
}
