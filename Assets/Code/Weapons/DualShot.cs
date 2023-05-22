//*********************************************************************************************************************
// File: DualShot.cs
//
// Description:
// This is the standard machinegun type weapon that fires standard projectiles at a steady rate.
//*********************************************************************************************************************
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class DualShot : IFiringMechanism
{
    public void Fire(GameObject aSource, Transform aProjectile)
    {
        // The value of half of one Unit in the world. This is th value in Units for half the sprite (e.g., from center to an edge)
        const float halfSizeUnit = 0.5F;
        // The distance from the center to edge (0.0 being center and 1.0 being the edge of the sprite)
        const float distancFromCenter = 0.75F;

        // Get offset by calculating the distance from the sprite center to one edge based on the sprite's scaled along the x axis and then
        // multiplying by the desired distance from center.
        float offsetDistance = (halfSizeUnit * aSource.transform.localScale.x) * distancFromCenter;

        // Create two bullets that offset from the center of the source based on the source's angle.
        float angleRads = Mathf.Deg2Rad * aSource.transform.rotation.eulerAngles.z;
        Vector3 leftBarrelOffset = new Vector3(aSource.transform.position.x + (-offsetDistance * Mathf.Cos(angleRads)),
                                               aSource.transform.position.y + (-offsetDistance * Mathf.Sin(angleRads)), 0);
        Vector3 rightBarrelOffset = new Vector3(aSource.transform.position.x + (offsetDistance * Mathf.Cos(angleRads)),
                                                aSource.transform.position.y + (offsetDistance * Mathf.Sin(angleRads)), 0);
        Object.Instantiate(aProjectile, leftBarrelOffset, aSource.transform.rotation);
        Object.Instantiate(aProjectile, rightBarrelOffset, aSource.transform.rotation);
    }
}