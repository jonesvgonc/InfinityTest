using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineControl
{
    private GameObject[] _line;

    public GameObject[] Line { get => _line; set => _line = value; }

    public LineControl()
    {
        Line = new GameObject[1];
    }
}

public class LineDrawManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _dotPrefab;
    private LineControl _currentLine;
    private LineRenderer _lineRenderer;
    private List<Vector2> _fingerPositions;

    private void Start()
    {
        _currentLine = new LineControl();
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
        _currentLine.Line[0] = Instantiate(_dotPrefab, Vector3.zero, Quaternion.identity);
        _lineRenderer = _currentLine.Line[0].GetComponent<LineRenderer>();
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

        if (TestExtremityOfLine(hit))
        {
            hit = Physics2D.Raycast(_fingerPositions[_fingerPositions.Count() - 1], Vector3.forward, 5f);
            if (TestExtremityOfLine(hit))
            {
                DrawLine(_fingerPositions[0], _fingerPositions[_fingerPositions.Count() - 1]);
            }
        }

        Destroy(_currentLine.Line[0]);
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
        var connectionLine = Instantiate(_dotPrefab, Vector3.zero, Quaternion.identity);
        _lineRenderer = connectionLine.GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, startPoint);
        _lineRenderer.SetPosition(1, endPoint);
    }
}
