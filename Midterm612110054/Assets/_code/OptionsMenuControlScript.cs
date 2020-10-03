using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using KSCamt;

public class OptionsMenuControlScript : MonoBehaviour
{
    [SerializeField]
    Dropdown _dropdownDifficulty;
    [SerializeField]
    Toggle _toggleMusic;
    [SerializeField]
    Toggle _toggleSFX;
    [SerializeField]
    Button _backButton;
    // Start is called before the first frame update
    void Start()
    {
        _dropdownDifficulty.value = SingletonGameAppicationManager.Instance.
DifficultyLevel;
        _toggleMusic.isOn = SingletonGameAppicationManager.Instance.MusicEnabled;
        _toggleSFX.isOn = SingletonGameAppicationManager.Instance.SFXEnabled;

        _dropdownDifficulty.onValueChanged.AddListener(delegate{DropdownDifficultyChanged(_dropdownDifficulty);});
        _toggleMusic.onValueChanged.AddListener(delegate{OnToggleMusic(_toggleMusic);});
        _toggleSFX.onValueChanged.AddListener(delegate{OnTogglrSFX(_toggleSFX);});
        _backButton.onClick.AddListener(delegate{BackButtonClick(_backButton);});

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackButtonClick(Button button)
    {
        SceneManager.UnloadSceneAsync("SceneOptions");
        SingletonGameAppicationManager.Instance.IsOptionMenuActive = false;
    }
    public void DropdownDifficultyChanged(Dropdown dropdown)
    {
        SingletonGameAppicationManager.Instance.DifficultyLevel = dropdown.value;
    }
    public void OnToggleMusic(Toggle toggle)
    {
        SingletonGameAppicationManager.Instance.MusicEnabled = _toggleMusic.isOn;
        if (SingletonGameAppicationManager.Instance.MusicEnabled)
        SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.Instance.
        MusicVolumeDefault;
        else
        SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.MUTE_VOLUME;


    }
    public void OnTogglrSFX(Toggle toggle)
    {
        SingletonGameAppicationManager.Instance.SFXEnabled = _toggleSFX.isOn;
        if (SingletonGameAppicationManager.Instance.SFXEnabled)
        SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.
        Instance.MasterSFXVolumeDefault;
        else
        SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.MUTE_VOLUME;
    }
}
