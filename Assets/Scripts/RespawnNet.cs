
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RespawnNet : UdonSharpBehaviour
{
    [SerializeField]
    private Transform _spawnPoint; //Position at which the player will be respawned.

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        base.OnPlayerTriggerEnter(player);

        player.TeleportTo(_spawnPoint.position, Quaternion.identity);
    }
}
