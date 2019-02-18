using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 1f;

    public float newItemY;
    public float cutoffY;
    public float newItemZ;

    private List<IItem> itemList = new List<IItem>();
    private ItemFactory itemFactory;
    private bool isSpaceDown = false;

    #region ENTRY POINT

    private void Awake()
    {
        itemFactory = new ItemFactory();

        for (int i = 0; i < 10; i++)
            CreateItem();
    }

    #endregion

    #region MAIN LOOP

    private void Update()
    {
        foreach (var item in itemList)
        {
            if (item.gameObject.transform.position.y < cutoffY)
                RepositionItem(item);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            foreach (var item in itemList)
                item.PerformAction();
        
    }
    #endregion

    #region PRIVATE METHODS

    private void CreateItem()
    {
        var itemType = (UnityEngine.Random.Range(0, 2) == 0) ? ItemType.Cross : ItemType.Cube;
        itemList.Add(itemFactory.Create(itemType, GetRandomStartingPosition()));
    }

    private void RepositionItem(IItem item)
    {
        item.gameObject.transform.position = GetRandomStartingPosition();
        item.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private Vector3 GetRandomStartingPosition()
    {
        float itemX = UnityEngine.Random.Range(minX, maxX);
        float itemY = newItemY;
        float itemZ = newItemZ;

        return new Vector3(itemX, itemY, itemZ);
    }

    #endregion
}
