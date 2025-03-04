
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

    private int _nbCubes = 1; //Number of platforms that are active in the scene.

    //Spawn a new platform.
    public void SpawnCube(Vector3 spawnPosition)
    {
        GameObject cube = (GameObject)Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        cube.GetComponent<SpawnPlatform>().platformsManager = this;

        if(_nbCubes >= _cubes.Length)
        {
            _nbCubes = 0;
        }

        if(_cubes[_nbCubes] != null)
        {
            Destroy(_cubes[_nbCubes]);
        }

        _cubes[_nbCubes] = cube;
        _nbCubes++;

    }
}
