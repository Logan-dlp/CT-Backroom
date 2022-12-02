using UnityEngine;

public class Die : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision _collision)
    {
        MonsterDetection _detect = _collision.gameObject.GetComponent<MonsterDetection>();
        if (_detect != null) SceneLoader.SeneLoader("Die"); ;

        Door _door = _collision.gameObject.GetComponent<Door>();
        if (_door != null) SceneLoader.SeneLoader("Win");
    }
}
