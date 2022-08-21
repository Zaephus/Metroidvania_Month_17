using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public void Start() {
        StartCoroutine(DoBehaviour());
    }

    public void Update() {

    }

    public IEnumerator DoBehaviour() {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}