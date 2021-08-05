using System;
using Disjointed.Audio;
using UnityEngine;
using Disjointed.Tools.Extensions;
using Sprite = Disjointed.Sprites.Sprite;


namespace Disjointed.Environment
{
    public class Door : Sprite, IUnlockable
    {
        [Serializable] public class Data
        {
            public bool open;
            public bool locked;
        }

        public Data data;
        public LayerMask playerMask;
        
        new private Collider2D collider;
        
        override protected void Awake()
        {
            base.Awake();

            SetAnimationState("Open", data.open);
            collider = GetComponent<Collider2D>();
        }

        public void Lock()
        {
            data.locked = true;
            AudioManager.Connect.PlayOneShot("Lock");
        }

        public void Unlock()
        {
            data.locked = false;
            AudioManager.Connect.PlayOneShot("Unlock");
        }

        public void ToggleLock()
        {
            data.locked = !data.locked;
            AudioManager.Connect.PlayOneShot("Lock");
        }

        public void Open()
        {
            if (data.locked) return;
            
            data.open = true;
            collider.isTrigger = true;
            AudioManager.Connect.PlayOneShot("WoodenDoorOpen");
            SetAnimationState("Open", data.open);
        }

        public void Close()
        {
            data.open = false;
            collider.isTrigger = false;
            AudioManager.Connect.PlayOneShot("WoodenDoorClose");
            SetAnimationState("Open", data.open);
        }

        public void ToggleOpen()
        {
            data.open = !data.open;
            collider.isTrigger = !collider.isTrigger;
            AudioManager.Connect.PlayOneShot("WoodenDoorOpen");
            SetAnimationState("Open", data.open);
        }
    

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!playerMask.Contains(other.gameObject.layer)) return;

            if (!data.locked && !data.open) Open();
        }
    }
}
