
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpawnPlatform : UdonSharpBehaviour
{
    public PlatformsManager platformsManager; //Manages platform cubes.
    [SerializeField]
    private float _spawnOffset = 1f; //Offset to spawn the platform.
    private bool _hasSpawned = false; //Has the next platform spawned?

    //Spawns the next platform.
    public void NextPlatform()
    {
        float randX = Random.Range(transform.position.x, transform.position.x + _spawnOffset);
        float randY = Random.Range(transform.position.y, transform.position.y + _spawnOffset);
        float randZ = Random.Range(transform.position.z, transform.position.z + _spawnOffset);

        Vector3 spawnPosition = new Vector3(randX, randY, randZ);
        platformsManager.SpawnCube(spawnPosition);

        _hasSpawned = true;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        base.OnPlayerTriggerEnter(player);

        if (!_hasSpawned)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NextPlatform");
        }
    }
}
