using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public GameObject camera;
    private CamaraMovement scriptCamara;

    void Start()
    {
        scriptCamara = camera.GetComponent<CamaraMovement>();
    }

    public void OnSliderChange(float value)
    {
        scriptCamara.Sensibility = value;
    }

}
