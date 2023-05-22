//*********************************************************************************************************************
// File: WeaponSystem.cs
//
// Description:
// This is an abstract class for the various weapons used in the game.
// - Handles shared component of weapons on rate of fire.
//*********************************************************************************************************************

using UnityEngine;

public class WeaponSystem
{
    private IFiringMechanism mFiringMechanism;
    Transform mProjectile;
    protected Transform projectile;
    protected float fireSpeed;
    protected float fireTimeout;
    protected bool firePause;

    public WeaponSystem(IFiringMechanism aFiringMechanism, Transform aProjectile, float aFireSpeed)
    {
        mFiringMechanism = aFiringMechanism;
        mProjectile = aProjectile;
        fireSpeed = aFireSpeed;
        fireTimeout = 0.0F;
        firePause = false;

    }

    public void Fire(GameObject aSource)
    {
        if (!firePause)
        {
            mFiringMechanism.Fire(aSource, mProjectile);
            firePause = true;
            fireTimeout = fireSpeed;
        }
    }

        public void CheckFiringPause()
    {
        if (firePause)
        {
            fireTimeout -= Time.deltaTime;

            if (fireTimeout < 0.0F)
                firePause = false;
        }
    }
}
