using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBlock : MonoBehaviour
{
    [SerializeField] GameObject invisibleBarrier;

    private void OnMouseDown()
    {
        invisibleBarrier.SetActive(true);
    }
}
