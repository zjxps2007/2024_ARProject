using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public MeshRenderer _renderer;
    private Rigidbody _rigidbody;
    private RigidbodyConstraints originalConstraints;

    private bool pieceGrabbed;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool xDown, yDown, zDown;

    private float maxVelocity = 10f;
            
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        originalConstraints = _rigidbody.constraints;

        pieceGrabbed = false;
        xDown = false;
        yDown = false;
        zDown = false;

        GameManager.Instance.canMove = true;
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > maxVelocity)
        {
            var v = _rigidbody.velocity;
            _rigidbody.velocity = v.normalized * maxVelocity;
        }

        if (GameManager.Instance.canMove && pieceGrabbed)
        {
            DragPiece();
        }
    }

    private void OnMouseEnter()
    {
        if (GameManager.Instance.canMove && !pieceGrabbed)
        {
            _renderer.material.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (!GameManager.Instance.pieceSelected && GameManager.Instance.canMove)
        {
            pieceGrabbed = true;
            _rigidbody.freezeRotation = true;
            _rigidbody.useGravity = false;
            GameManager.Instance.pieceSelected = true;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    private void OnMouseUp()
    {
        if (pieceGrabbed)
        {
            pieceGrabbed = false;
            _rigidbody.freezeRotation = false;
            _rigidbody.useGravity = true;
            _rigidbody.constraints = originalConstraints;
            GameManager.Instance.pieceSelected = false;
    
        }
    }

    private void DragPiece()
    {

        _rigidbody.Sleep();

        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
        }
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 translatedPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 newPosition = transform.position;

        if (xDown || yDown || zDown)
        {
            if (xDown)
            {
                newPosition.x = translatedPosition.x;
            }
            if (yDown)
            {
                newPosition.y = translatedPosition.y;
            }
            if (zDown)
            {
                newPosition.z = translatedPosition.z;
            }
        }
        else
        {
            newPosition = translatedPosition;
        }
        transform.position = newPosition;
    }
}