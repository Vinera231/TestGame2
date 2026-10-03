using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetWorlkManagerUI : MonoBehaviour
{
    [SerializeField] private Button _host;
    [SerializeField] private Button _client;

    private void Awake()
    {
        _host.onClick.AddListener(() =>{        
            NetworkManager.Singleton.StartHost();
        });
        _client.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }
}
