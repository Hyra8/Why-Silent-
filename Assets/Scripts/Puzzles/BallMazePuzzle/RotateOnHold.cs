using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Xoay vật thể
/// </summary>
public class RotateOnHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float rotationSpeed = 100f; // tốc độ xoay của đồ vật
    private bool isRotating = false;
    public bool clockwise = true;
    [SerializeField] Transform maze;

    void FixedUpdate()
    {
        if (isRotating)
        {
            if (!clockwise)
            {
                maze.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            else
            {
                maze.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotating = false;
    }
}
