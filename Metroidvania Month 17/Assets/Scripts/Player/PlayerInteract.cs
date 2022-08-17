using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    private PlayerManager player;

    public void OnStart(PlayerManager p) {
        player = p;
    }

    public void OnUpdate() {}

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<IPassable>() != null) {
            player.transform.position = other.GetComponent<Door>().exitPoint.position;
            player.cam.currentLevel = other.GetComponent<Door>().targetLevel;
            player.cam.transform.position = other.GetComponent<Door>().targetLevel.transform.position;
            player.cam.Initialize();
        }
    }

}