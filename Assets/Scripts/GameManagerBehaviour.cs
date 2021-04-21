using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public static GameManagerBehaviour Instance;
    public static List<LineRenderer> Lines = new List<LineRenderer>();
    [SerializeField] private VictoryScreenBehaviour _victoryScreen;
    [SerializeField] private float _baseScore = 1000;

    private bool _isGameOver = false;

    public bool IsGameOver 
    { 
        get { return _isGameOver; }
        set
        {
            _isGameOver = value;
            if (_isGameOver)
                DoGameOver();
        }
    }

    private void Start()
    {
        // Singleton

        // If there is no Instance, make this the new Instance
        if (!Instance)
            Instance = this;
        // If there is an Instance and it is not this object, delete this object
        else if (Instance != this)
            Destroy(this.gameObject);
    }

    public void DoGameOver()
    {
        // Stop time to prevent movements
        Time.timeScale = 0.001f;

        // Turn on Victory Screen
        _victoryScreen.gameObject.SetActive(true);
    }

    public int CalculateScore()
    {
        float totalDistance = 0;

        // Loop through each line renderer
        foreach (LineRenderer line in Lines)
        {
            // Loop through each point in the renderer
            for (int i = 1; i < line.positionCount; i++)
            {
                // Get the distance between the current and previous points
                float distance = Vector2.Distance(line.GetPosition(i), line.GetPosition(i - 1));

                // Add it to totalDistance
                totalDistance += distance;
            }
        }

        // Score should decrease with longer lines, so we will subtract totalDistance from baseScore to come up with our final score
        return (int)(_baseScore - totalDistance);
    }

    public void RestartScene(float delay = 0)
    {
        StartCoroutine(RestartSceneCoroutine(delay));
    }

    private IEnumerator RestartSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
