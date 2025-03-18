using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HighJump : UdonSharpBehaviour
{
    [SerializeField]
    private float jumpPower = 50f; //New high at which the player will jump.

    private void Start()
    {
        VRCPlayerApi player = Networking.LocalPlayer;

        if (player != null)
        {
            player.SetJumpImpulse(jumpPower);
            Debug.Log("[HighJump] Jump power set to " + jumpPower);
        }
    }
}
