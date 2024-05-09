using UnityEngine;

public class ScreenBound : MonoBehaviour {

    [Header("Screen Bound Object Settings")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float buffer;

    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float bottomBorder;

    private void Awake() {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Start() {
        leftBorder = mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        rightBorder = mainCamera.ScreenToWorldPoint(Vector3.right * Screen.width).x;
        topBorder = mainCamera.ScreenToWorldPoint(Vector3.up * Screen.height).y;
        bottomBorder = mainCamera.ScreenToWorldPoint(Vector3.zero).y;
    }

    private void Update() {
        if (transform.position.x < leftBorder - buffer)
            transform.position = new Vector3(rightBorder, transform.position.y);

        if (transform.position.x > rightBorder + buffer)
            transform.position = new Vector3(leftBorder, transform.position.y);

        if (transform.position.y < bottomBorder - buffer)
            transform.position = new Vector3(transform.position.x, topBorder);

        if (transform.position.y > topBorder + buffer)
            transform.position = new Vector3(transform.position.x, bottomBorder);
    }
}
