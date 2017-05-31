using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed;
    //[SerializeField]
    //private float _maxAcceleration;

    private CharacterController _controller;
    private Vector3 _prevPosition;
    private Vector3 _nextPosition;
    private Quaternion _prevRotation;
    private Quaternion _nextRotation;
    private float _timeSinceLastFixedUpdate;

    private Vector2 _cursorPos;
    private bool _mouseInputActive;
    
    public Vector3 Velocity { get; set; }

    public RectTransform Crosshair;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _nextPosition = transform.position;
        _nextRotation = transform.rotation;
    }

    public void Update()
    {
        _timeSinceLastFixedUpdate += Time.deltaTime;
        var moveVector = Vector3.Lerp(_prevPosition, _nextPosition, _timeSinceLastFixedUpdate / Time.fixedDeltaTime) - transform.position;
        var rotateTo = Quaternion.Lerp(_prevRotation, _nextRotation, _timeSinceLastFixedUpdate / Time.fixedDeltaTime);
        //Debug.Log(string.Format("Update, {0}, {1}, {2}", Time.deltaTime, moveVector.ToString("G4"), (_nextPosition - transform.position - moveVector).ToString("G4")));
        _controller.Move(moveVector);
        transform.rotation = rotateTo;
        Crosshair.gameObject.SetActive(true);
        if (Input.GetButton("MouseTrigger"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _cursorPos.x += Input.GetAxis("MouseX");
            _cursorPos.y += Input.GetAxis("MouseY");
            _mouseInputActive = true;
            Crosshair.gameObject.SetActive(true);
            var playeroffset = transform.position + new Vector3(0, _controller.height / 2, 0);
            var playeroffsetScreen = Camera.main.WorldToScreenPoint(playeroffset);
            Crosshair.anchoredPosition = _cursorPos + new Vector2(playeroffsetScreen.x, playeroffsetScreen.y);

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _cursorPos.x = 0;
            _cursorPos.y = 0;
            _mouseInputActive = false;
            Crosshair.gameObject.SetActive(false);

        }
    }
    
    public void FixedUpdate()
    {
       
        var moveVector = _nextPosition - transform.position;
        _controller.Move(moveVector);
        transform.rotation = _nextRotation;

        var viewForward = Camera.main.transform.up.SetY(0).normalized;
        var viewRight = Camera.main.transform.right.SetY(0).normalized;
        var moveInput = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("MainX"), 0, Input.GetAxis("MainY")), 1);
        var moveInputSize = moveInput.magnitude;
        Vector3 viewInput;
        float viewInputSize;
        if (!_mouseInputActive)
        {
            viewInput = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("SecondaryX"), 0, Input.GetAxis("SecondaryY")), 1);
        }
        else
        {
            viewInput = Vector3.ClampMagnitude(new Vector3(_cursorPos.x, 0, _cursorPos.y), 1);
        }
        viewInputSize = viewInput.magnitude;
        moveInput = viewRight * moveInput.x + viewForward * moveInput.z;

        var playeroffset = transform.position + new Vector3(0, _controller.height / 2, 0);
        var playeroffsetScreen = Camera.main.WorldToScreenPoint(playeroffset);
        var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(viewInput.x*100, viewInput.z*100, 0) + playeroffsetScreen);
        var orthoCamPos = Camera.main.transform.position.SetX(playeroffset.x);
        //Debug.DrawLine(orthoCamPos, worldPoint);

        var cam2point = (worldPoint - orthoCamPos).normalized;
        float mul = (playeroffset.y - orthoCamPos.y) / cam2point.y;
        worldPoint = orthoCamPos + mul*cam2point;
        //Debug.DrawLine(orthoCamPos, worldPoint, Color.red);


        Velocity = moveInput * _maxSpeed + Vector3.down * 9.81f;

        _prevPosition = transform.position;
        _nextPosition = _prevPosition + Time.fixedDeltaTime * Velocity;
        _prevRotation = transform.rotation;
        if (viewInputSize > 0)
        {
            _nextRotation = Quaternion.LookRotation(worldPoint - transform.position.SetY(worldPoint.y));
        }
        else if (Velocity.SetY(0).sqrMagnitude > 0)
        {
            _nextRotation = Quaternion.LookRotation(Velocity.SetY(0));
        }
        else
        {
            _nextRotation = transform.rotation;
        }
        _timeSinceLastFixedUpdate = 0;
    }
}
