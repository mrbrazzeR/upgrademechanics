using UnityEngine;

public class Publisher : MonoBehaviour
{
    public delegate void Notify(int data);

    public event Notify Publish;

    public void OnPublish(int data)
    {
        Publish?.Invoke(data);
    }
}
