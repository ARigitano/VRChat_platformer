
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpawnPlatform : UdonSharpBehaviour
{
    public PlatformsManager platformsManager; //Manages platform cubes.
    
    private bool _hasSpawned = false; //Has the next platform spawned?
    private VRCPlayerApi _collisionPlayer; //Player who jumped on this platform.
    [SerializeField]
    private GameObject _cubePrefab; //Prefab for a platform.

    //Spawns the next platform.
    public void NextPlatform()
    {
        platformsManager.SpawnCube();
        platformsManager.StartPlatformSpawning();
        _hasSpawned = true;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        base.OnPlayerTriggerEnter(player);

        if (!_hasSpawned)
        {
            _collisionPlayer = player;
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NextPlatform");
        }
    }
}
