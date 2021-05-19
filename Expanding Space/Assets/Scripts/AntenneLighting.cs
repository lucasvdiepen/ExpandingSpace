using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenneLighting : MonoBehaviour
{
    public Light antenneLight;

    public void SetBrightness(int brightness)
    {
        antenneLight.intensity = brightness * 0.01f;
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
