using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    private int sceneIndex = 0;
    public int charIndex = 0;

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this as LoadSceneManager;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void OnLoadScene()
    {
        sceneIndex++;
        Fade.onFadeAct(3f, Color.white, true, () => SceneManager.LoadScene(sceneIndex));
    }

    public void SetCharIndex(int index)
    {
        charIndex = index;
    }
}
