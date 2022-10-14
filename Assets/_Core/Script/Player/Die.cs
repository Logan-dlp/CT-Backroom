using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider _colider)
   {
        MonsterDetection _detect = _colider.gameObject.GetComponent<MonsterDetection>();
        if (_detect == null) return;
        transform.position = new Vector3(0, 0, 0);
    }
}
