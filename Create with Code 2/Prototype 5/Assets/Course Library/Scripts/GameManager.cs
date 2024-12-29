using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score;
    [SerializeField] private float spawnRate = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        SetScore(0);
    }

    void Update()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
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
}