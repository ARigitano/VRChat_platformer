
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlatformsManager : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab; //Prefab for a platform.
    [SerializeField]
    private GameObject[] _cubes; //Platforms currently active in the scene.

    private int _nbActiveCubes = 1; //Number of platforms that are active in the scene.
    private int _nbTotalCubes = 0; // Total number of cubes that have spawned.
    public System.String firstPlayerName = ""; // Name of the player who is first in the race.

    [SerializeField]
    private HighscoreBoard _highscoreBoard; //Script reference for the highscore board.

    [SerializeField]
    private float _spawnOffset = 1f; //Offset to spawn the platform.

    private float _timer = 3f;
    private float _interval = 3f; // Time between each execution
    private bool _isRunning = false;

    private float randX;
    private float randY;
    private float randZ;

    private void Start()
    {
        randX = transform.position.x;
        randY = transform.position.y;
        randZ = transform.position.z;
    }

    public void StartCoroutineSimulation()
    {
        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                ExecuteAfterDelay();
                _timer = _interval;
            }
        }
    }

    private void ExecuteAfterDelay()
    {
        SpawnCube();
        Debug.Log("spawned");
    }

    //Spawn a new platform.
    public void SpawnCube()
    {
        randX += Random.Range(transform.position.x, transform.position.x + _spawnOffset);
        randY += Random.Range(transform.position.y, transform.position.y + _spawnOffset);
        randZ += Random.Range(transform.position.z, transform.position.z + _spawnOffset);

        Vector3 spawnPosition = new Vector3(randX, randY, randZ);

        GameObject cube = (GameObject)Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        //cube.GetComponent<SpawnPlatform>().platformsManager = this;

        if(_nbActiveCubes >= _cubes.Length)
        {
            _nbActiveCubes = 0;
        }

        if(_cubes[_nbActiveCubes] != null)
        {
            Destroy(_cubes[_nbActiveCubes]);
        }

        _cubes[_nbActiveCubes] = cube;
        _nbActiveCubes++;

        //firstPlayerName = firstPlayer.displayName;
        _nbTotalCubes++;

        _highscoreBoard.UpdateBoard(firstPlayerName, _nbTotalCubes.ToString());
    }
}
