using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    #region Tags

    public const string Obstacle_TagName = "Obstacle";

    public const string StackableBlock_TagName = "Stackable block";

    public const string TopObstacle_TagName = "Top obstacle";

    public const string BonusBlock_TagName = "Bonus block";

    public const string EndStep_TagName = "End step";

    public const string Gem_TagName = "Gem";

    public const string Pod_TagName = "Pod";

    #endregion


    #region Animation

    public const string Start_CameraState = "Start camera";
    public const string Follow_CameraState = "Follow camera";
    public const string End_CameraState = "End camera";

    #endregion

    public const string GemCount_PlayerPrefs = "Gem count";

    public const string GemGrabbed_AnimationTrigger = "Grabbed";

    public const string AstronautIdle_AnimationTrigger = "Idle";

    public const string AstronautRun_AnimationTrigger = "Run";
}
