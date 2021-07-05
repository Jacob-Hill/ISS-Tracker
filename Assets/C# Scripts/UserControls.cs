using UnityEngine;

public class UserControls : MonoBehaviour
{
    GameObject Earth;
    public float ScrollSensitivity = 1;
    public float TurnSpeed = 1;
    private Vector2 PrevMousePos;
    private Vector2 MousePos;
    private bool mouseDown = false;
    private float radius = 50;
    private float maxAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.FindGameObjectWithTag("earth");
    }

    // Update is called once per frame
    void Update()
    {
        MouseDown();
        Rotate();
        ZoomCamera();
        //LimitRotation();
    }

    void ZoomCamera()
    {
        Vector3 displacement = Earth.transform.position - transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 velocity = direction * Input.GetAxisRaw("Mouse ScrollWheel") * ScrollSensitivity * 25;
        transform.Translate(velocity, Space.World);
        displacement = Earth.transform.position - transform.position;
        radius = Mathf.Sqrt(Mathf.Pow(displacement.x, 2) + Mathf.Pow(displacement.y, 2) + Mathf.Pow(displacement.z, 2));
    }

    void Rotate()
    {
        if (mouseDown)
        {
            transform.LookAt(Earth.transform.position);
            PrevMousePos = MousePos;
            MousePos = Input.mousePosition;
            Vector2 mouseDrag = MousePos - PrevMousePos;
            Vector2 direction = mouseDrag.normalized;
            Vector2 velocity2 = direction * TurnSpeed * -1 * Time.deltaTime * radius;
            transform.Translate(new Vector3(velocity2.x, velocity2.y));
        }
    }

    void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
    }

    void LimitRotation()
    {
        Vector3 initialVector = Vector3.forward;
        Vector3 currentVector = transform.position - Earth.transform.position;
        currentVector.x = 0;
        float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).x > 0 ? 1 : -1);
        float newAngle = Mathf.Clamp(angleBetween, -maxAngle, maxAngle);
        float rotateDegrees = newAngle - angleBetween;
        transform.RotateAround(Earth.transform.position, Vector3.up, rotateDegrees);
    }
}
