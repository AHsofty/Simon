using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRes : MonoBehaviour
{
    void Start()
    {
        Camera.main.aspect = 16 / 9; // Hardcoding <3
    }


}
