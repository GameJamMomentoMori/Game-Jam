using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int maxHP = 100;
    private int maxSP = 25;
    private int atk = 5;
    private int def = 5;
    private int INT = 5;
    private int res = 5;
    private int atkRange = 1;
    private int intRange = 5;
    bool itemChoice = false; //0 = melee; 1 = range

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            if(itemChoice) {
                MeleeAtk();
            } else {
                RangeAtk();
            }
        }
    }

    void MeleeAtk () {

    }

    void RangeAtk() {

    }

    void Damage() {

    }
}
