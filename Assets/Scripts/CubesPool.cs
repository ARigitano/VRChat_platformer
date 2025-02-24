
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

public class CubesPool : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject[] _cubes; //Pool of platform cubes.
    private int _activeCubeIndex; //Index of last cube active.

    //Activate a cube and deactive first cube if too many cubes.
    public void ActivateCube(Vector3 spawnPosition)
    {
        foreach(GameObject cube in _cubes)
        {
            if(!cube.activeInHierarchy)
            {
                cube.SetActive(true);
                cube.transform.position = spawnPosition;
                _activeCubeIndex = Array.IndexOf(_cubes, cube);

                if(_activeCubeIndex == _cubes.Length - 1)
                {
                    Debug.Log("ok");

                    foreach (GameObject cube2 in _cubes)
                    {
                        if (cube2.activeInHierarchy)
                        {
                            cube2.SetActive(false);
                            Debug.Log("ok2");
                            break;
                        }
                    }
                }

                break;
            }
        }
    }
}
