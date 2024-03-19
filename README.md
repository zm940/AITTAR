# Week 6 Practical: Prototyping Augmented Reality with Vuforia and Unity

In this week's lecture we saw a range of different approaches for creating augmented reality experiences, which overlay digital content onto the physical world. In this practical, we're going to use a tool called Vuforia within Unity to make some experiences using some of those approaches.

## Task 1: Getting Vuforia Setup in Unity

I've created a template Unity project with some assets that you can use for the practical today already included. To get started, you should create a copy of this repository in your personal GitHub account by pressing the ```Use This Template``` button, and then clone it onto your local machine. Finally, open the ```Sample Scene```.

To use Vuforia AR functionality in Unity we need to add it to our project as a package. There are a few ways to do this, which are described in the tutorial below. I'd reccomend you use the first one ```Add Vuforia Engine to Unity via Editor script```, but you can try the others if you'd prefer.

- https://library.vuforia.com/getting-started/vuforia-engine-package-unity

Next you need to create a license key for your app. You can do this by following the two tutorials below. It’s a bit fiddly, but its worth it trust me!

1. [Create a Vuforia Account](https://developer.vuforia.com/vui/auth/register)
2. [Create a free development license key](https://library.vuforia.com/articles/Training/Vuforia-License-Manager.html)
3. [Add your license key to your app](https://library.vuforia.com/articles/Solution/How-To-add-a-License-Key-to-your-Vuforia-App.html)

Once you’ve done this, you should have an AR-enabled project. You can check if it worked by looking in the ```Game Object``` menu. If there is a new option in the list called ```Vuforia Engine``` then it’s worked.

## Task 2: Your First AR Experience with an Image Target Marker

The most basic Vuforia augmented reality experience we can create comprises:

1. An “ARCamera” object that let’s us look into the scene
2. An “Image” marker that allows us to track the position of a particular image in the real world and overlay it with some virtual content

First up let’s create the camera. To do this, delete the ```MainCamera``` object that’s been created as part of the template scene and replace it with an ```ARCamera```. You can find the ARCamera within the new ```Vuforia Engine``` sub-menu of the ```Game Object``` menu. Once you’ve added your camera, press play and see what happens. You should just see an image from your webcam.

Next let’s make the experience more exciting by adding our first trackable marker. To create an image marker, choose ```Image Target``` from the Vuforia menu.

When you do this you’ll see a new game object in the hierarchy called ```ImageTarget```. This is a game object that will appear in your scene when a particular image is detected by your camera. We can add content like 3D models to this game object, and they'll then appear on top of the image too!

Before this will work though, we need to tell Vuforia which image it should be looking for! Choose one of one of the printed pictures of book covers from the front of the room, which you would like to use an an AR marker. Next, find the corresponding image asset showing your chosen book cover in the ```Practical Assets/Book Covers``` folder.

Once you've done this, follow these instructions to associate that image with your marker:

1. Click on the ```Image Target``` game object
2. In the inspector find the ```Image Target Behavior``` script
3. Choose ```From Image``` from the ```Type``` drop down menu
4. Drag the image asset showing your chosen book cover into the ```Image``` box

To finish the task, add one of Unity's primitive shapes (e.g. a Sphere or a Cube) as a child of the ```ImageTarget``` game object and run the scene. If you hold up your image to the camera, the primitive shape you have added should appear on top of the book cover!

To complete the task, find a 3D model online (e.g. from https://www.turbosquid.com/) that you feel represents the contents of the book. Add this as a child of the ```Image Target``` so that it appears when the book is held up instead of the primitive shape.

## Task 3: Putting it on a Mobile Device

In the remainder of this practical, we're going to be making an AR experience that's designed to work on a mobile device. In this task, let's learn how ot convert our simple Augmented Reality Book Cover expeirnece to run on an Android Tablet. The good news here is that this isn’t difficult to do. All you need to do is:

1. Connect your device with a USB cable
2. Choose Android as the build target (```File > Build Settings```)
3. Click build and run

The experience should work as it did in the Unity editor, but on your tablet instead.

## Task 4: Markerless AR with a Ground Plane

Printed markers are a robust way to position AR content in a scene. However, they have a big drawback. You need a printed marker, which isn't ideal for many mobile use cases. In the lecture, we saw techniques that seek to analyse the physical geometery of the environment in order to find the right position to put AR content, and how these can offer a better solution. In this task, we're going to try something like this out.

Vuforia has a feature called a Ground Plane Stage. This feature basically analyses your image to find a sufficently large horizontal area (e.g. the floor, a table) that the user can choose to have AR content appear on. With a Vuforia ground plane, you can create experiences where:

1. The user points their camera at a flat surface in the room they would like AR conten to appear on
2. Vuforia detects that region and suggests it as a possible ground plane, by showing a small visual indicator on the screen
3. The user presses the screen to confirm that they would like the AR content to appear on that surface
4. The content appears and the AR experience begins!

In this task you should create a simple experience where a basic Unity primitive appears on a Ground Plane. To do this, follow the instructions in the ```Creating your First Ground Plane Experience``` at the following link:

- https://library.vuforia.com/ground-plane/introduction-ground-plane-unity

Your tablet computers are capable of detecting a ground plane. Therefore, you don't need to follow the instructions in the ```Ground Plane Emulator``` section of the guide.

## Task 5: Interacting with AR Content (Paper in Bin!)

To complete the final task, we’re going to create your first AR game. The game should be a homage to the classic paper bin AR game.

https://www.youtube.com/watch?v=2ClIQx6wINQ

It should have the following behaviour: 

1. A bin should be positioned on either an ```Image Target``` or a ```Ground Plane Stage```
2. The player should be able to throw balls into the bin
3. The balls should be thrown by pressing on the touch screen
4. The direction the balls are thrown should depend on the device angle
5. A score counter should be shown on the screen, which keeps track of the number of successful balls scored
5. You can choose what assets you use, or even make your own. However, I've also provided some basic ones in ```Practical Assets/Ball Game```

To help you focus on the AR aspects of this task, I've created a Scene with a Game Object in it (called ```Ball Thrower```) that will thorw balls forward into a scene when you press the screen for you to use (feel free to code your own instead though!). You can find this in ```Practical Assets/Ball Game```. You can also find a prefab of this game object there too, in case you'd like to adapt your previous AR scene rather than work from scratch again (probably a good idea, which will save you some duplicated work).

## Optional Extension: Calling Code When a Marker or Ground Plane is Tracked

You might be wondering whether it's possible to call some code when an image marker or ground plane is tracked. For example, what if you want to disable the ball throwing in the game until the bin appears? The answer is that it's pretty simple to do this with Vuforia.

Take a look at the ```Default Observer Event Handler``` component on either the ```Image Target``` or ```Ground Plane Stage``` game object that was used in your solution to the last task. Can you see anything in this component that might help you call some code when the object is tracked? Thinking back to how we processed input with a graphical user interface in Unity during the MPIE module last year might help you find the solution.





