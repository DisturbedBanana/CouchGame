using UnityEngine;

public class FlameCylinderMeshGenerator : MonoBehaviour
{
    [Header("Mesh Visual")]
    [SerializeField] private MeshFilter _delimiterMeshFilter;

    private Mesh _mesh;

    [Header("Mesh Generation")]
    [SerializeField] private int _sides = 16;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _height = 2.5f;

    public float Radius {
        get => _radius;
        set => _radius = value;
    }

    private Vector3[] _vertices;
    private Vector2[] _uvs;
    private int[] _triangles;

    [Header("Ground Detection")]
    [SerializeField] private Vector3 _raycastOffset = Vector3.zero;
    [SerializeField] private float _raycastMaxDistance = 1000f;
    [SerializeField] private LayerMask _raycastLayerMask;

    private const int RAYCAST_MAX_RESULTS = 5;
    private RaycastHit[] _raycastResults = new RaycastHit[RAYCAST_MAX_RESULTS];

    private Vector3 _center = Vector3.zero;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _RegenerateMesh();
    }

    public void Init()
    {
        _InitMeshData();
        _ResetScale();
        _ResetYPosition();
        _center = transform.position;
    }

    private void _ResetScale()
    {
        transform.localScale = Vector3.one;
    }

    private void _ResetYPosition()
    {
        Vector3 position = transform.localPosition;
        position.y = 1f;
        transform.localPosition = position;
    }
    
    private void _InitMeshData()
    {
        _vertices = new Vector3[(_sides * 2) + 2];
        _uvs = new Vector2[(_sides * 2) + 2];
        _triangles = new int[_sides * 2 * 3];
        
        _mesh = _delimiterMeshFilter.mesh;
        _mesh.vertices = _vertices;
        _mesh.uv = _uvs;
        _mesh.triangles = _triangles;
        _mesh.RecalculateBounds();
    }

    private void _RegenerateMesh()
    {
        for (int i = 0; i <= _sides; ++i) {
            //vi => vertex index
            int vi = i * 2;

            float radAngle = ((Mathf.PI * 2f) / _sides) * i;
            float s = Mathf.Sin(radAngle);
            float c = Mathf.Cos(radAngle);

            Vector3 pos = new Vector3(c * _radius, 0f, s * _radius);

            Vector3 highestPoint = _FindHighestPointOnGround(pos + _center + _raycastOffset);
            float highestPointY = highestPoint.y;

            _vertices[vi] = new Vector3(pos.x, highestPointY - _center.y, pos.z);
            _vertices[vi + 1] = new Vector3(pos.x, highestPointY + _height - _center.y, pos.z);

            float u = (float)i / _sides;
            _uvs[vi] = new Vector2(u, 0f);
            _uvs[vi + 1] = new Vector2(u, 1f);
        }

        for (int i = 0; i < _sides; ++i) {
            //ti => triangle index
            //vi => vertex index
            int ti = i * 6;
            int vi = i * 2;
            _triangles[ti] = vi + 0;
            _triangles[ti + 1] = vi + 1;
            _triangles[ti + 2] = vi + 2;

            _triangles[ti + 3] = vi + 2;
            _triangles[ti + 4] = vi + 1;
            _triangles[ti + 5] = vi + 3;
        }

        _mesh.vertices = _vertices;
        _mesh.uv = _uvs;
        _mesh.triangles = _triangles;
        _mesh.RecalculateBounds();
    }
    
    private Vector3 _FindHighestPointOnGround(Vector3 position)
    {
        Vector3 highestPoint = new Vector3(0f, 0f, 0f);
        int nbResults = Physics.RaycastNonAlloc(position, Vector3.down, _raycastResults, _raycastMaxDistance, _raycastLayerMask);
        float highestY = -Mathf.Infinity;
        for (int i = 0; i < nbResults; ++i) {
            Vector3 hitPoint = _raycastResults[i].point;
            float y = hitPoint.y;
            if (y > highestY) {
                highestY = y;
                highestPoint = hitPoint;
            }
        }

        return highestPoint;
    }
}