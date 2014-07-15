using System;

namespace Pony
{
    public class Route
    {
        public static Action<TController> Execute<TController>(Action<TController> action) where TController : WinFormsController
        {
            return action;
        }
    }
}
