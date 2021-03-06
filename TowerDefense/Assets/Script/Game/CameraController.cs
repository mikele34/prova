using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    [Header("Clamp telecamera")]
    public float MinY_x = 10f;
    public float MaxY_x = 80f;
    public float MinY_y = 10f;
    public float MaxY_y = 80f;
    public float MinY_z = 10f;
    public float MaxY_z = 15f;
    

    
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if(Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        
        if(Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, MinY_y, MaxY_y);

        pos.x = Mathf.Clamp(pos.x, MinY_x, MaxY_x);

        pos.z = Mathf.Clamp(pos.z, MinY_z, MaxY_z);

        transform.position = pos;

    }
}
