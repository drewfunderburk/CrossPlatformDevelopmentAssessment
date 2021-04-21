using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextSceneBehaviour : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GoToNextScene();
    }
    private void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
