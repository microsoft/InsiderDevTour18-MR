
# Build Windows Mixed Reality Apps

## Prerequisites:
- Windows 10 April 2018 Update
- Visual Studio 2017 (15.7.1 or higher) (Community works great)
- Universal Windows Platform development workload with Windows 10 SDK (10.0.17134.0)
- [Unity](https://unity3d.com/unity/qa/lts-releases?version=2017.4)

## Pre-Demo Setup:
-	Start Unity and open the Demo project 
-	Plug your headset in and make sure it is setup for your demo space using the Mixed Reality Portal
-	Make sure your controllers work in the Mixed Reailty Portal, then turn them off
-	Open the Demo 1 End scene from the Scenes folder in the Project panel and run in the Unity editor by pressing the Play button in the top center of Unity
-	Confirm the floor is in a natural location and everything looks ok. If not, the best thing to do is run Setup in the Mixed Reality Portal again and re-run in Unity
-	Open the Demo Start scene from the Scenes folder in the Project panel and don’t save changes from the previous scene
-	Click the Game tab next to the Scene tab, make sure the Maximize On Play button is on, this will maximize the 3D view on screen when we show the scene in the headset. Select the Scene tab again so this tab is displayed

## Demo 1: Get Started
### Unity Overview
-	For newcomers to Unity explain a couple of the main panels so they can follow along better during the demos. 
-	Introduce the Project panel, this panel set of folders that contains all of the 3D assets, scripts, and toolkit packages available to use in the project. For the most part we will just drag and drop from here
-	Introduce the Hierarchy panel, this is a list view of all the objects for an individual scene in our app
-	Introduce the Scene view, this is 3D view into our scene, to start with it is empty, hold down the right mouse button to move the view a little bit in the scene
-	Introduce the Inspector panel, this is where details and components for selected scene objects can be manipulated
### Exporting to Visual Studio
-	Before we build a scene let’s make sure the project is properly setup to export as a UWP solution and support Windows Mixed Reality
-	From the File menu select Build Settings
-	Unity supports many different platforms, make sure that the Universal Windows Platform is the selected platform
-	Click the Player Settings button, this will open the PlayerSettings in the Inspector panel.
-	Expand the XR Settings section, make sure the Virtual Reality Supported checkbox is checked, this is the most important part besides UWP being the selected platform
-	Second expand the Publishing Settings and scroll to the bottom where the capabilities are, note this is where we assign certain capabilities for the app, make sure Microphone is checked
-	To actually kick off an export, go back to the Build Settings window, click the Build button
-	Unity will ask for you to select or create an output folder, by selecting a folder an export is kicked off, DO NOT pick a folder, just mention this is the last step and the result will be a VS solution you can then create a Microsoft Store package with. Hit Cancel and then close the Build Settings window too
### Building the Scene
-	Now we are ready add some objects to our scene, we have prepared a living room prefab. 
-	Prefab are reusable components inside Unity that we can easily drag into our scene.
-	In the Project panel expand the 3D Models/Prefabs folder, drag the RoomPrefab into the Hierarchy panel
-	Move around a little in the Scene view to show off the room, you can use the mouse wheel to zoom in and out
-	Now we have some beautiful scenery to look at so the next part we need to make sure we setup properly for Windows Mixed Reality is the camera. 
-	Every scene has a camera, this represents the users view in Mixed Reality. When we checked the Virtual Reality box this tells Unity to take over the camera positioning for us. So we want to make sure the camera position is set to 0,0,0. Click on the Main Camera in the Hierarchy panel and confirm that the position is set to 0,0,0 in the Inspector panel
-	The Unity default camera will work fine with virtual reality scenarios, however there are some more feature-rich camera prefabs available in the Mixed Reality Toolkit that we want to take advantage of
-	Remove the default camera from the Hierarchy panel by right clicking on Main Camera and selecting Delete
-	In the Project panel expand the HoloToolkit/Input/Prefabs folder, drag the MixedRealityCameraParent prefab into the Hierarchy panel
-	Expand the MixedRealityCameraParent in the Hierarchy panel, click MixedRealityCamera, in the Inspector panel scroll to the bottom and note that this camera is setup to handle both VR (Opaque Display Settings) and AR/HoloLens (Transparent Display Settings). The black background for transparent display settings is critical for HoloLens because black is considered transparent and is not rendered in the device
-	With our MixedRealityCameraParent we need to make sure a few things are setup before we test our scene
-	In the Hierarchy panel select Boundary, then in the Inspector panel make sure the Opaque Tracking Space Type is set to Stationary. Note that we just talked about space types in the session, we will setup our scene to be stationary because we will not be walking around during this demo
-	Second, we need to tell the camera where the floor is in the room. Note there is a Floor Quad property in the Inspector panel for Boundary
-	Expand the RoomPrefab object in the Hierarchy panel, scroll down to the Floor object of the room, drag and drop the Floor object into the slot in the Inspector panel for Floor Quad
-	[HEADSET ON]
-	Now we are all set to run our scene for the first time in Unity, click Play at the top and put on your headset, once the room displays look around and note some of the objects in the room. Mention the Lamp on the table in front of you, the wood coaster on the same table and the drone sitting on the coffee table behind you. We will do more with these objects further along in the session
-	[HEADSET OFF and click Play to exit play mode]

## Demo 2: Gaze
-	To implement gaze in our scene we can take advantage of more prefabs provided by the Mixed Reality Toolkit
-	In the Project panel expand the HoloToolkit/Input/Prefabs folder, drag the InputManager prefab into the Hierarchy panel
-	Click the InputManager in the Hierarchy panel to show the details of it in the Inspector panel. Note that this prefab is simply a collection of scripts that contain the necessary logic to track the user’s gaze via the headset position and also handle displaying the cursor in the proper position within the scene
-	So the next thing we need to add is a cursor to our scene for the InputManager. Expand the Cursor folder in the HoloToolkit/Input/Prefabs folder. Drag the Cursor prefab (blue circle) into the Hierarchy panel
-	Explain that this cursor contains to states, an on and an off state. The cursor is rendered as on when it gaze of the user interacts with a 3D object that contains a physics collider with it. For 3D objects in the room without physics colliders, then cursor won’t be drawn when we gaze at them
-	[HEADSET ON]
-	So with two additional prefabs we are able to add gaze to our scene, no coding needed
-	Press Play to run the scene with Gaze in the Unity editor. Show that as we gaze at the floor, lamp, and the table with the lamp on it that the cursor is rendered. As we look at the couch or other objects around the room the cursor is not rendered. This is one type of cursor, there are a few other types that are available in the toolkit.
-	[HEADSET OFF and click Play to exit play mode]

## Demo 3: Controllers
### Visualizing Controllers
-	[TURN ON AT LEAST ONE CONTROLLER]
-	Like with gaze, we can take advantage of the toolkit again for controllers. The MixedRealityCameraParent has built in support for visualizing controllers in our scene
-	Expand the MixedRealityCameraParent object in the Hierarchy panel and select the MotionControllers object. 
-	In the Inspector panel show that this object contains a script to visualize controllers within our scene. 
-	[HEADSET ON]
-	So without any additional work for us we can use our controller(s) in our scene. Show the audience that you controller is on now and press Play to enter into the scene in your headset
-	In the scene show how the controller is displayed for us. This model is actually pulled from the operating system drivers for mixed reality.
-	Demonsrate the other build in functionality we have, first is teleporting. To teleport push up on the controller thumbstick and use gaze to set the spot to teleport to. Release the thumbstick.
-	Flick the thumbstick to the right or left. This turns the camera without needing to turn our head. This is useful if we need to turn 180 degrees to view something in the scene
-	Also note that the cursor will continue to match our gaze until we actually click the trigger on the controller. Once we click the trigger on the controller the cursor is then assigned to follow the controller’s pointer targeting. Use the controller to point to the lamp and table
-	[HEADSET OFF and click Play to exit play mode]

### Controller Interaction
-	Now let’s add some interaction with the controllers into our scene. This does require some coding. In Unity we write C# scripts to add logic to our scene. We have prepared a few scripts that enable some simple interactions with some objects on our room
-	Click the Scripts folder in the Project panel, note there are a few scripts here.
-	In the Hierarchy panel expand the RoomPrefab and locate the Lamp object near the top, click the Lamp object to view its properties in the Inspector panel
-	To assign the script logic to the Lamp we drag our script in to the Inspector panel. Drag the LampClick script from the Project panel into the Inspector panel for the Lamp 
-	This script requires us to define what object the Lamp should turn off and on. Expand the Lamp object in the Hierarchy and then expand the Sphere object and note the LampLight, don’t click it. The LampLight is currently off. Drag the LampLight into the Toggle This slot for the LampClick script in the Inspector panel
-	Locate the DroneTarget object just above the Lamp object inside the RoomPrefab in the Hierarchy panel. Click the DroneTarget
-	This object is meant as a target landing spot for our drone in the scene. To have the drone fly to this object we need to attach a script to it. Drag the FlyDrone script into the Inspector panel for the DroneTarget object
-	This script also requires us to define what object should fly to this location. From the Hierarchy panel, drag the Drone object into the Flying Object slot for the Fly Drone script in the Inspector panel
-	Now we are set to interact with these two objects, the Lamp and the Drone landing target. Both of these scripts simple listen for click events passed by the toolkit. When a click occurs with the cursor on these objects then the logic in these scripts is executed.
-	[HEADSET ON]
-	Press Play and make sure the controller is on. Click the controller trigger to take over the cursor with the controller
-	Point at the Lamp and click the controller, the light should turn on. Click a few more times to turn off and on again.
-	Look behind you at the coffee table, and note that the drone sitting there has been programmed to fly to the target if we click on the target. Look back at the DroneTarget on the lamp table and point and click the controller trigger. 
-	Turn around and watch the drone fly to this target.
-	Now we have added controllers and interaction to our scene. The toolkit has provided a lot of code free features and with a little bit of code we have added specific interactions into our scene
-	[HEADSET OFF and click Play to exit play mode]

## Demo 4: HoloLens

-------------------------------------------
This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
