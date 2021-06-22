using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtons : MonoBehaviour
{
    public Scrollbar volume;
    public Dropdown quality;
    public Toggle fullScreen;
    public Dropdown resolution;

    public AudioSource backgroundVolume;

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;

        resolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolution.AddOptions(options);

        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }
    private void Awake()
    {
        GetVolumeValue();
        GetQuality();
        GetFullScreen();
    }

    public void GetVolumeValue()
    {
        volume.value = backgroundVolume.volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void GetQuality()
    {
        quality.value = QualitySettings.GetQualityLevel();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void GetFullScreen()
    {
        fullScreen.isOn = Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
