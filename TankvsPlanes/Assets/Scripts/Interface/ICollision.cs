using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollision 
{
    void OnTriggerEnter2D(Collider2D collision);
}