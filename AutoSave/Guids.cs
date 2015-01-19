// Guids.cs
// MUST match guids.h
using System;

namespace TeisLindemark.AutoSave
{
    static class GuidList
    {
        public const string guidAutoSavePkgString = "9f8f52e8-4776-4b81-a9be-cb5917e97ea6";
        public const string guidAutoSaveCmdSetString = "907d81c6-dfa6-4bd6-b719-2407b2548d34";

        public static readonly Guid guidAutoSaveCmdSet = new Guid(guidAutoSaveCmdSetString);
    };
}