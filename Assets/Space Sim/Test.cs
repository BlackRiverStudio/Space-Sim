using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private void Start()
    {
        ResolutionSetup();
    }
    public void ChangeScene(int _sceneId) => SceneManager.LoadScene(_sceneId);
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    #region Audio
    public AudioMixer masterAudio;
    public void ChangeVolume(float _volume) => masterAudio.SetFloat("volume", _volume);
    public void ToggleMute(bool _isMuted)
    {
        if (_isMuted) masterAudio.SetFloat("isMutedVolume", -80);
        else masterAudio.SetFloat("isMutedVolume", 0);
        _ = true ? masterAudio.SetFloat("", 0) : masterAudio.SetFloat("", 0);
    }
    #endregion
    public void Quality(int _qualityIndex) => QualitySettings.SetQualityLevel(_qualityIndex);
    #region Fullscreen Resolution
    public void FullscreenToggle(bool _isFullscreen) => Screen.fullScreen = _isFullscreen;
    public Resolution[] resolutions;
    public Dropdown dropdown;
    private void ResolutionSetup()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutionIndex = i;
            dropdown.AddOptions(resolutionOptions);
            dropdown.value = currentResolutionIndex;
            dropdown.RefreshShownValue();
        }
    }
    public void SetResolution(int _resolutionIndex)
    {
        Resolution res = resolutions[_resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    #endregion
}
