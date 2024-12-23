using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Biến chứa những vật thể mang qua cửa
    private HashSet<GameObject> doorObjects = new HashSet<GameObject>();

    [SerializeField] private Transform destination;

    [SerializeField] private Room currentRoom;

    [SerializeField] private Room destinationRoom;

    private void Awake()
    {

    }

    /// <summary>
    /// Kiểm tra xem Người chơi chạm vào Object chưa
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    private bool CheckPlayer(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return true;
        }
        else

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (CheckPlayer(collision))
        {
            return;
        }

        // Kiểm tra xem có gameObject nào đang ở trong Collider 
        if (doorObjects.Contains(collision.gameObject))
        {
            return;
        }

        // Lấy component từ gameObject
        if (destination.TryGetComponent(out Door destinationDoor))
        {
            // Thêm Player vào Door đích
            destinationDoor.doorObjects.Add(collision.gameObject);
        }

        collision.transform.position = destination.transform.position;
        currentRoom.UnactiveRoom();
        destinationRoom.ActiveRoom();  
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (CheckPlayer(collision))
        {
            return;
        }
        doorObjects.Remove(collision.gameObject);
    }
}
