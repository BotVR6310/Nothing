using System.Collections;
using UnityEngine;
using GorillaExtensions;
using System;

namespace Nothing
{
    public class oddbutton : GorillaPressableButton
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider is null)
            {
                throw new ArgumentNullException(nameof(collider));
            }

            Press();
        }

        public void Press()
        {
            UnityEngine.Debug.Log("Button Pressed");
            GetComponent<AudioSource>().Play();
            //cube.GetComponent<AudioSource>().Play();
            UnityEngine.Debug.Log("Button Pressed");
        }
        //void OnTriggerEnter<cube>(Collider collider) <-- this crashes your game
        //button button = collider.GetComponent<button>();
        //var cube = new Plugin();
        //cube.GetComponent<AudioSource>().Play();
        //UnityEngine.Debug.Log("button");
    }
}
