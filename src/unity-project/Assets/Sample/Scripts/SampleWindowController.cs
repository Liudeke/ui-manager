﻿using UnityEngine;
using UserInterface;

namespace Sample.Scripts
{
    public class SampleWindowController : MonoBehaviour
    {
        private SampleWindow sampleWindow;

        private void Awake()
        {
            sampleWindow = UiManager.GetInstance().Add<SampleWindow>();
            sampleWindow.Show();
        }

        private void Start()
        {
            SubscribeToFadeAnimationEvents();
        }

        private void SubscribeToFadeAnimationEvents()
        {
            var uiFadeAnimation = sampleWindow.GetComponent<UiFadeAnimation>();
            uiFadeAnimation.FadeInCompeleted += OnFadeInCompeleted;
            uiFadeAnimation.FadeOutCompeleted += OnFadeOutCompeleted;
        }

        private void UnsubscribeFromFadeAnimationEvents()
        {
            var uiFadeAnimation = sampleWindow.GetComponent<UiFadeAnimation>();
            uiFadeAnimation.FadeInCompeleted -= OnFadeInCompeleted;
            uiFadeAnimation.FadeOutCompeleted -= OnFadeOutCompeleted;
        }

        private void OnFadeInCompeleted()
        {
            sampleWindow.Hide();
        }

        private void OnFadeOutCompeleted()
        {
            UnsubscribeFromFadeAnimationEvents();

            UiManager.GetInstance().Remove(sampleWindow);

            Destroy(gameObject);
        }
    }
}