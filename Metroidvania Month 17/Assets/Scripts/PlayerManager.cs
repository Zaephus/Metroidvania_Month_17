using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private PlayerController controller;
    private PlayerCamera playerCamera;

    public void Start() {

        controller = GetComponent<PlayerController>();
        controller.OnStart();

        playerCamera = FindObjectOfType<PlayerCamera>();
        playerCamera.OnStart();

    }

    public void Update() {

        controller.OnUpdate();
        playerCamera.OnUpdate();

    }

    public void FixedUpdate(){

        controller.OnFixedUpdate();
        playerCamera.OnFixedUpdate();
        
    }

}