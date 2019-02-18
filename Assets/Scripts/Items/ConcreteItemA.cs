using UnityEngine;

public class ConcreteItemA : MonoBehaviour, IItem
{
    public Rigidbody rigidBody
    {
        get;
        set;
    }

    public void PerformAction()
    {
        if (rigidBody == null)
            rigidBody = gameObject.AddComponent<Rigidbody>();

        rigidBody.velocity = Vector3.up * 10;
    }
}
