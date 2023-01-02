using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _brokenPiece;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    private bool _isBroken = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Gun")) return;
        if (_isBroken) return;

        if (collision.relativeVelocity.magnitude >= _breakForce)
        {
            _isBroken = true;
            var brokenPiece = Instantiate(_brokenPiece, transform.position, transform.rotation);

            var thisRend = GetComponent<Renderer>();
            var rends = brokenPiece.GetComponentsInChildren<Renderer>();
            foreach (var rend in rends) rend.material = thisRend.material;

            var rbs = brokenPiece.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier, collision.contacts[0].point, 2);

            Destroy(this.gameObject);
        }
    }
}
