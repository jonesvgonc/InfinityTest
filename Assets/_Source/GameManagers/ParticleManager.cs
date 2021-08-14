using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField]
    private GameObject _particleSuccess;

    public void Awake()
    {
        Instance = this;
    }

    public void SuccessConnection(Vector2 position)
    {
        Instantiate(_particleSuccess, position, Quaternion.identity);
    }    
}
