using UnityEngine;
using System.Collections.Generic;

public class FlopsyController : MonoBehaviour {
    public float movementSpeed = 5f;
    public float collectionRadius = 1.5f;
    public GameObject collectionAnimation;
    private List<GameObject> fruitInRange = new List<GameObject>();

    void Update() {
        Move();
        CollectFruit();
    }

    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void CollectFruit() {
        if (Input.GetKeyDown(KeyCode.E)) {
            foreach (var fruit in fruitInRange) {
                // Trigger collection animation
                Instantiate(collectionAnimation, fruit.transform.position, Quaternion.identity);
                Destroy(fruit);
            }
            fruitInRange.Clear();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Fruit")) {
            fruitInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Fruit")) {
            fruitInRange.Remove(other.gameObject);
        }
    }
}
