using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenneLighting : MonoBehaviour
{
    public Light antenneLight;

    public float minIntensity = 0f;
    public float maxIntensity = 50f;

    public void SetBrightness(int brightness)
    {
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, brightness * 0.01f);

        antenneLight.intensity = intensity;
    }

    public void EnableLight()
    {
        antenneLight.gameObject.SetActive(true);
    }

    public void DisableLight()
    {
        antenneLight.gameObject.SetActive(false);
    }
}
