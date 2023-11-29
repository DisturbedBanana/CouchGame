using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tombstone : MonoBehaviour
{
    [SerializeField] private int _tombstoneId;

    public int TombstoneId { get { return _tombstoneId; } set { _tombstoneId = value; } }
}
