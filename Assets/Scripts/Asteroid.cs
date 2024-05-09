using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable {
    [SerializeField] private int health = 100;

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            DestroyAsteroid();
        }
    }

    private void DestroyAsteroid() {
        // todo: add destruction GFX
        Destroy(gameObject);
    }
}
