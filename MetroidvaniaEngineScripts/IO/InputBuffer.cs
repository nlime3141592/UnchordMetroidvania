using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnchordMetroidvania
{
    public static class InputBuffer
    {
        public const int bufferCount = 60;

        private static InputData[] c_buffers = new InputData[bufferCount];
        private static int currentFrame = 0;

        internal static void FixedUpdate()
        {
            c_buffers[currentFrame].Copy(InputHandler.data);

            currentFrame++;
            currentFrame %= bufferCount;
        }

        public static InputData GetBufferedData(int backframe)
        {
            int index = (bufferCount + currentFrame - backframe) % bufferCount;
            return c_buffers[index];
        }
    }
}