### Installation Instructions:

Install Unity Hub, if not installed.  (This helps to manage version number and install/edit the features installed in the application).

https://unity3d.com/get-unity/download

In the Installs tab of Unity Hub, add a new installation.  Install version 2019.2.12f1.  include build support for your operating system in the install. Support for other builds can be added later or now if you would like but shouldn't be needed for this particular project.

Wait for install.

Clone the Github repository.

On the projects tab in Unity Hub, go to add, then navigate to the project folder on your drive (This is the folder that contains the Assets, Library, Logs, etc. folders and the sln file).  Provided you have installed unity version 2019.2.12f1 there should be no error in opening the project.

### Project Instructions:

On opening the project there are really only two scripts that will control the rendering of the fractal.  There is a script on the camera object, CameraCompute.cs, that calls the compute shader, Raymarcher.compute, and the compute shader itself. Other scripts may be added to allow for user control of the parameters passed to the compute shader.

### Other Sources:

For a tutorial on how this was setup (and just a cool tutorial) see:
http://blog.three-eyed-games.com/2018/05/03/gpu-ray-tracing-in-unity-part-1/

This tutorial is great as it shows how to pass variables to a compute shader.


For an overview of Unity and the interface see:
https://learn.unity.com