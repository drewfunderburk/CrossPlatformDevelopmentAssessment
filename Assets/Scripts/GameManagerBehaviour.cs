using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public static GameManagerBehaviour Instance;
    public static List<LineRenderer> Lines = new List<LineRenderer>();
    [SerializeField] private VictoryScreenBehaviour _victoryScreen;
    [SerializeField] private LineDrawBehaviour _lineDraw;
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

        // Ensure Victory Screen is disabled
        if (_victoryScreen.gameObject.activeInHierarchy)
            _victoryScreen.gameObject.SetActive(false);
    }

    public void DoGameOver()
    {
        // Turn on Victory Screen
        _victoryScreen.gameObject.SetActive(true);
        _victoryScreen.UpdateScore(CalculateScore());

        // Disable line drawing
        _lineDraw.enabled = false;
    }

    public float CalculateScore()
    {
        float totalDistance = 0;

        // Loop through each line renderer
        foreach (LineRenderer line in Lines)
        {
            // If the line is null, go to the next loop
            if (!line)
                continue;

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
        return Mathf.Max(0, _baseScore - (totalDistance * 10));
    }

    public void RestartScene(float delay = 0)
    {
        StartCoroutine(RestartSceneCoroutine(delay));
    }

    private IEnumerator RestartSceneCoroutine(float delay)
    {
        // Wait however long is specified
        yield return new WaitForSeconds(delay);

        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
