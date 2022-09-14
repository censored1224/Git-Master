using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _forwardSeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;

    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _best;

    private static int _countFlip;


    private bool _looksRight { 
        get;
        set; 
    }


    void Start()
    {
        _looksRight = true;
        _countFlip = 0;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _best.text = "Best : " + PlayerPrefs.GetInt("HightScore", 0).ToString();
    }

    void Update()
    {
        if(_countFlip > PlayerPrefs.GetInt("HightScore", 0))
        {
            PlayerPrefs.SetInt("HightScore", _countFlip);
            _best.text = _countFlip.ToString();
        }

        _countText.text = "" + _countFlip;
        

        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (_looksRight)
        {           
            _rigidbody2D.velocity = new Vector2(_forwardSeed  * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(-_forwardSeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
        }
        
       
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - _gravity * Time.fixedDeltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _countFlip++;
        _looksRight = !_looksRight;
    }
}
