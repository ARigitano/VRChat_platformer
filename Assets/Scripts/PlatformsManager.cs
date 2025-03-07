
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

public class PlatformsManager : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab; //Prefab for a platform.
    [SerializeField]
    private GameObject[] _cubes; //Platforms currently active in the scene.
    [SerializeField]
    private Transform _firstCubePosition; //Position of the first platform.

    private int _nbActiveCubes = 1; //Number of platforms that are active in the scene.
    private int _nbTotalCubes = 0; // Total number of cubes that have spawned.
    public String firstPlayerName = ""; // Name of the player who is first in the race.

    [SerializeField]
    private HighscoreBoard _highscoreBoard; //Script reference for the highscore board.

    //Spawn a new platform.
    public void SpawnCube(Vector3 spawnPosition, VRCPlayerApi firstPlayer)
    {
        GameObject cube = (GameObject)Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        cube.GetComponent<SpawnPlatform>().platformsManager = this;

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

        firstPlayerName = firstPlayer.displayName;
        _nbTotalCubes++;

        _highscoreBoard.UpdateBoard(firstPlayerName, _nbTotalCubes.ToString());
    }
}
