using System;

namespace DominoGame
{
    public static class Factory
    {
        public static T CreateInstance<T>(params object[] args) where T : class
        {
            var ttype = typeof (T);
            var obj = (T) Activator.CreateInstance(ttype, args);
            return obj;
        }
    }
}