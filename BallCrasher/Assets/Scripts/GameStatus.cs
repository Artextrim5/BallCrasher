using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parametrs

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestryed;
    [SerializeField] TextMeshProUGUI scoreText;

    // State veriables

    [SerializeField] int carentScore = 0;

    private void Start()
    {
        pointsPerBlockDestryed = 50;
        scoreText.text = carentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        carentScore = carentScore + pointsPerBlockDestryed;
        scoreText.text = carentScore.ToString();
    }

}
