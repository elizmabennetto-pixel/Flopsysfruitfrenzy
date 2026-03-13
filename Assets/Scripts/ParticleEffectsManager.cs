using UnityEngine;

public class ParticleEffectsManager : MonoBehaviour
{
    // Reference to the particle system for collecting fruits
    public ParticleSystem collectFruitEffect;

    // Reference to the particle system for matching tiles
    public ParticleSystem matchTileEffect;

    void Start()
    {
        // Initialize particle systems (if necessary)
        if (collectFruitEffect == null)
        {
            Debug.LogError("CollectFruitEffect is not assigned!");
        }
        if (matchTileEffect == null)
        {
            Debug.LogError("MatchTileEffect is not assigned!");
        }
    }

    // Method to play the collect fruit effect
    public void PlayCollectFruitEffect(Vector3 position)
    {
        Instantiate(collectFruitEffect, position, Quaternion.identity);
    }

    // Method to play the match tile effect
    public void PlayMatchTileEffect(Vector3 position)
    {
        Instantiate(matchTileEffect, position, Quaternion.identity);
    }
}