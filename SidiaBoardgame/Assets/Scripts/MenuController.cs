using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class MenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
   
    public PlayerInfos player1;
    public PlayerInfos player2;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    #region Start and End game
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
    #endregion

    #region Audio Settings
    public void MasterSlider(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }
    public void SongSlider (float volume)
    {
        audioMixer.SetFloat("songVolume", volume);
    }

    public void EffectSlider (float volume)
    {
        audioMixer.SetFloat("effectsVolume", volume);
    }
    #endregion

    #region Video Settings
    public void GraphicsDropdown (int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }

    public void FullscreenToggle (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ResolutionSettings (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion]

    #region Characters choosing

    public void getPlayer1Nick(string nick)
    {
        player1.nickname = nick;
    }
    public void getPlayer2Nick(string nick)
    {
        player2.nickname = nick;
    }

    public void FinishCharacterSelection()
    {
        if (player1.nickname == "")
            player1.nickname = "Jogador 1";
        
        if (player2.nickname == "")
            player2.nickname = "Jogador 2";
        
        if (player1.life == 0)
        {
            player1.life = 12;
            player1.maxLife = 12;
            player1.damage = 2;
            player2.maxDamage = 2;
        }
        
        if (player2.life == 0)
        {
            player2.life = 12;
            player2.maxLife = 12;
            player2.damage = 2;
            player2.maxDamage = 2;
        }
    }

    #endregion
}
