using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text moveCounterText;
    private int score;
    private int moveCounter;

    void Start()
    {
        score = 0;
        moveCounter = 10; // Example initial move count
        UpdateScoreText();
        UpdateMoveCounterText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseMoveCounter()
    {
        moveCounter--;
        UpdateMoveCounterText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateMoveCounterText()
    {
        moveCounterText.text = "Moves Left: " + moveCounter.ToString();
    }
}