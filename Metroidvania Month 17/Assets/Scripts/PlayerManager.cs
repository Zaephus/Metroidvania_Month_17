using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private PlayerController controller;

    public void Start() {
        controller = GetComponent<PlayerController>();
        controller.OnStart();
    }

    public void Update() {
        controller.OnUpdate();
    }

    public void FixedUpdate(){
        controller.OnFixedUpdate();
    }

}