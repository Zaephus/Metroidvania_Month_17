using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private PlayerController controller;
    private PlayerInteract interact;
    public PlayerCamera cam;

    public void Start() {

        controller = GetComponent<PlayerController>();
        controller.OnStart();

        interact = FindObjectOfType<PlayerInteract>();
        interact.OnStart(this);

        cam = FindObjectOfType<PlayerCamera>();
        cam.OnStart();

    }

    public void Update() {

        controller.OnUpdate();
        interact.OnUpdate();
        cam.OnUpdate();

    }

    public void FixedUpdate(){

        controller.OnFixedUpdate();
        cam.OnFixedUpdate();
        
    }

}