namespace Runtime.Source.Tools.CameraShaker.Enums
{
    // Based on plugin 'MilkShake Camera Shaker' 
    // Link to the Asset store page: https://assetstore.unity.com/packages/tools/camera/milkshake-camera-shaker-165604
    // Great thanks!
    
    /// <summary>
    /// Represents the current state of a shake.
    /// </summary>
    public enum ShakeState
    {
        /// <summary>
        /// The shake is starting / fading in.
        /// </summary>
        FadingIn = 0,

        /// <summary>
        /// The shake has reached its full strength and is now constant.
        /// </summary>
        Sustained = 1,

        /// <summary>
        /// The shake is stopping / fading out.
        /// </summary>
        FadingOut = 2,

        /// <summary>
        /// The shake has fully stopped.
        /// </summary>
        Stopped = 3
    }
}