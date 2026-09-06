using UnityEngine;

public class ZonaDeth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))        
            player.PlayerDied();
    }
}
