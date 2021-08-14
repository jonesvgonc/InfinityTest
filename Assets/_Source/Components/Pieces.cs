using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    [SerializeField]
    private int _numberOfConnections = 1;
    [SerializeField]
    private ComponentType _type;

    private bool _canConnect = true;
    private int _connectionsMade = 0;
   

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
