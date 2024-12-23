using UnityEngine;


public class Room : MonoBehaviour
{
    /// <summary>
    /// Hiện phòng
    /// </summary>
    public void ActiveRoom()
    {
        gameObject.SetActive(true);
/*        RoomManager.instance.PlayRoomAmbientV1(gameObject.name);*/
    }

    /// <summary>
    /// Tắt phòng   
    /// </summary>
    public void UnactiveRoom()
    {
/*        RoomManager.instance.StopRoomAmbient(gameObject.name);*/
        gameObject.SetActive(false);
    }
}
