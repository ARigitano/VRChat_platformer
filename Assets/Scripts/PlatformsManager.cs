
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

//Not synched over the network : to fix
public class PlatformsManager : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab; //Prefab for a platform.
    [SerializeField]
    private SpawnPlatform _baseCube; //Script of the cube that starts the spawning.
    

    [SerializeField]
    private float _spawnOffset = 0f; //Offset to spawn the platform.

    private float _timer = 2f; //Timer before next platform is spawned.
    private float _interval = 2f; //Time between each platform spawning.
    private bool _isRunning = false; //Should platform be spawned?

    private float _randX; //X coordinate for platform spawning.
    private float _randY; //Y coordinate for platform spawning.
    private float _randZ; //Z coordinate for platform spawning.

    [SerializeField]
    private int _nbPlatformsToSpawn = 6; //Number of platforms to spawn
    private int _nbPlatformsSpawned = 0; //Number of platforms spawned.

    private void Reset()
    {
        _randX = transform.position.x;
        _randY = transform.position.y;
        _randZ = transform.position.z;
    }

    //Starts spawning platforms.
    public void StartPlatformSpawning()
    {
        Reset();
        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                if (_nbPlatformsSpawned <= _nbPlatformsToSpawn)
                {
                    SpawnPlatform();
                    _timer = _interval;
                    _nbPlatformsSpawned++;
                }
                else
                {
                    _nbPlatformsSpawned = 0;
                    _isRunning = false;
                    _baseCube.ResetActivate();
                }
            }
        }
    }

    //Launches the spawning of a platform.
    private void SpawnPlatform()
    {
        SpawnCube();
    }

    //Spawns a new platform.
    public void SpawnCube()
    {
        _randX += Random.Range(transform.position.x, transform.position.x + _spawnOffset);
        _randY += Random.Range(transform.position.y, transform.position.y + _spawnOffset);
        _randZ += Random.Range(transform.position.z, transform.position.z + _spawnOffset);

        Vector3 spawnPosition = new Vector3(_randX, _randY, _randZ);

        GameObject cube = (GameObject)Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        Destroy(cube, 10f);
    }
}
