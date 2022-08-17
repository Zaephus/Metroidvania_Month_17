using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private PlayerManager player;
    private Camera cam;

    public Level currentLevel;

    private float minX;
    private float maxX;

    private float camAdjustment;

    public void OnStart() {

        player = FindObjectOfType<PlayerManager>();
        cam = GetComponent<Camera>();

        Initialize();

    }

    public void Initialize() {

        minX = currentLevel.minX + currentLevel.transform.position.x;
        maxX = currentLevel.maxX + currentLevel.transform.position.x;

        camAdjustment = cam.orthographicSize*cam.aspect;

    }

    public void OnUpdate() {

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,minX+camAdjustment,maxX-camAdjustment),player.transform.position.y,-10);

    }

    public void OnFixedUpdate() {}

}