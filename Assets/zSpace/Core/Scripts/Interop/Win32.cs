﻿////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) 2007-2020 zSpace, Inc.  All Rights Reserved.
//
////////////////////////////////////////////////////////////////////////////////

#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !UNITY_EDITOR_OSX

using System;
using System.Runtime.InteropServices;

namespace zSpace.Core.Interop
{
    public static class Win32
    {
        ////////////////////////////////////////////////////////////////////////
        // Public Static Methods
        ////////////////////////////////////////////////////////////////////////

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();
    }
}

#endif // (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !UNITY_EDITOR_OSX
