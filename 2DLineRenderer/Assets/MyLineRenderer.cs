using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLineRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider2D;
    private Camera _mainCam;

    private List<Vector3> pointsForDraw = new List<Vector3>();
    private List<Vector2> pointsForEdge = new List<Vector2>();
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        _mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            DrawTheLine();
        }
    }
    private void DrawTheLine()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 converted = _mainCam.ScreenToWorldPoint(mousePos);

        pointsForDraw.Add(converted);
        pointsForEdge.Add(converted);

        _lineRenderer.positionCount = pointsForDraw.Count;
        _lineRenderer.SetPositions(pointsForDraw.ToArray());

        _edgeCollider2D.points = pointsForEdge.ToArray();
    }
}
