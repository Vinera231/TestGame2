using UnityEngine;

public class WinZona : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))        
            player.PlayerWin();
    }
}
