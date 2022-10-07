using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AutoScaleBoxCollider : MonoBehaviour
{
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        if(TryGetComponent(out Collider col))
        {
            object obj = col;
            obj.GetType()
            .GetProperty("size")
            .SetValue(GetComponent<Collider>(), rend.localBounds.size);
        }


    }
    
}

