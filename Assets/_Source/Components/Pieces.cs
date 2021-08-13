using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    private bool _canConnect = true;
    [SerializeField]
    private int _numberOfConnections = 1;
    private int _connectionsMade = 0;
    [SerializeField]
    private ComponentType _type;

    public bool TryConnect()
    {
        if(_canConnect)
        {
            _connectionsMade++;
            if (_numberOfConnections == _connectionsMade)
                _canConnect = false;

            return true;
        }
        return false;
    }
}
