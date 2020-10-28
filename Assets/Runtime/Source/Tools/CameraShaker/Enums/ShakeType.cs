namespace Runtime.Source.Tools.CameraShaker.Enums
{
    // Based on plugin 'MilkShake Camera Shaker' 
    // Link to the Asset store page: https://assetstore.unity.com/packages/tools/camera/milkshake-camera-shaker-165604
    // Great thanks!
    
    /// <summary>
    /// Defines the behavior of a shake.
    /// </summary>
    public enum ShakeType
    {
        /// <summary>
        /// Will fade in and fade out automatically.
        /// </summary>
        OneShot,

        /// <summary>
        /// Will fade in automatically, but will continue to shake and will not fade out until told to stop.
        /// </summary>
        Sustained
    }
}