using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // if we left click
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                //Swing sword
            }
        }

        // if we right click
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                //Fire projectile
            }
        }
    }
}
