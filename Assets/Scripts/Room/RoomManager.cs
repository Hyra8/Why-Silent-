using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Room[] rooms;
    public static RoomManager instance;


    private void Awake()
    {
        instance = this;
    }

    public void PlayRoomAmbientV1(string roomName)
    {
        switch (roomName)
        {
            case "Livingroom":
                AudioManager.instance.PlayMusic("Horror Ambient 1");
                break;

            case "Bedroom 1":
                AudioManager.instance.PlayMusic("Horror Ambient 2");
                break;

            default:

                break;
        }
    }

    public void PlayRoomAmbientV2()
    {
        Room currentRoom = GetCurrentRoom();
        if (currentRoom == null)
        {
            return;
        } else {
            switch (currentRoom.gameObject.name)
            {
                case "Livingroom":
                    AudioManager.instance.PlayMusic("Horror Ambient 1");
                    break;


                case "Bedroom 1":
                    AudioManager.instance.PlayMusic("Horror Ambient 2");
                    break ;

                default:

                    break;
            }
        } 
    }

    public void StopRoomAmbient(string roomName)
    {
        switch (roomName)
        {
            case "Livingroom":
                AudioManager.instance.StopMusic("Horror Ambient 1");
                break;


            case "Bedroom 1":
                AudioManager.instance.StopMusic("Horror Ambient 2");
                break;

            default:

                break;
        }
    }

    public Room GetCurrentRoom()
    {
        return Array.Find(rooms, (room) => room.isActiveAndEnabled == true);
    }

}
