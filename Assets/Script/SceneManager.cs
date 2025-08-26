using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagers : MonoBehaviour
{
    public static SceneManagers Instance;
    private NetworkSceneManager sceneManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (NetworkManager.Singleton != null)
        {
            sceneManager = NetworkManager.Singleton.SceneManager;
        }
    }

    public void ChangeScene(string sceneName)
    {
         if (NetworkManager.Singleton == null)
    {
        Debug.LogError("NetworkManager가 없습니다! 씬에 NetworkManager 프리팹이 있는지 확인하세요.");
        return;
    }

    if (!NetworkManager.Singleton.IsHost)
    {
        Debug.LogWarning("호스트만 씬을 변경할 수 있습니다.");
        return;
    }

    // SceneManager가 초기화 안 됐으면 다시 가져오기
    if (sceneManager == null)
    {
        sceneManager = NetworkManager.Singleton.SceneManager;
    }

    if (sceneManager != null)
    {
        sceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    else
    {
        Debug.LogError("SceneManager를 가져오지 못했습니다. Enable Scene Management 옵션 확인하세요.");
    }
    }
    public void exit(){
       Debug.Log("게임 종료");
       Application.Quit();
    }
}
