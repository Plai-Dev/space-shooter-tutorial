using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("References")]
    [SerializeField]
    private Rigidbody2D rb;
    
    [SerializeField]
    private Camera cam;

    [Header("Settings")]
    [SerializeField]
    private float moveForce;

    private Vector2 input;
    private float rotation;

    private void Update() {
        input = Vector2.up * Input.GetAxisRaw("Vertical") + Vector2.right * Input.GetAxisRaw("Horizontal");
        rotation = GetRotation();
    }

    private void FixedUpdate() {
        rb.AddForce(input.normalized * moveForce);
        rb.MoveRotation(rotation);
    }

    private float GetRotation() {
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mouseWorldPosition - transform.position;
        return Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
    }
}
