using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class LobbyLoader : MonoBehaviour
{
    public void OnLeaveButtonClicked()
    {
        // NGO 연결 종료
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.Shutdown();
            // 필요하면 NetworkManager 오브젝트 제거
            Destroy(NetworkManager.Singleton.gameObject);
        }

        // 로비 씬으로 이동
        SceneManager.LoadScene("LobbyScene");
    }
}
