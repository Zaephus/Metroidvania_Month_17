using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private PlayerManager player;

    public float minX;
    public float maxX;

    public void OnStart() {
        player = FindObjectOfType<PlayerManager>();
    }

    public void OnUpdate() {

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,minX,maxX),player.transform.position.y,-10);

    }

    public void OnFixedUpdate() {}

}