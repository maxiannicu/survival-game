using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private Period _currentPeriod;
    private float _animationDelta;
    private bool _animationRunning;

    // Use this for initialization
    void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        _currentPeriod = PeriodController.CurrentPeriod;
        _animationDelta = 0;
        _animationRunning = false;
        _spriteRender.color = new Color(_spriteRender.color.r, _spriteRender.color.g, _spriteRender.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPeriod != PeriodController.CurrentPeriod)
        {
            _animationRunning = true;
            _currentPeriod = PeriodController.CurrentPeriod;
        }

        if (_animationRunning)
        {
            _animationDelta += Time.deltaTime;
            var progress = (1.0f * Mathf.Min(Constants.Animation.PeriodSwitch, _animationDelta) / Constants.Animation.PeriodSwitch);
            if (_currentPeriod == Period.Day)
                progress = 1 - progress;


            _spriteRender.color = new Color(_spriteRender.color.r, _spriteRender.color.g, _spriteRender.color.b, progress);

            if (_animationDelta >= Constants.Animation.PeriodSwitch)
            {
                _animationRunning = false;
                _animationDelta = 0;
            }
        }
    }
}
