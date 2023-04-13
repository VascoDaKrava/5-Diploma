using UnityEngine;


namespace RTDef.Game.Animations
{
    public static class AnimationParams
    {

        #region Properties

        /// <summary>
        /// Value 0 : 1
        /// </summary>
        public static int VELOCITY_FORWARD => Animator.StringToHash("VelocityForward");

        /// <summary>
        /// Value -1 (right) : 1 (left)
        /// </summary>
        public static int ROTATION => Animator.StringToHash("Rotation");

        #endregion

    }
}