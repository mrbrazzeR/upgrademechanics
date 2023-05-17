using UnityEngine;

namespace Character
{
    public class SubscriberB:MonoBehaviour
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
            Debug.Log("data x2 is " + data*2);
        }
    }
}