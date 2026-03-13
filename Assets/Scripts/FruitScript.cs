using UnityEngine;
public class FruitScript : MonoBehaviour {
    [SerializeField] private string fruitType;
    [SerializeField] private int pointValue = 10;
    [SerializeField] private ParticleSystem collectParticles;
    private bool isCollected = false;

    void Start() {
        gameObject.tag = "Fruit";
    }

    public void Collect() {
        if (!isCollected) {
            isCollected = true;
            if (collectParticles != null) {
                Instantiate(collectParticles, transform.position, Quaternion.identity);
            }
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null) {
                audioSource.Play();
            }
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) {
                gameManager.AddScore(pointValue);
            }
            Destroy(gameObject, 0.2f);
        }
    }

    public string GetFruitType() {
        return fruitType;
    }

    public int GetPointValue() {
        return pointValue;
    }
}