using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoApiCalls.Utilities
{
    /**
        <summary> A prevents device from sleeping, going into power saving mode.</summary>
    */

    public static class KeepAwake
    {
        /**
            <summary> A bit-field of flags for specifying execution states.</summary>
        */

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            /** <summary> A binary constant representing the awaymode required flag.</summary> */
            ES_AWAYMODE_REQUIRED = 0x00000040,
            /** <summary> A binary constant representing the continuous flag.</summary> */
            ES_CONTINUOUS = 0x80000000,
            /** <summary> A binary constant representing the display required flag.</summary> */
            ES_DISPLAY_REQUIRED = 0x00000002,
            /** <summary> A binary constant representing the system required flag.</summary> */
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        static bool _alwaysAwake = false;

        /**
            <summary> Sets always awake.</summary>
        
            <param name="alwaysAwake"> True to always awake.</param>
        */

        public static void SetAlwaysAwake(bool alwaysAwake)
        {
            if (alwaysAwake != _alwaysAwake)
            {
                if (alwaysAwake)
                {
                    SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
                }
                else
                {
                    SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
                }

                _alwaysAwake = alwaysAwake;
            }
        }
    }
}
