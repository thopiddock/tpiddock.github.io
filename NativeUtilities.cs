using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

/// <summary>
/// The native methods utilities class.
/// </summary>
public static class NativeUtilities
{
  /* 
  /// <summary>
  /// The window show style enumerator.
  /// </summary>
  public enum WindowShowStyle : uint
  {
      /// <summary>
      /// Hide
      /// </summary>
      Hide = 0,
      ShowNormal = 1,
      ShowMinimized = 2,
      ShowMaximized = 3,
      Maximize = 3,
      ShowNormalNoActivate = 4,
      Show = 5,
      Minimize = 6,
      ShowMinNoActivate = 7,
      ShowNoActivate = 8,
      Restore = 9,
      ShowDefault = 10,
      ForceMinimized = 11
  }
*/

  /// <summary>
  /// The window style.
  /// </summary>
  public const int GWL_STYLE = -16;

  /// <summary>
  /// Don't display critical errors. 
  /// </summary>
  public const uint SEM_FAILCRITICALERRORS = 0x0001;

  /// <summary>
  /// Don't display Windows Error-Reporting message box.
  /// </summary>
  public const uint SEM_NOGPFAULTERRORBOX = 0x0002;

  /// <summary>
  /// Recalculate the size and position of the windows client area.
  /// </summary>
  public const uint SWP_FRAMECHANGED = 0x0020; // The frame changed: send WM_NCCALCSIZE

  /// <summary>
  /// No z order on window.
  /// </summary>
  public const uint SWP_ASYNCWINDOWPOS = 0x4000;

  /// <summary>
  /// No z order on window.
  /// </summary>
  public const uint SWP_NOZORDER = 0x0004;

  /// <summary>
  /// Do not activate the window upon reattaching the process.
  /// </summary>
  public const uint SWP_NOACTIVATE = 0x0010;

  /// <summary>
  /// The specified window has a title bar.
  /// </summary>
  public const uint WS_CAPTION = 0x00C00000;

  /// <summary>
  /// Creates a window with a resizable frame.
  /// </summary>
  public const uint WS_THICKFRAME = 0x00040000;

  /// <summary>
  /// Set window position.
  /// </summary>
  /// <param name="hWnd">
  /// </param>
  /// <param name="hWndInsertAfter">
  /// </param>
  /// <param name="X">
  /// </param>
  /// <param name="Y">
  /// </param>
  /// <param name="cx">
  /// </param>
  /// <param name="cy">
  /// </param>
  /// <param name="uFlags">
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool SetWindowPos(
      IntPtr hWnd, 
      IntPtr hWndInsertAfter, 
      int X, 
      int Y, 
      int cx, 
      int cy, 
      uint uFlags);

  /// <summary>
  /// Set window handle.
  /// </summary>
  /// <param name="hWnd">
  /// </param>
  /// <param name="nIndex">
  /// </param>
  /// <param name="dwNewLong">
  /// </param>
  /// <returns>
  /// The <see cref="int"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

  /// <summary>
  /// Get window handle.
  /// </summary>
  /// <param name="hWnd">
  /// </param>
  /// <param name="nIndex">
  /// </param>
  /// <returns>
  /// The <see cref="int"/>.
  /// </returns>
  [DllImport("user32.dll", SetLastError = true)]
  public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

