using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreenBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScore(float score)
    {
        // Update the score text
        _scoreText.text = score.ToString();
    }
}
