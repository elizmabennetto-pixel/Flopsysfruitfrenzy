using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private string gameState;

    // Method to add score
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    // Method to end the game
    public void EndGame()
    {
        gameState = "GameOver";
        Debug.Log("Game Over");
        // Additional logic for ending the game can be added here
    }

    // Method to get the current game state
    public string GetGameState()
    {
        return gameState;
    }
}