  /// <summary>
  /// Find the window ex.
  /// </summary>
  /// <param name="parentHandle">
  /// </param>
  /// <param name="childAfter">
  /// </param>
  /// <param name="lclassName">
  /// </param>
  /// <param name="windowTitle">
  /// </param>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern IntPtr FindWindowEx(
      IntPtr parentHandle, 
      IntPtr childAfter, 
      string lclassName, 
      string windowTitle);

  /// <summary>
  /// The set error mode.
  /// </summary>
  /// <param name="uMode">
  /// The u mode.
  /// </param>
  /// <returns>
  /// The <see cref="uint"/>.
  /// </returns>
  [DllImport("kernel32.dll")]
  public static extern uint SetErrorMode(uint uMode);

  /// <summary>
  /// The enable window.
  /// </summary>
  /// <param name="hwnd">
  /// The hwnd.
  /// </param>
  /// <param name="enable">
  /// The enable.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool EnableWindow(IntPtr hwnd, bool enable);

  /// <summary>
  /// The set foreground window.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool SetForegroundWindow(IntPtr hWnd);

  /// <summary>
  /// The show cursor.
  /// </summary>
  /// <param name="bShow">
  /// The b show.
  /// </param>
  /// <returns>
  /// The <see cref="int"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern int ShowCursor(bool bShow);

  /// <summary>
  /// The get current thread id.
  /// </summary>
  /// <returns>
  /// The <see cref="int"/>.
  /// </returns>
  [DllImport("kernel32.dll")]
  public static extern int GetCurrentThreadId();

  /// <summary>
  /// The attach thread input.
  /// </summary>
  /// <param name="idAttach">
  /// The id attach.
  /// </param>
  /// <param name="idAtttachTo">
  /// The id atttach to.
  /// </param>
  /// <param name="fAttach">
  /// The f attach.
  /// </param>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAtttachTo, int fAttach);

  /// <summary>
  /// The get window thread process id.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <param name="ProcessId">
  /// The process id.
  /// </param>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

  /// <summary>
  /// The set parent.
  /// </summary>
  /// <param name="hWndChild">
  /// The h wnd child.
  /// </param>
  /// <param name="hWndNewParent">
  /// The h wnd new parent.
  /// </param>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

  /// <summary>
  /// The show window.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <param name="nCmdShow">
  /// The n cmd show.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

  /// <summary>
  /// The get foreground window.
  /// </summary>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern IntPtr GetForegroundWindow();

  /// <summary>
  /// The get window text.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <param name="text">
  /// The text.
  /// </param>
  /// <param name="count">
  /// The count.
  /// </param>
  /// <returns>
  /// The <see cref="int"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

  /// <summary>
  /// The find window.
  /// </summary>
  /// <param name="strClassName">
  /// The str class name.
  /// </param>
  /// <param name="strWindowName">
  /// The str window name.
  /// </param>
  /// <returns>
  /// The <see cref="IntPtr"/>.
  /// </returns>
  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern IntPtr FindWindow(string strClassName, string strWindowName);

  /// <summary>
  /// The get window rect.
  /// </summary>
  /// <param name="hwnd">
  /// The hwnd.
  /// </param>
  /// <param name="rectangle">
  /// The rectangle.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

  /// <summary>
  /// The attach thread input.
  /// </summary>
  /// <param name="idAttach">
  /// The id attach.
  /// </param>
  /// <param name="idAttachTo">
  /// The id attach to.
  /// </param>
  /// <param name="fAttach">
  /// The f attach.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll")]
  public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

  /// <summary>
  /// The bring window to top.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool BringWindowToTop(IntPtr hWnd);

  /// <summary>
  /// The bring window to top.
  /// </summary>
  /// <param name="hWnd">
  /// The h wnd.
  /// </param>
  /// <returns>
  /// The <see cref="bool"/>.
  /// </returns>
  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool BringWindowToTop(HandleRef hWnd);

  /// <summary>
  /// Force the window to the foreground.
  /// </summary>
  /// <param name="hWnd">
  /// The window handle.
  /// </param>
  public static void ForceForegroundWindow(IntPtr hWnd)
  {
      IntPtr ignored;
      uint foreThread = (uint)GetWindowThreadProcessId(GetForegroundWindow(), out ignored);
      uint appThread = (uint)GetCurrentThreadId();
      const uint SW_SHOW = 5;

      if (foreThread != appThread)
      {
          AttachThreadInput(foreThread, appThread, true);
          BringWindowToTop(hWnd);
          ShowWindow(hWnd, SW_SHOW);
          AttachThreadInput(foreThread, appThread, false);
      }
      else
      {
          BringWindowToTop(hWnd);
          ShowWindow(hWnd, SW_SHOW);
      }
  }
}
