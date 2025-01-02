using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float _timeRemaining;
    private bool _timerRunning;
    [SerializeField] private UnityEvent onTimerEnded;
    
    public void StartTimer(float duration)
    {
        _timeRemaining = duration;
        _timerRunning = true;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        Debug.Log($"_timeRemaining: {_timeRemaining}");
        while (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            DisplayTime(_timeRemaining);
            yield return null; 
        }
        
        _timeRemaining = 0;
        _timerRunning = false;
        Debug.Log("onTimerEnded");
        onTimerEnded?.Invoke();
    }
    
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay); // Ensure no negative time
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }    
}
