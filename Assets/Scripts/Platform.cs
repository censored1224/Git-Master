using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _downCheck;
    [SerializeField] private Transform _upCheck;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speedPlatform;
    [SerializeField] private float _rayLiane;

    private bool _wallCheck;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 

    }


    private void FixedUpdate()
    {
        _wallCheck = WallCheck();


        if (_wallCheck)
        {
            _speedPlatform *= -1;
        }

        _rigidbody2D.velocity = new Vector2(0, _speedPlatform * Time.fixedDeltaTime);

        /*Movement move = new Movement();

        if((move.CountFplip() % 2) == 0 && move.CountFplip() != 0) 

        {|
            _speedPlatform += 200 * Time.fixedDeltaTime;
        }*/


    }


    private bool WallCheck()
    {
        RaycastHit2D downCheck = Physics2D.Raycast(_downCheck.position, Vector2.down, _rayLiane);
        RaycastHit2D upCheck = Physics2D.Raycast(_upCheck.position, Vector2.up, _rayLiane);

        if(downCheck.collider != null || upCheck.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
