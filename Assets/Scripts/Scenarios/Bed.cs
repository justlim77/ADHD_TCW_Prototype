using UnityEngine;
using System.Collections;

public class Bed : MonoBehaviour
{
    public static Bed Instance { get; private set; }
    public BoxCollider2D bcBed;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetBoxCollider(bool isActive)
    {
        if (!GameManager.isTempPause)
        {
            bcBed.enabled = isActive;
        }
    }
}
