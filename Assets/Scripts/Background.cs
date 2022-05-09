using UnityEngine;

public class Background : MonoBehaviour {
    [SerializeField] public float speed;
    [SerializeField] public float Xend;
    [SerializeField] public float Xstart;

    private void Update() {
        var myTransform = transform;
        
        myTransform.Translate(Vector3.left * (speed * Time.deltaTime));
        
        if (!(transform.position.x < Xend))
            return;
        
        var pos = new Vector3(Xstart, myTransform.position.y);
        myTransform.position = pos;
    }
}
