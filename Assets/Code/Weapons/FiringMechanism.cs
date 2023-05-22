//*********************************************************************************************************************
// File: FiringMechanism.cs
//
// Description:
// This is an abstract class for the various weapons used in the game.
// - Handles shared component of weapons on rate of fire.
//*********************************************************************************************************************

using UnityEngine;

public interface IFiringMechanism
{
    public void Fire(GameObject aSource, Transform aProjectile);
}
