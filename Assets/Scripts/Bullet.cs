using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private int damage = 20;
    [SerializeField] private GameObject bulletFX;
    [SerializeField] private LayerMask targetLayerMask;

    private void Start() {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if ((1 << col.gameObject.layer & targetLayerMask) != 0) {
            col.GetComponent<IDamageable>()?.TakeDamage(damage);
            // spawn bulletFX
            Destroy(gameObject);
        }
    }
}
