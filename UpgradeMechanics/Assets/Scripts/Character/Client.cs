using System;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Client : MonoBehaviour
    {
        public List<SubscriberA> subscribersA;
        public List<SubscriberB> subscribersB;
        public Publisher publisher;

        private void Awake()
        {
            foreach (var subscriberA in subscribersA)
            {
                subscriberA.Subscribe(publisher);
            }

            foreach (var subscriberB in subscribersB)
            {
                subscriberB.Subscribe(publisher);
            }
        }
    }
}