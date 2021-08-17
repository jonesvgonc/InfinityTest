using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _dotPrefab;
    [SerializeField]
    private Material _blueMaterial;
    [SerializeField]
    private Transform _piecesParent;

    private GameObject _currentLine;
    private LineRenderer _lineRenderer;
    private List<Vector2> _fingerPositions;    

    private void Start()
    {
        _fingerPositions = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if(Input.GetMouseButton(0))
        {
            var tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempFingerPos, _fingerPositions[_fingerPositions.Count() -1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            CalculateConnections();
        }
    }

    void CreateLine()
    {
        _currentLine = Instantiate(_dotPrefab, Vector3.zero, Quaternion.identity);
        _lineRenderer = _currentLine.GetComponent<LineRenderer>();
        _fingerPositions.Clear();
        _fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _lineRenderer.SetPosition(0, _fingerPositions[0]);
        _lineRenderer.SetPosition(1, _fingerPositions[0]);
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        _fingerPositions.Add(newFingerPos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, newFingerPos);
    }    

    void CalculateConnections()
    {        
        var hit = Physics2D.Raycast(_fingerPositions[0], Vector3.forward, 5f);
        var connected = false;
        if (TestExtremityOfLine(hit))
        {
            var firstPiece = hit.rigidbody.GetComponent<Pieces>();
            if (firstPiece.TryConnect())
            {
                hit = Physics2D.Raycast(_fingerPositions[_fingerPositions.Count() - 1], Vector3.forward, 5f);
                if (TestExtremityOfLine(hit))
                {
                    var secondPiece = hit.rigidbody.GetComponent<Pieces>();
                    if (secondPiece.TryConnect())
                    {
                        ParticleManager.Instance.SuccessConnection(_fingerPositions[0]);
                        ParticleManager.Instance.SuccessConnection(_fingerPositions[_fingerPositions.Count() - 1]);
                        GameDataManager.Instance.LevelConnectionsMade++;
                        AudioManager.Instance.PlayElletricSparks();
                        firstPiece.MakeConnection();
                        secondPiece.MakeConnection();
                        connected = true;
                        GameDataManager.Instance.Score += 10;                        
                        DrawLine(_fingerPositions[0], _fingerPositions[_fingerPositions.Count() - 1]);
                        UIManager.Instance.ChangeScoreText(GameDataManager.Instance.Score);
                    }
                }
            }
        }

        Destroy(_currentLine);

        if(GameDataManager.Instance.EndGame() && GameDataManager.Instance.GameStarted)
        {
            GameManager.Instance.LevelEnd();
        }else if(connected)
        {
            StartCoroutine(CameraShake.Instance.Shake(0.2f, 0.2f));
        }
    }

    bool TestExtremityOfLine(RaycastHit2D hit)
    {
        if (hit.rigidbody != null &&
            (hit.rigidbody.gameObject.CompareTag(StaticStrings.PowerSource) ||
            hit.rigidbody.gameObject.CompareTag(StaticStrings.Machine)))
        {
            return true;
        }

        return false;
    }

    private void DrawLine(Vector2 startPoint, Vector2 endPoint)
    {
        var connectionLine = Instantiate(_dotPrefab, Vector3.zero, Quaternion.identity, _piecesParent);
        _lineRenderer = connectionLine.GetComponent<LineRenderer>();
        _lineRenderer.materials = new Material[] { _blueMaterial };
        _lineRenderer.sortingOrder = -100;
        _lineRenderer.SetPosition(0, startPoint);
        _lineRenderer.SetPosition(1, endPoint);
    }
}
