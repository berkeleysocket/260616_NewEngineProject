using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Core.EventChannels.SO
{
    [CreateAssetMenu(fileName = "GameEventChannel", menuName = "SO/Utilities/EventChannelSO")]
    public class EventChannelSO : ScriptableObject
    {
        private Dictionary<Type, Action<ChannelEvent>> _events = new();
        private Dictionary<Delegate, Action<ChannelEvent>> _lookUp = new();

        public void AddListener<T>(Action<T> handler) where T : ChannelEvent
        {
            if (_lookUp.ContainsKey(handler)) return;

            Action<ChannelEvent> castHandler = (evt) => handler(evt as T);
            _lookUp[handler] = castHandler;
            Type eventType = typeof(T);
            if (_events.ContainsKey(eventType))
            {
                _events[eventType] += castHandler;
            }
            else
            {
                _events[eventType] = castHandler;
            }
        }

        public void RemoveListener<T>(Action<T> handler) where T : ChannelEvent
        {
            Type evtType = typeof(T);
            if (_lookUp.TryGetValue(handler, out Action<ChannelEvent> castHandler))
            {
                if (_events.TryGetValue(evtType, out Action<ChannelEvent> internalHandler))
                {
                    internalHandler -= castHandler;
                    if (internalHandler == null)
                        _events.Remove(evtType);
                    else
                        _events[evtType] = internalHandler;
                }
                _lookUp.Remove(handler);
            }
        }

        public void RaiseEvent(ChannelEvent evt)
        {
            if (_events.TryGetValue(evt.GetType(), out Action<ChannelEvent> castHandler))
            {
                castHandler?.Invoke(evt);
            }
        }

        public void Clear()
        {
            _events.Clear();
            _lookUp.Clear();
        }
    }
}
