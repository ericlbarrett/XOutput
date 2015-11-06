XOutput is a simple DirectInput to XInput wrapper made in C#. It uses the SCPDriver as a backend.

#Building

XOutput can be built in Visual Studio 2013+. It depends on the SlimDX developer SDK which can be found [here](http://slimdx.org/)

#How to Set Up

1. Download and install the official Xbox 360 Controller driver [here](http://www.microsoft.com/hardware/en-us/d/xbox-360-controller-for-windows)
2. Run ScpDriver.exe
3. Click install, wait until it finishes to close it
4. Press the windows key and type in joy.cpl, in this program press properties to view your controllers keymap
5. Run XOutput and set up your controller with the mappings from joy.cpl
6. Click "Start"
