using UnityEngine;

public class BubbleRotation : MonoBehaviour
{
    public Transform bubble;
    public float speed;

    private void Update() => BubbleRotate();

    private void BubbleRotate() => bubble.Rotate(0f, 0f, speed * Time.deltaTime);

}
