using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreenBehaviour : MonoBehaviour
{
    [Tooltip("Reference to the score text")]
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScore(float score)
    {
        // Update the score text
        _scoreText.text = "Score: " + ((int)(score)).ToString();
    }
}
