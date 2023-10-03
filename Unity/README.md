<div align="center">

# Pong

</div>

<!-- ![Pong](https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Pong1.gif?raw=true "Title") -->

<p align="center">
  <!-- <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Pong1.gif?raw=true" width="350" title="Pong"> -->
</p>

Pong is one of the first computer games that ever created, this simple "tennis like" game features two paddles and a ball, the goal is to defeat your opponent by being the first one to gain 10 point, a player gets a point once the opponent misses a ball. Pong became a huge success, and became the first commercially successful game, on 1975, Atari release a home edition of Pong (the first version was played on Arcade machines) which sold 150,000 units. 

Today, the Pong Game is considered to be the game which started the video games industry, as it proved that the video games market can produce significant revenues.

[More About Pong Game...](https://www.ponggame.org/)


<div align="center">

# Creating Process

</div>


## Template
 - The very first step is setting the template properly, 2D Core must be selected.

## Graphics Elements
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Elements.png?raw=true" width="900" title="Pong">
</p>

- The great majority of the grapichs elements are created selecting 2D Object -> Sprites -> Square.
- However the counters are created different, UI -> Text TextMeshPro
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/ElementsList.png?raw=true" height="250" title="Pong">
</p>


## BoxCollider2D
- It is necessary to detect collisions between two elements. For that pourpuse we have Colliders. Every grapich element must have a ***BoxCollider2D*** inside the Inspector window, except for the ***LineaCentral*** element, which is only visual.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxCollider.png?raw=true" height="250" title="Pong">
</p>

- Without the colliders, the ball, for example, could go through the wall without bouncing. However we can set up the vertical walls or goals as triggers, it means that a specific action will be performed when the ball hit them.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxColliderGol.png?raw=true" height="250" title="Pong">
</p>


##  RigidBody
- Rigidbodies enable your GameObjects to act under the control of physics. The Rigidbody can receive forces and torque to make your objects move in a realistic way. Any GameObject must contain a Rigidbody to be influenced by gravity, act under added forces via scripting, or interact with other objects through the NVIDIA PhysX physics engine.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/RigidBodyBola.png?raw=true" height="250" title="Pong">
</p>

- The only elements with a **RigidBody 2D** are **Pala1**, **Pala2** and **Bola**








##### Feel free to download or fork this repo and explore the files and undertstand how I made this project.

