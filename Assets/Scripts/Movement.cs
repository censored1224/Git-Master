using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _forwardSeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;

    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private TextMeshProUGUI _best;

    private static int _countFlip;

    private bool _looksRight;

    public int CountFplip()
    {
        return _countFlip;
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
        _rigidbody2D.velocity = new Vector2(_forwardSeed  * Time.fixedDeltaTime, _rigidbody2D.velocity.y - _gravity * Time.fixedDeltaTime);
    }
    
    private void Flip()
    {
        _countFlip++;
        _looksRight = !_looksRight;
        _forwardSeed *= -1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.collider.CompareTag("Platform"))
        {
           Flip();
        }
    }
}
