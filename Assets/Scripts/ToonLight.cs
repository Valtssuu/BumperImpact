using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonLight : MonoBehaviour
{
    private Light light = null;

    private void OnEnable()
    {
        light = this.GetComponent<Light>();
    }

    private void Update()
    {
        Shader.SetGlobalVector("_ToonLightDirection", -this.transform.forward);
    }
}
