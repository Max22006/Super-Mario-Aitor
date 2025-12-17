using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform cameraTarget;

    public Vector3 cameraOffset;
    
    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cameraTarget = GameObject.Find("Mario_0").GetComponent<Transform>();
        //cameraTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cameraTarget.position + cameraOffset;
        //transform.position = new Vector3(cameraTarget.position.x, 0, 0) + cameraOffset;
       
        Vector3 desiredPosition = cameraTarget.position + cameraOffset;

        float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, maxCameraPosition.x);
        float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, maxCameraPosition.y);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        transform.position = clampedPosition;
    }
}
