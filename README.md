# Unity Crosshair Demo
A world-space crosshair system for unity 5.

## Usage
Add the crosshair prefab to your scene.
You can respond to 3 events: `OnCrosshairExit`, `OnCrosshairEnter` and `OnCrosshairClick`

It has both Dynamic and Fixed modes. Dynamic will move to position the crosshair in front of objects, and Fixed will stay a fixed distance from the camera.

There is a demo scene in the Scenes folder demonstrating how to use the system. For an exmaple script that uses all the messages, see the `BoxDropper.cs` file in `Scripts/GameObjects`.

Happy Coding!
