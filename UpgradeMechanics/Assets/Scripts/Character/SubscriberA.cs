using UnityEngine;

namespace Character
{
    public class SubscriberA : MonoBehaviour
    {
        public void Subscribe(Publisher publisher)
        {
            publisher.Publish += OnNotifyReceived;
        }

        public void UnSubscribe(Publisher publisher)
        {
            publisher.Publish += OnNotifyReceived;
        }
        private void OnNotifyReceived(int data)
        {
            Debug.Log("data is " + data);
        }
    }
}