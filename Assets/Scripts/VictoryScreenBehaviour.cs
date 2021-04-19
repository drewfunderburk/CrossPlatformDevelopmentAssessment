using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreenBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScore(float score)
    {
        _scoreText.text = score.ToString();
    }
}
