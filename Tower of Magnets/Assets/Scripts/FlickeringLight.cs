using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlickeringLight : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D _light2D;
    void Start()
    {
        _light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    
    void Update()
    {
        _light2D.intensity = Random.Range(1f, 2f);
    }
}
