using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public Guid _objectId;

    public string ObjectId;

    private void Start()
    {
        _objectId = Guid.NewGuid();
        ObjectId = _objectId.ToString();
    }

    private void Update()
    {
        
    }
}
