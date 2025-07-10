using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioChangerScript : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }
}