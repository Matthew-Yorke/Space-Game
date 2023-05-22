//*********************************************************************************************************************
// File: Bullet.cs
//
// Description:
// This is the script to handle the standard bullet type projectile that fires in a straight line from it's source.
//*********************************************************************************************************************

using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D mRigidBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mRigidBody.isKinematic = true;
        
        //mRigidBody.AddForce(angle * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();
    }

    private void Move()
    {
        Vector2 angle = new Vector2(-Mathf.Sin(mRigidBody.rotation * Mathf.Deg2Rad), Mathf.Cos(mRigidBody.rotation * Mathf.Deg2Rad));
        mRigidBody.MovePosition(mRigidBody.position + angle * Time.deltaTime * speed);
    }

    private void CheckBoundaries()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.0F || pos.x > 1.0F)
            Destroy(gameObject);

        if (pos.y < 0.0F || pos.y > 1.0F)
            Destroy(gameObject);
    }
}
