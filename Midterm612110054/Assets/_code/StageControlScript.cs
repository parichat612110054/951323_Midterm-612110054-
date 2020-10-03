using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageControlScript : MonoBehaviour
{
    [SerializeField] Button _backButton;
    [SerializeField] Button _stage1Button;
    [SerializeField] Button _stage2Button;
    // Start is called before the first frame update
    void Start()
    {
       _backButton.onClick.AddListener (delegate{ BackToMainMenuButtonClick(_backButton); });
        _stage1Button.onClick.AddListener(delegate{Stage1ButtonClick(_stage1Button);});
        _stage2Button.onClick.AddListener(delegate{Stage2ButtonClick(_stage2Button);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stage1ButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneGameplay1");
    }
    public void Stage2ButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneGameplay2");
    }
    public void BackToMainMenuButtonClick(Button button) 
    {
        SceneManager.UnloadSceneAsync("SceneStage");
        SceneManager.LoadScene("SceneMainMenu");
    }
}