using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject optionsCloser;
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionPicker;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionPicker.ClearOptions();

        List<string> options = new List<string>();
        int resolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }
        }

        resolutionPicker.AddOptions(options);
        resolutionPicker.value = resolutionIndex;
        resolutionPicker.RefreshShownValue();
    }
    public void openMenu()
    {
        optionsMenu.SetActive(true);
        optionsCloser.SetActive(true);
    }

    public void closeMenu()
    {
        optionsMenu.SetActive(false);
        optionsCloser.SetActive(false);
    }

    public void volumeAdjust(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log("The Quality index is: " + index);
    }

    public void fullScreenToggle(bool status)
    {
        Screen.fullScreen = status;
    }
    public void resolutionChange(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
