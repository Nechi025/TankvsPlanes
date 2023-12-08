using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float lifetime = 3f;


    private void Start()
    {

        Destroy(gameObject, lifetime);

    }

}