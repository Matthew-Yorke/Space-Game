//*********************************************************************************************************************
// File: SingleShot.cs
//
// Description:
// This is the standard machinegun type weapon that fires standard projectiles at a steady rate.
//*********************************************************************************************************************
using UnityEngine;

public class SingleShot : IFiringMechanism
{
    public void Fire(GameObject aSource, Transform aProjectile)
    {
        Object.Instantiate(aProjectile, aSource.transform.position, aSource.transform.rotation);
    }
}
