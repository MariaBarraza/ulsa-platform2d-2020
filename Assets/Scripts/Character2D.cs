using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Character2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    void Update()
    {
        GameplaySystem.TMovementDelta(this.transform,moveSpeed);
    }
}
