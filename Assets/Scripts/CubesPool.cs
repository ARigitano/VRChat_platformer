
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

public class CubesPool : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject[] _cubes; //Pool of platform cubes.
    private int _indexToActivate = 0;

    public void ActivateCube(Vector3 spawnPosition)
    {
        if (_indexToActivate >= _cubes.Length)
        {
            _indexToActivate = 0;
        }

        GameObject cube = _cubes[_indexToActivate];
        cube.transform.position = spawnPosition;
        _indexToActivate++;
    }
}
