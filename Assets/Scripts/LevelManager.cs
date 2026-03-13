using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int maxLevel = 10;
    public float baseDifficulty = 1.0f;
    public float difficultyScaling = 0.1f;

    private Dictionary<int, float> levelDifficulty;

    void Start()
    {
        InitializeLevelDifficulty();
    }

    void InitializeLevelDifficulty()
    {
        levelDifficulty = new Dictionary<int, float>();
        for (int i = 1; i <= maxLevel; i++)
        {
            levelDifficulty[i] = CalculateDifficulty(i);
        }
    }

    float CalculateDifficulty(int level)
    {
        return baseDifficulty + (level - 1) * difficultyScaling;
    }

    public void AdvanceLevel()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            Debug.Log("Advanced to level " + currentLevel);
        }
        else
        {
            Debug.Log("Maximum level reached");
        }
    }

    public float GetCurrentDifficulty()
    {
        return levelDifficulty[currentLevel];
    }
}