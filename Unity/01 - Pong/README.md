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

- It is necessary to detect collisions between two elements. For that pourpuse we have Colliders. Every grapich element must have a **_BoxCollider2D_** inside the Inspector window, except for the **_LineaCentral_** element, which is only visual.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxCollider.png?raw=true" height="250" title="Pong">
</p>

- Without the colliders, the ball, for example, could go through the wall without bouncing. However we can set up the vertical walls or goals as triggers, it means that a specific action will be performed when the ball hit them.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxColliderGol.png?raw=true" height="250" title="Pong">
</p>

## RigidBody

- Rigidbodies enable your GameObjects to act under the control of physics. The Rigidbody can receive forces and torque to make your objects move in a realistic way. Any GameObject must contain a Rigidbody to be influenced by gravity, act under added forces via scripting, or interact with other objects through the NVIDIA PhysX physics engine.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/RigidBodyBola.png?raw=true" height="350" title="Pong">
</p>

- The only elements with a **RigidBody 2D** are **Pala1**, **Pala2** and **Bola**. They are not gooing to rotate so is convenient to freeze rotation in Z axis.

- **Pala1** and **Pala2** must be in Kinematic mode. It allows to control their movement based on a script, not phisics.

- The Ball mantains the Dynamic mode but without gravity.

- The RigidBody 2D allow us to set up that the ball will be affected by the impact with **Pala1** and **Pala2**, the result will be the ball bouncing which movement will be based on Phisics.

## The Ball Phisics

<summary><h3></h3></summary>
      
- The default Phisics rules can cause a lost of energy during the impacts, so to change that we can create a **Physics Material 2D** that prevents by modifying the Friction and the Bounciness value.
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PhysicsMaterial.png?raw=true" height="350" title="Pong">
</p>
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PhysicsMaterial2.png?raw=true" height="350" title="Pong">
</p>

- This new rules must be applied to the **Bola** RigidBody by changing the Material
<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/RigidBodyBola.png?raw=true" height="350" title="Pong">
</p>

</details>



## Pala Physics

- The movement of **Pala1** and **Pala2** is determined by the C# Script. This file, as the PhysicMaterial, is created in the Project window.
- The Script is added to the elements just by drag and drop

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    // Using [SerializeField] we can see the it in the Unity inspector
    [SerializeField] private float velocidad = 7f;
    [SerializeField] private bool esPala1;

    // Vertical limit in Y Axis
    private float limiteY = 3.75f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movimiento;

        if(esPala1)
        {
            // Devuelve 1 o -1 si se pulda las teclas arriba (up) o abajo (down)
            movimiento = Input.GetAxisRaw("Vertical");
        }
        else
        {
            // Devuelve 1 o -1 si se pulda las teclas arriba (W) o abajo (S)
            movimiento = Input.GetAxisRaw("Vertical2");
        }

        Vector2 posicionPala = transform.position;

        // Nos permite indicar los valores mínimo y máximo que pasamos como el primer parámetro
        posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento * velocidad * Time.deltaTime, -limiteY, limiteY);

        // Aplicamos el cambio de la posicion
        transform.position = posicionPala;
    }
}
```


1. **public class Pala : MonoBehaviour**: This is the class declaration for a C# script named "Pala." The class inherits from MonoBehaviour, which is a Unity class that allows you to attach scripts to GameObjects.

2. **[SerializeField] private float velocidad = 7f**;: This line declares a private float variable named "velocidad" and initializes it with a value of 7. The [SerializeField] attribute indicates that the variable should be visible in the Unity Inspector, allowing you to adjust its value from the Inspector.

3. **[SerializeField] private bool esPala1;**: Similar to the previous line, this line declares a private boolean variable named "esPala1" and initializes it without a value. It's also marked with [SerializeField], making it editable in the Unity Inspector.

4. **private float limiteY = 3.75f**;: This line declares a private float variable named "limiteY" and initializes it with a value of 3.75. This variable represents the vertical limit in the Y-axis.

5. **void Start()**: This is the declaration of a method named "Start." In Unity, the "Start" method is called automatically when the GameObject this script is attached to is initialized (i.e., when the game starts). In the provided code, the method is empty, so it doesn't contain any code.

6. **void Update()**: This is the declaration of the "Update" method. In Unity, "Update" is called once per frame. In this script, the "Update" method contains the logic for moving the GameObject (likely a paddle) based on player input.

7. **float movimiento;**: This line declares a float variable named "movimiento" without initializing it. It will be used to store the player's input for vertical movement.

8. **if (esPala1) { ... } else { ... }**: This is an if-else statement that checks the value of the "esPala1" variable. If it's true, it executes the code inside the first block (between the curly braces), otherwise, it executes the code inside the second block. This allows for different input controls based on whether "esPala1" is true or false.

9. **movimiento = Input.GetAxisRaw("Vertical");**: This line sets the "movimiento" variable based on player input. If "esPala1" is true, it reads input from the vertical axis labeled as "Vertical," which typically corresponds to the "up" and "down" arrow keys.

10. **movimiento = Input.GetAxisRaw("Vertical2");**: If "esPala1" is false, this line reads input from the "Vertical2" axis, which could correspond to other keys or input methods.

11. **Vector2 posicionPala = transform.position;**: This line creates a Vector2 variable named "posicionPala" and initializes it with the current position of the GameObject to which this script is attached.

12. **posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento * velocidad * Time.deltaTime, -limiteY, limiteY);**: This line updates the "posicionPala.y" value based on the player's input for vertical movement ("movimiento"), the speed ("velocidad"), and the time passed since the last frame ("Time.deltaTime"). The Mathf.Clamp function ensures that the new position does not exceed the specified vertical limits between "-limiteY" and "limiteY."

13. **transform.position = posicionPala;**: Finally, this line applies the updated position ("posicionPala") to the GameObject's transform, effectively moving the GameObject vertically within the specified limits.

In summary, this script controls the vertical movement of a GameObject (likely a paddle) based on player input. The input controls can be different depending on whether "esPala1" is true or false, allowing for flexibility in controlling the GameObject's movement. The [SerializeField] attribute makes it possible to adjust the speed and control type from the Unity Inspector.









****

Feel free to download or fork this repo and explore the files and undertstand how I made this project.
