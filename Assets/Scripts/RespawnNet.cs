
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RespawnNet : UdonSharpBehaviour
{
    [SerializeField]
    private Transform _spawnPoint; //Position at which the player will be respawned.
    [SerializeField]
    private PlatformsManager _manager; //Reference to the platform manager script.
    [SerializeField]
    private Transform _firstCubeTransform; //Transform of the first platform.
    private Transform _firstTransformSave; //Saving the transform of the first platform.

    private void Start()
    {
        _firstTransformSave = _firstCubeTransform;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        base.OnPlayerTriggerEnter(player);

        player.TeleportTo(_spawnPoint.position, Quaternion.identity);

        if(player.displayName == _manager.firstPlayerName)
        {
            _manager.SpawnCube(_firstTransformSave.position, player);
        }
    }
}
