using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private float spawnRate = 1.0f;

    public bool gameOver;
    private int _score;

    private void Start()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void SetScore(int points)
    {
        _score += points;
        scoreText.text = $"Score: {_score}";
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame(Difficulty difficulty)
    {
        gameOver = false;
        _score = 0;
        spawnRate = difficulty switch
        {
            Difficulty.Medium => spawnRate / 2,
            Difficulty.Hard => spawnRate / 3,
            _ => spawnRate
        };

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        StartCoroutine(SpawnTarget());
    }

    public void RestartGame()
    {
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}