
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Mob : UdonSharpBehaviour
{
    private int _health = 10;
    private int _damageTaken = 0;

    public void TakingDamageActivate(int damageTaken)
    {
        damageTaken = _damageTaken;
        TakingDamage(); //To replace with a network event.
    }

    private void TakingDamage()
    {
        _health -= _damageTaken;

        if(_health <= 0)
        {
            Destroy(gameObject); //To replace with death animation.
        }
    }
}
