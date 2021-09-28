using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Background;
    // Update is called once per frame
    void PlayCutscene()
    {
        Background.SetActive(true);
    }
}
