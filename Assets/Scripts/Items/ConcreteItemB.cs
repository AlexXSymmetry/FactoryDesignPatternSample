using UnityEngine;

public class ConcreteItemB : MonoBehaviour, IItem
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

        rigidBody.isKinematic = !rigidBody.isKinematic;
    }
}
