using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuControlScript : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField] Button buttonStart;
    [SerializeField] Button buttonOptions;
    [SerializeField] Button buttonCredits;
    [SerializeField] Button buttonExit;
    //[SerializeField] Button buttonSoundTestingScene;
    AudioSource audiosourceButtonUI;
    [SerializeField] AudioClip audioclipHoldOver;
    // Start is called before the first frame update
    void Start()
    {
        this.audiosourceButtonUI = this.gameObject.AddComponent <AudioSource > ();
        this.audiosourceButtonUI.outputAudioMixerGroup = SingletonSoundManager.Instance.Mixer.FindMatchingGroups("UI")[0];
        SetupButtonsDelegate ();

        if (!SingletonSoundManager.Instance.BGMSource.isPlaying)
        SingletonSoundManager.Instance.BGMSource.Play();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audiosourceButtonUI.isPlaying)
        audiosourceButtonUI.Stop ();
        audiosourceButtonUI.PlayOneShot (audioclipHoldOver);
    }
    void SetupButtonsDelegate()
    {
        buttonStart.onClick.AddListener(delegate{StartButtonClick(buttonStart);});
        buttonOptions.onClick.AddListener ( delegate {OptionsButtonClick(buttonOptions);});
        buttonCredits.onClick.AddListener ( delegate {CreditButtonClick(buttonCredits);});
        buttonExit.onClick.AddListener ( delegate {ExitButtonClick(buttonExit);});
        //buttonSoundTestingScene.onClick.AddListener ( delegate {SoundTestingButtonClick(buttonSoundTestingScene);});

    }
    public void StartButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneStage");
    }
    public void OptionsButtonClick(Button button)
    {
        if (!GameApplicationManager.Instance.IsOptionMenuActive)
        {
            SceneManager.LoadScene("SceneOptions", LoadSceneMode.Additive);
            GameApplicationManager.Instance.IsOptionMenuActive = true;
        }
    }
    public void CreditButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneCredits");
    }
    /*public void SoundTestingButtonClick(Button button)
    {
        if (SingletonSoundManager.Instance.BGMSource.isPlaying)
        SingletonSoundManager.Instance.BGMSource.Stop();

        SceneManager.LoadScene("SceneSoundTesting");
    }*/
    public void ExitButtonClick(Button button)
    {
        Application.Quit();
    }
   
}

