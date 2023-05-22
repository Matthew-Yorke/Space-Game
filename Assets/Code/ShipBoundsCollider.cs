using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoundsCollider : MonoBehaviour
{
    private Camera mMainCamera;
    private bool moveVerticalCamera;
    private bool moveHorizontalCamera;
    private bool top = false;
    private bool bottom = false;
    private bool left = false;
    private bool right = false;

    const string mVerticalCameraBoundaryTag = "VerticalCameraBoundary";
    const string mHorizontalCameraBoundaryTag = "HorizontalCameraBoundary";
    const string mUpperBoundaryName = "UpperBoundary";
    const string mLowerBoundaryName = "LowerBoundary";
    const string mLeftBoundaryName = "LeftBoundary";
    const string mRightBoundaryName = "RightBoundary";

    // Start is called before the first frame update
    void Start()
    {
        mMainCamera = Camera.main;
        moveVerticalCamera = false;
        moveHorizontalCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get x and y movement speeds based on the ship's forward speed and it's current angle.
        float x = GetComponentInParent<Ship>().forwardSpeed * Mathf.Sin(Mathf.Deg2Rad * GetComponentInParent<Ship>().transform.rotation.eulerAngles.z);
        float y = GetComponentInParent<Ship>().forwardSpeed * Mathf.Cos(Mathf.Deg2Rad * GetComponentInParent<Ship>().transform.rotation.eulerAngles.z);

        // Move the camera vertically based on the ship's y speed
        if (moveVerticalCamera)
        {
            if (top)
                mMainCamera.transform.Translate(new Vector3(0, Mathf.Abs(Time.deltaTime * y), 0));
            else if (bottom)
                mMainCamera.transform.Translate(new Vector3(0, -Mathf.Abs(Time.deltaTime * y), 0));
        }

        // Mov the camera horizontally based on the ship's x speed.
        if(moveHorizontalCamera)
        {
            if (right)
                mMainCamera.transform.Translate(new Vector3(Mathf.Abs(Time.deltaTime * x), 0, 0));
            else if (left)
                mMainCamera.transform.Translate(new Vector3(-Mathf.Abs(Time.deltaTime * x), 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == mVerticalCameraBoundaryTag)
        {
            moveVerticalCamera = true;
            if (otherCollider.name == mUpperBoundaryName)
                top = true;
            else if (otherCollider.name == mLowerBoundaryName)
                bottom = true;
        }

        if (otherCollider.tag == mHorizontalCameraBoundaryTag)
        {
            moveHorizontalCamera = true;
            if (otherCollider.name == mLeftBoundaryName)
                left = true;
            else if (otherCollider.name == mRightBoundaryName)
                right = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == mVerticalCameraBoundaryTag)
        {
            moveVerticalCamera = false;
            if (otherCollider.name == mUpperBoundaryName)
                top = false;
            else if (otherCollider.name == mLowerBoundaryName)
                bottom = false;
        }

        if (otherCollider.tag == mHorizontalCameraBoundaryTag)
        {
            moveHorizontalCamera = false;
            if (otherCollider.name == mLeftBoundaryName)
                left = false;
            else if (otherCollider.name == mRightBoundaryName)
                right = false;
        }
    }
}
