using System;
using UnityEngine;

public class ItemFactory
{
    private GameObject itemAPrefab;
    private GameObject itemBPrefab;

    public ItemFactory()
    {
        itemAPrefab = Resources.Load<GameObject>("Prefabs/ItemBodyA");
        itemBPrefab = Resources.Load<GameObject>("Prefabs/ItemBodyB");
    }

    public IItem Create(ItemType itemType, Vector3 itemStartingPosition)
    {
        var item = GetItemByType(itemType);
        var itemBody = ((Component)item).gameObject;
        itemBody.transform.position = itemStartingPosition;
        if (itemBody.GetComponent<Rigidbody>() == null)
        {
            var rb = SetupItemRigidBody(itemBody);
            item.rigidBody = rb;
        }
        return item;
    }
    #region PRIVATE METHODS

    private Rigidbody SetupItemRigidBody(GameObject itemBody)
    {
        var rb = itemBody.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        return rb;
    }


    private IItem GetItemByType(ItemType itemType)
    {
        IItem item = null;

        switch (itemType)
        {
            case ItemType.Cross:
                item = GameObject.Instantiate<GameObject>(itemBPrefab).AddComponent<ConcreteItemB>();
                break;
            case ItemType.Cube:
                item = GameObject.Instantiate<GameObject>(itemAPrefab).AddComponent<ConcreteItemA>();
                break;
            default:
                break;
        }

        return item;
    }

    #endregion
}
