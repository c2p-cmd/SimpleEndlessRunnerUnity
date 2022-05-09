using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public GameObject effect;
    private static readonly int Shake = Animator.StringToHash("shake");

    private void Update () {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Player"))
            return;
        other.GetComponent<Player>().health--;
        other.GetComponent<Player>().camAnim.SetTrigger(Shake);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
