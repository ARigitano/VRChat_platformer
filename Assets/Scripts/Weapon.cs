
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Weapon : UdonSharpBehaviour
{
    private int _damageAmount = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Mob>() != null)
        {
            collision.gameObject.GetComponent<Mob>().TakingDamageActivate(_damageAmount);
            Debug.Log("hit");
            //Playing weapon sound
        }
    }
}
