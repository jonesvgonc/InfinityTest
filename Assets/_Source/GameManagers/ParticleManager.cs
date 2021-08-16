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

    public void EndLevelCommemoration()
    {
        StartCoroutine(EmitParticles(0.5f));
    }

    public IEnumerator EmitParticles(float value)
    {
        for (int index = 0; index < 10; index++)
        {
            yield return new WaitForSeconds(value);
            var position = new Vector2(Random.Range(-2, 3), Random.Range(-4, 5));
            Instantiate(_particleSuccess, position, Quaternion.identity);
        }
    }
}
