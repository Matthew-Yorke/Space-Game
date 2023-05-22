//*********************************************************************************************************************
// File: Ship.cs
//
// Description:
// This class handles the code for the ship the player controls:
// - Holds components of the ship.
// - Handles movement of the ship.
// - Handles firing of the weapons of the ship.
//*********************************************************************************************************************

using UnityEngine;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{
    public int health;
    // Movement System
    public int forwardSpeed;
    public int rotationSpeed;
    public enum rotationDirection { LEFT, RIGHT };
    // Weapons System
    private List<WeaponSystem> mMainWeapon;
    int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        mMainWeapon = new List<WeaponSystem> ();
        mMainWeapon.Add(new WeaponSystem(new DualShot(),
                                         GameObject.FindWithTag("projectilesList").GetComponent<ProjectilePrefabListing>().mRocket,
                                         1.0F));
        currentWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mMainWeapon.ForEach(weapon => weapon.CheckFiringPause());
    }


    public void MoveForward()
    {
        this.transform.position += this.transform.up * Time.deltaTime * forwardSpeed;

        CheckBoundaries();
    }


    public void Turn(rotationDirection aDirectoin)
    {
        if (aDirectoin == rotationDirection.LEFT)
            this.transform.Rotate(Vector3.forward * rotationSpeed);
        else if (aDirectoin == rotationDirection.RIGHT)
            this.transform.Rotate(Vector3.forward * -rotationSpeed);
    }

    public void Fire()
    {
        mMainWeapon[currentWeapon].Fire(this.gameObject);
        //Transform projectile = mMainWeapon[currentWeapon].Fire();
        //
        //if (projectile == null)
        //    return;
        //else
        //    Instantiate(projectile, transform.position, transform.rotation);
    }

    private void CheckBoundaries()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.0F || pos.x > 1.0F)
            this.transform.position = new Vector3(-this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (pos.y < 0.0F || pos.y > 1.0F)
            this.transform.position = new Vector3(this.transform.position.x, -this.transform.position.y, this.transform.position.z);
    }
}
