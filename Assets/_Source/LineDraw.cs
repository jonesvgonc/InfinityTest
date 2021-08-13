using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    [SerializeField]
    private GameObject _dotPrefab;
    [SerializeField]
    private GameObject _currentLine;

    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private EdgeCollider2D _edgeCollider;
    [SerializeField]
    private List<Vector2> _fingerPositions;

    // Start is called before the first frame update
    void Start()
    {
        
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
        _edgeCollider = _currentLine.GetComponent<EdgeCollider2D>();
        _fingerPositions.Clear();
        _fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _lineRenderer.SetPosition(0, _fingerPositions[0]);
        _lineRenderer.SetPosition(1, _fingerPositions[0]);

        _edgeCollider.points = _fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        _fingerPositions.Add(newFingerPos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, newFingerPos);
        _edgeCollider.points = _fingerPositions.ToArray();
    }

    void CalculateConnections()
    {

    }
}
