using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    GameObject gameObject { get; }
    Rigidbody rigidBody { get; set; }

    void PerformAction();
}
