using UnityEngine;

public class Die : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] string sceneDie;
    void Start()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider _colider)
    {
        MonsterDetection _detect = _colider.gameObject.GetComponent<MonsterDetection>();
        if (_detect == null) return;
        SceneLoader.SeneLoader("Die");
    }
}
