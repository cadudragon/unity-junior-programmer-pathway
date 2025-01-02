using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DifficultyHandler : MonoBehaviour
{
    [SerializeField] private Difficulty difficulty;
    private GameManager _gameManager;
    private Button _button;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    void Update()
    {
    }

    private void SetDifficulty()
    {
        Debug.Log($"{_button.gameObject.name} was clicked.");
        _gameManager.StartGame(difficulty);
    }
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}