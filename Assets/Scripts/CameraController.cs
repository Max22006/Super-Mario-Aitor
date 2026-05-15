using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 startPosition; // ESTO NO HACE FALTA PARA EL Examen del 22

    private Transform cameraTarget; // public , pero hay que arrastrar el objetivo en el menu de unity
    public Vector3 cameraOffset;
    
    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cameraTarget = GameObject.Find("Mario_0").GetComponent<Transform>(); // esto no hace falta si pongo en public lo anterior
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cameraTarget.position + cameraOffset; //esto es la aversion facil, no se necesita los limites solo el cameraTarget y el cameraOffset.

       if (cameraTarget != null)
       {
           Vector3 desiredPosition = cameraTarget.position + cameraOffset;

        float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, maxCameraPosition.x);
        float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, maxCameraPosition.y);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        transform.position = clampedPosition;
       }
       
    }
}
