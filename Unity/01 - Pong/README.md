<div align="center">

# Pong

</div>

<!-- ![Pong](https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Pong1.gif?raw=true "Title") -->

<p align="center">
  <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Pong1.gif?raw=true" width="900" title="Pong">
</p>

Pong is one of the first computer games that ever created, this simple "tennis like" game features two paddles and a ball, the goal is to defeat your opponent by being the first one to gain 10 point, a player gets a point once the opponent misses a ball. Pong became a huge success, and became the first commercially successful game, on 1975, Atari release a home edition of Pong (the first version was played on Arcade machines) which sold 150,000 units.

Today, the Pong Game is considered to be the game which started the video games industry, as it proved that the video games market can produce significant revenues.

[More about Pong game...](https://www.ponggame.org/)

<div align="center">

# Creating Process

</div>

## Template

<details>
  <summary>See more...</summary>
  <br>

- The very first step is to set the template correctly, "2D Core" must be selected.

  <br>
</details>

## Graphics Elements

<details>
  <summary>See more...</summary>
  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/Elements.png?raw=true" width="900" title="Pong">
  </p>

- The great majority of the grapichs elements are created by selecting **"2D Object" -> "Sprites" -> "Square."**

- However, the counters are created differently: **"UI" -> "Text" -> "TextMeshPro."**
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/ElementsList.png?raw=true" height="250" title="Pong">
  </p>
</details>

## BoxCollider2D

<details>
  <summary>See more...</summary>
  <br>

- It is necessary to detect collisions between two elements. For that purpose, we have Colliders. Every graphic element must have a BoxCollider2D inside the Inspector window, except for the "LineaCentral" element, which is purely visual.

  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxCollider.png?raw=true" height="250" title="Pong">
  </p>
  <br>

- Without the colliders, the ball, for example, could pass through the walls without bouncing. However, we can set up the vertical walls or goals as triggers, which means that a specific action will be performed when the ball hits them.

  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BoxColliderGol.png?raw=true" height="250" title="Pong">
  </p>
</details>

## RigidBody2D

<details>
  <summary>See more...</summary>
  <br>
  
  - Rigidbodies enable your GameObjects to act under the control of physics. The Rigidbody can receive forces and torque to make your objects move in a realistic way. Any GameObject must contain a Rigidbody to be influenced by gravity, act under added forces via scripting, or interact with other objects through the NVIDIA PhysX physics engine.
  
  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/RigidBodyBola.png?raw=true" height="350" title="Pong">
  </p>
  <br>

- The only elements with a **RigidBody 2D** are **Pala1**, **Pala2** and **Bola**. They are not gooing to rotate so it's convenient to freeze rotation on the Z-axis.

- **Pala1** and **Pala2** must be in Kinematic mode. This allows for control their movement based on a script, rather than physics.

- The Ball maintains the Dynamic mode but without gravity.

- The Rigidbody2D allows us to set up the ball to be affected by impacts with **Pala1** and **Pala2**, resulting in the ball bouncing, with its movement based on physics
</details>

## Ball Phisics

<details>
  <summary>See more...</summary>
  <br>

- The default Phisics rules can cause a lost of energy during the impacts, so to change that we can create a **Physics Material 2D** that prevents by modifying the Friction and the Bounciness value.

  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PhysicsMaterial.png?raw=true" width="90%" title="Pong">
  </p>
  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PhysicsMaterial2.png?raw=true" width="90%" title="Pong">
  </p>
  <br>

- This new rules must be applied to the **Bola** RigidBody by changing the Material

  <br>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/RigidBodyBola.png?raw=true" height="350" title="Pong">
  </p>
</details>

## Paddle Physics (Code)

<details>
  <summary>See more...</summary>
  <br>

  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PalaScript.png?raw=true" width="100%" title="Pong">
  </p>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/PalaScript.png?raw=true" width="100%" title="Pong">
  </p>

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

  <br>

1. **`public class Pala : MonoBehaviour`**: This is the class declaration for a C# script named "Pala." The class inherits from MonoBehaviour, which is a Unity class that allows you to attach scripts to GameObjects.

2. **`[SerializeField] private float velocidad = 7f;`**: This line declares a private float variable named "velocidad" and initializes it with a value of 7. The [SerializeField] attribute indicates that the variable should be visible in the Unity Inspector, allowing you to adjust its value from the Inspector.

3. **`[SerializeField] private bool esPala1;`**: Similar to the previous line, this line declares a private boolean variable named "esPala1" and initializes it without a value. It's also marked with [SerializeField], making it editable in the Unity Inspector.

4. **`private float limiteY = 3.75f;`**: This line declares a private float variable named "limiteY" and initializes it with a value of 3.75. This variable represents the vertical limit in the Y-axis.

5. **`void Start()`**: This is the declaration of a method named "Start." In Unity, the "Start" method is called automatically when the GameObject this script is attached to is initialized (i.e., when the game starts). In the provided code, the method is empty, so it doesn't contain any code.

6. **`void Update()`**: This is the declaration of the "Update" method. In Unity, "Update" is called once per frame. In this script, the "Update" method contains the logic for moving the GameObject (likely a paddle) based on player input.

7. **`float movimiento;`**: This line declares a float variable named "movimiento" without initializing it. It will be used to store the player's input for vertical movement.

8. **`if (esPala1) { ... } else { ... }`**: This is an if-else statement that checks the value of the "esPala1" variable. If it's true, it executes the code inside the first block (between the curly braces), otherwise, it executes the code inside the second block. This allows for different input controls based on whether "esPala1" is true or false.

9. **`movimiento = Input.GetAxisRaw("Vertical");`**: This line sets the "movimiento" variable based on player input. If "esPala1" is true, it reads input from the vertical axis labeled as "Vertical," which typically corresponds to the "up" and "down" arrow keys.

10. **`movimiento = Input.GetAxisRaw("Vertical2");`**: If "esPala1" is false, this line reads input from the "Vertical2" axis, which could correspond to other keys or input methods.

11. **`Vector2 posicionPala = transform.position;`**: This line creates a Vector2 variable named "posicionPala" and initializes it with the current position of the GameObject to which this script is attached.

12. **`posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento _ velocidad _ Time.deltaTime, -limiteY, limiteY);`**: This line updates the "posicionPala.y" value based on the player's input for vertical movement ("movimiento"), the speed ("velocidad"), and the time passed since the last frame ("Time.deltaTime"). The Mathf.Clamp function ensures that the new position does not exceed the specified vertical limits between "-limiteY" and "limiteY". We need to use limits because the RigidBody with Kinematic mode does not detects the collisions with the ceiling and floor.

13. **`transform.position = posicionPala;`**: Finally, this line applies the updated position ("posicionPala") to the GameObject's transform, effectively moving the GameObject vertically within the specified limits.

  <br>
In summary, this script controls the vertical movement of a GameObject (likely a paddle) based on player input. The input controls can be different depending on whether "esPala1" is true or false, allowing for flexibility in controlling the GameObject's movement. The [SerializeField] attribute makes it possible to adjust the speed and control type from the Unity Inspector.
  <br>
  <br>
  <br>

  <details>
  <summary>Why the "velocidad" value comes with a <code>f</code> ?</summary>
  <br>

The "f" suffix you see in the line `[SerializeField] private float velocidad = 7f;` is used to explicitly denote that the number is a floating-point (float) value. In C#, adding the "f" suffix is optional but can be useful for code clarity and to ensure that the number is treated as a float rather than a double.

In C#, numeric literals without a suffix are treated as double by default. For example, if you write 7, it's treated as a double. However, Unity's SerializeField attribute expects the type to match exactly with the field type, so if you have a field of type float, it's good practice to add the "f" suffix to indicate that it's a float literal.

Here's a breakdown of the line:

`private float velocidad = 7f`: This declares a private float variable named "velocidad" with the value 7f, where "7" is the numeric value, and "f" is the suffix indicating that it's a float.

Including the "f" suffix makes it clear that "velocidad" is intended to be a float value, and it can help prevent any potential type mismatch issues. In Unity, it's a common practice to use the "f" suffix when working with float variables to improve code readability and maintain consistency in type declarations.

  </details>
  <br>

  <details>
  <summary>What does this line: <code>movimiento = Input.GetAxisRaw("Vertical");</code> ? </summary>
  <br>

The line `movimiento = Input.GetAxisRaw("Vertical");` is used to read the player's input along the vertical axis in a Unity game. Here's a breakdown of what each part of this line does:

`movimiento`: This is a float variable named "movimiento." It is being assigned a value based on the player's input.

`Input`: This is a Unity class that provides access to various input-related functions and properties.

`GetAxisRaw("Vertical")`: This is a method call that retrieves the input along the specified axis. In this case, it's looking for input along the "Vertical" axis.

Now, let's dive deeper into what `Input.GetAxisRaw("Vertical")` does:

- `Input.GetAxisRaw("Vertical")`: This function reads the player's input along the specified axis and returns a float value. The "Vertical" axis typically corresponds to vertical input, such as pressing the "up" and "down" arrow keys or using a gamepad's thumbstick in the up and down directions.

- `GetAxisRaw`: The `GetAxisRaw` function returns a raw value, which means it provides values of either -1, 0, or 1, depending on whether the input is pressed in a negative direction (e.g., "down" arrow key or pushing the thumbstick down), not pressed at all (0), or pressed in a positive direction (e.g., "up" arrow key or pushing the thumbstick up).

So, after executing `Input.GetAxisRaw("Vertical")`, the movimiento variable will hold a value of either -1 (for downward input), 0 (for no input), or 1 (for upward input). This value can be used to control the vertical movement of an object in your game, such as moving a paddle up and down based on player input.

  </details>
  <br>

  <details>
  <summary>What does this line: <code>Vector2 posicionPala = transform.position;</code> ?</summary>
  <br>

The line `Vector2 posicionPala = transform.position;` is used to create a new Vector2 variable named "posicionPala" and initialize it with the current position of the GameObject to which this script is attached. Let's break down what this line does step by step:

Vector2 posicionPala: This part declares a new variable named "posicionPala" with the data type Vector2. Vector2 is a type commonly used in Unity to represent 2D positions and directions. In this case, it's being used to store the position of the GameObject in 2D space.

`transform.position`: The transform component is a fundamental part of Unity GameObjects. It contains information about the GameObject's position, rotation, and scale. transform.position retrieves the current position of the GameObject in 3D space as a Vector3 (x, y, z).

Since you're assigning the value of `transform.position` (a Vector3) to a Vector2 variable, Unity automatically converts the Vector3 to a Vector2 by discarding the z-component, resulting in a 2D position represented by "posicionPala."

In the context of your script, "posicionPala" is likely used to keep track of the GameObject's position in the 2D space, specifically in the Y-axis, as you can see from the later code where the Y-coordinate is modified based on player input.

Overall, this line sets up a Vector2 variable to store the current 2D position of the GameObject, which can then be modified or used in various ways within the script.

  </details>
  <br>

  <details>
  <summary>How the "transform" component knows it makes reference to the "Pala" element ?</summary>
  <br>

The "transform" component in Unity always refers to the transform component of the GameObject to which the script is attached. In the script you provided, which is named "Pala," the "transform" component refers to the transform of the GameObject to which this "Pala" script is attached. Here's how it works:

Script Attachment: You attach scripts to GameObjects in Unity. When you attach the "Pala" script to a GameObject, you are essentially telling Unity that this script is associated with that specific GameObject.

Accessing Transform: Inside the "Pala" script, when you use the transform keyword, Unity knows to reference the transform component of the GameObject to which the script is attached. It's a built-in reference provided by Unity for every script.

GameObject Context: Unity maintains a context for each script. When the script executes, it operates within the context of the GameObject to which it's attached. This context includes access to the GameObject's transform, position, rotation, scale, and other components.

So, you don't need to explicitly specify which GameObject's transform you want to access in the script. Unity takes care of that for you based on the context of the script's attachment. If you attach the "Pala" script to multiple GameObjects, each instance of the script will independently reference the transform of the GameObject it's attached to.

  </details>
  <br>

  <details>
  <summary>What does this line: <code>posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento * velocidad * Time.deltaTime, -limiteY, limiteY);</code> ?</summary>
  <br>

The line `posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento * velocidad * Time.deltaTime, -limiteY, limiteY);` is responsible for controlling the vertical position of the GameObject (likely a paddle) within specified limits in a Unity game. Let's break it down step by step:

`posicionPala.y`: This part refers to the Y-coordinate of the "posicionPala" Vector2 variable, which represents the current vertical position of the GameObject.

`Mathf.Clamp(...)`: This is a function call to `Mathf.Clamp`, which is a Unity function used to restrict or "clamp" a value within specified minimum and maximum limits.

`posicionPala.y + movimiento _ velocidad _ Time.deltaTime`: Inside the `Mathf.Clamp` function, this expression calculates the new Y-coordinate for "posicionPala." It starts with the current Y-coordinate and adds a value that depends on player input ("movimiento"), speed ("velocidad"), and the time passed since the last frame ("Time.deltaTime").

`movimiento`: This is a float value that typically represents player input for vertical movement. It can be -1 (for downward input), 0 (for no input), or 1 (for upward input).

`velocidad`: This float value likely represents the speed at which the GameObject moves vertically.

`Time.deltaTime`: This is the time in seconds it took to complete the last frame. It's used to ensure smooth and frame-rate-independent movement.

`-limiteY, limiteY`: These are the minimum and maximum limits for the Y-coordinate. The GameObject's vertical position is clamped between these two values.

Here's what this line does:

- It calculates a new potential Y-coordinate for the "posicionPala" based on the current position, player input, speed, and frame time.

- It then uses Mathf.Clamp to ensure that this new Y-coordinate remains within the specified vertical limits defined by -limiteY and limiteY.

The result is that the GameObject's vertical position is updated based on player input, but it cannot go beyond the defined limits. This ensures that the GameObject stays within a specific vertical range.

This line of code is commonly used for implementing vertical movement for game objects such as paddles, characters, or any element that needs to be constrained within certain boundaries in a 2D Unity game.

  </details>
  <br>
</details>

## Ball Movement (Code)

<details>
  <summary>See more...</summary>
  <br>

  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BolaScript.png?raw=true" width="100%" title="Pong">
  </p>
  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/BolaScript2.png?raw=true" width="100%" title="Pong">
  </p>

- As we did with the paddles, a new C# script must be created to design the ball movement

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    // Establecemos la velocidad inicial y valor de multiplicación
    [SerializeField] private float velocidadInicial = 4f;
    [SerializeField] private float valorDeMultiplicacion = 1.1f;

    // Cogemos referencia a su Rigidbody
    private Rigidbody2D bolaRb;

    // Start is called before the first frame update
    void Start()
    {
        bolaRb = GetComponent<Rigidbody2D> ();
        Lanzar();
    }

    // Método que se encarga de lanzar la bola en el comienzo
    private void Lanzar()
    {
        float velocidadX = Random.Range(0, 2) == 0 ? 1 : -1; // Range nos da 0 o 1 y lo convertimos a 1 o -1
        float velocidadY = Random.Range(0, 2) == 0 ? 1 : -1;

        // Asignamos a la velocidad de la bola un Vector2 y la multiplicamos por esa velocidad inicial
        bolaRb.velocity = new Vector2(velocidadX, velocidadY) * velocidadInicial;
    }

    // Método para saber cuándo se produce una colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si colisiona con un objeto con TAG "PalaTag" => aumentamos velocidad
        if(collision.gameObject.CompareTag("PalaTag"))
        {
            bolaRb.velocity *= valorDeMultiplicacion;
        }
    }

    // Detectamos si se alcanzó alguan de las 2 zonas de gol
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GolPala2Tag"))
        {
            ControladorJuego.Instance.GolPala1();
        }
        else
        {
            ControladorJuego.Instance.GolPala2();
        }
        // Reiniciamos los elementos del juego y lanzamos la bola
        ControladorJuego.Instance.Reiniciar();
        Lanzar();
    }
}
```

  <br>

1. **`using System.Collections;`** : This line includes the namespace System.Collections, which is necessary for working with collections and data structures in C#.

2. **`using System.Collections.Generic;`** : This line includes the namespace System.Collections.Generic, which is necessary for working with generic collections and data structures in C#.

3. **`using UnityEngine;`** : This line includes the UnityEngine namespace, which provides access to Unity's core functionality.

4. **`public class Bola : MonoBehaviour`**: This is the class declaration for a C# script named "Bola." The class inherits from MonoBehaviour, indicating that it's a Unity script that can be attached to GameObjects.

5. **`[SerializeField] private float velocidadInicial = 4f;`** : This line declares a private float variable named "velocidadInicial" and initializes it with a value of 4. The [SerializeField] attribute allows you to expose this variable in the Unity Inspector.

6. **`[SerializeField] private float valorDeMultiplicacion = 1.1f;`** : Similar to the previous line, this line declares another private float variable named "valorDeMultiplicacion" and initializes it with a value of 1.1. It's also marked with [SerializeField] for Inspector visibility.

7. **`private Rigidbody2D bolaRb;`** : This declares a private variable of type Rigidbody2D named "bolaRb." It will be used to reference the Rigidbody2D component attached to the GameObject.

8. **`void Start()`**: This is the declaration of the "Start" method. In Unity, "Start" is called automatically when the GameObject this script is attached to is initialized (i.e., when the game starts). In this script, the method is used to set up and initialize the "bolaRb" variable and then call the "Lanzar" method.

9. **`bolaRb = GetComponent<Rigidbody2D>();`** : This line assigns the "bolaRb" variable by getting the Rigidbody2D component attached to the same GameObject as this script. It uses GetComponent to retrieve the component.

10. **`Lanzar();`** : This line calls the "Lanzar" method, which is responsible for initializing the initial velocity of the GameObject.

11. **`private void Lanzar()`**: This is the declaration of the "Lanzar" method. It's a custom method used to launch the ball with an initial velocity.

12. **`float velocidadX = Random.Range(0, 2) == 0 ? 1 : -1;`** : This line calculates a random horizontal velocity for the ball. It uses Random.Range(0, 2) to generate a random number that's either 0 or 1, and then uses a conditional (ternary) operator to set velocidadX to 1 if the random number is 0, or -1 if it's 1.

13. **`float velocidadY = Random.Range(0, 2) == 0 ? 1 : -1;`** : Similar to the previous line, this line calculates a random vertical velocity for the ball.

14. **`bolaRb.velocity = new Vector2(velocidadX, velocidadY) * velocidadInicial;`** : This line assigns the initial velocity to the Rigidbody2D component of the ball. It creates a Vector2 with the velocidadX and velocidadY values and multiplies it by velocidadInicial.

15. **`private void OnCollisionEnter2D(Collision2D collision)`**: This is the declaration of the "OnCollisionEnter2D" method, which is called automatically when a collision occurs between the ball and another GameObject that has a collider. This method is used to handle collision events.

16. **`if (collision.gameObject.CompareTag("PalaTag"))`**: This line checks if the GameObject that the ball collided with has a tag "PalaTag." Tags are used to identify and categorize GameObjects in Unity.

17. **`bolaRb.velocity *= valorDeMultiplicacion;`** : If the collision is with an object tagged as "PalaTag," this line multiplies the current velocity of the ball by the "valorDeMultiplicacion." This can be used to increase the speed of the ball upon collision.

18. **`private void OnTriggerEnter2D(Collider2D collision)`**: This is the declaration of the "OnTriggerEnter2D" method. It's called automatically when the ball enters a trigger collider attached to another GameObject.

19. **`if (collision.gameObject.CompareTag("GolPala2Tag"))`**: This line checks if the ball has entered a trigger collider with the tag "GolPala2Tag."

20. **`ControladorJuego.Instance.GolPala1();`** : If the ball enters the trigger with the "GolPala2Tag" tag, this line calls a method named "GolPala1" on an instance of the "ControladorJuego" class. It appears to be a scoring mechanism.

  <br>
  <br>

  <details>
  <summary>What does this line: <code> bolaRb.velocity = new Vector2(velocidadX, velocidadY) * velocidadInicial; </code> ?</summary>
  <br>
  
The line `bolaRb.velocity = new Vector2(velocidadX, velocidadY) * velocidadInicial;` is used to set the velocity of the Rigidbody2D component attached to the GameObject (presumably a ball) in a 2D Unity game. Let's break down what this line does:

`bolaRb.velocity`: This part accesses the velocity property of the Rigidbody2D component named "bolaRb." The Rigidbody2D component is responsible for controlling the physics behavior of the GameObject, including its movement.

`new Vector2(velocidadX, velocidadY)`: This part creates a new 2D vector (Vector2) with horizontal and vertical components specified by the variables "velocidadX" and "velocidadY." These components determine the direction and magnitude of the velocity.

`velocidadX`: This variable holds a value that represents the horizontal component of the velocity. It can be either 1 (positive direction) or -1 (negative direction), indicating movement to the right or left.

`velocidadY`: Similarly, this variable holds a value that represents the vertical component of the velocity. It can be either 1 (positive direction) or -1 (negative direction), indicating movement upward or downward.

`velocidadInicial`: After creating the Vector2 with the desired direction, this line multiplies it by the "velocidadInicial" variable. "velocidadInicial" likely represents the initial speed or magnitude of the velocity that you want to give to the GameObject.

In summary, this line combines the horizontal and vertical components (determined by "velocidadX" and "velocidadY") and multiplies them by "velocidadInicial" to set the velocity of the Rigidbody2D component. This action effectively gives the GameObject a starting velocity, determining its initial movement direction and speed in the 2D space of the Unity game.

  </details>
  <br>
</details>

## Game Controller (Code)

<details>
  <summary>See more...</summary>
  <br>

  <p align="center">
    <img src="https://github.com/juancumbeq/DAM_M08_Multimedia_and_Mobile_Devices_Programming/blob/main/Unity/01%20-%20Pong/Images/ControladorScript.png?raw=true" width="100%" title="Pong">
  </p>

- This Script is a handler of issues such as the counters and the resetting of the initial position of the game for both the ball and the paddles.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Librería para los textos

public class ControladorJuego : MonoBehaviour
{
    // Textos de los marcadores
    [SerializeField] private TMP_Text marcadorPala1;
    [SerializeField] private TMP_Text marcadorPala2;

    // Componentes transform de las palas y la bola => para reiniciar posición
    [SerializeField] private Transform pala1Transform;
    [SerializeField] private Transform pala2Transform;
    [SerializeField] private Transform bolaTransform;

    // Variables que almacenen el valor de las puntuaciones
    private int golesPala1, golesPala2;

    // Patrón Singleton para tener un única instancia
    private static ControladorJuego instance;
    public static ControladorJuego Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ControladorJuego>();
            }
            return instance;
        }
    }

    // Actualizamos los marcadores
    public void GolPala1()
    {
        golesPala1++;
        marcadorPala1.text = golesPala1.ToString();
    }
    public void GolPala2()
    {
        golesPala2++;
        marcadorPala2.text = golesPala2.ToString();
    }

    // Cuando se anota un punto / gol reiniciamos posiciones de las palas y de la bola
    public void Reiniciar()
    {
        pala1Transform.position = new Vector2(pala1Transform.position.x, 0);
        pala2Transform.position = new Vector2(pala2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }
}
```

  <br>

1. **`using System.Collections;`**: This line includes the namespace System.Collections, which is necessary for working with collections and data structures in C#.

2. **`using System.Collections.Generic;`**: This line includes the namespace System.Collections.Generic, which is necessary for working with generic collections and data structures in C#.

3. **`using UnityEngine;`**: This line includes the UnityEngine namespace, which provides access to Unity's core functionality.

4. **`using TMPro;`**: This line includes the TMPro namespace, which is used for handling TextMeshPro text components in Unity, commonly used for UI text.

5. **`public class ControladorJuego : MonoBehaviour`**: This is the class declaration for a C# script named "ControladorJuego." It inherits from MonoBehaviour, indicating that it's a Unity script that can be attached to GameObjects.

6. **`[SerializeField] private TMP_Text marcadorPala1;`**: This line declares a private field of type TMP_Text named "marcadorPala1." It's marked with [SerializeField] to make it visible in the Unity Inspector, allowing you to assign TextMeshPro text components to it.

7. **`[SerializeField] private TMP_Text marcadorPala2;`**: Similar to the previous line, this declares a field for the second player's score.

8. **`[SerializeField] private Transform pala1Transform;`**: These lines declare fields for the transform components of the paddles and the ball. They are used to reset the positions of these objects.

9. **`private int golesPala1, golesPala2;`**: These lines declare private integer variables to store the scores for player 1 and player 2.

10. **`private static ControladorJuego instance;`**: This line declares a private static variable named "instance" of type "ControladorJuego." This is part of the Singleton design pattern used to ensure there is only one instance of this script.

11. **`public static ControladorJuego Instance`**: This is a property (getter) that provides access to the "instance" variable. It ensures that there's only one instance of "ControladorJuego" throughout the game. If there isn't an instance, it tries to find one using FindObjectOfType.

12. **`public void GolPala1()`**: This declares a public method named "GolPala1," which is used to update the score for player 1.

13. **`public void GolPala2()`**: Similar to the previous line, this declares a method to update the score for player 2.

14. **`public void Reiniciar()`**: This method is used to reset the positions of the paddles and the ball when a point or goal is scored. It sets their positions to specific coordinates.

  <br>
In summary, this script manages the game's scoring system, updates the scores displayed on the screen, and provides methods to reset the positions of game elements.

  <br>
  <br>

  <details>
  <summary>What is the Singleton Pattern</summary>
  <br>

The Singleton pattern ensures that a class has only one instance and provides a way to access that instance from any point in your code. Let's break down the code and explain the Singleton pattern step by step:

`private static ControladorJuego instance;`: This line declares a private static variable named "instance" of type "ControladorJuego." This variable will hold the single instance of the "ControladorJuego" class.

`public static ControladorJuego Instance`: This is a public property with a getter. It provides access to the "instance" variable, allowing other parts of the code to access the single instance of the "ControladorJuego" class.

Now, let's explain how the Singleton pattern is implemented:

- When you access `ControladorJuego.Instance`, you are requesting the single instance of the class.

- If the "instance" variable is null, it means that no instance of the "ControladorJuego" class exists yet.

- In that case, `instance = FindObjectOfType<ControladorJuego>();` is used to find an existing instance of the "ControladorJuego" class in the scene. The FindObjectOfType method searches for objects of a specified type in the current scene.

- If an instance is found, it's assigned to the "instance" variable.

- Finally, the "instance" variable is returned, providing access to the single instance of the "ControladorJuego" class.

Here's why the Singleton pattern is used:

- Single Instance: It ensures that there is only one instance of the "ControladorJuego" class throughout the lifetime of the game.

- Global Access: By making the instance accessible through ControladorJuego.Instance, you can access the class's functionality and data from any part of your code without needing to pass references between objects or create multiple instances.

- Initialization on Demand: The instance is only created when it's first accessed. This can be helpful for managing resources efficiently.

- Centralized Control: In many game scenarios, having a single point of control for certain functionalities, like managing scores or game state, can simplify the code and prevent issues that could arise from multiple instances.

In summary, the Singleton pattern ensures that there's exactly one instance of a class, provides a way to access that instance globally, and initializes the instance when it's first needed. It's a common design pattern used in game development and other software applications for managing shared resources and centralizing control.

  </details>
  <br>

  <details>
  <summary>How is it posible that FindObjectType can find an instance if <code> instance == null </code> </summary>
  <br>

When instance is null, `FindObjectOfType` is used to search for an instance of the ControladorJuego class in the current scene. If instance is null, it means that an instance of ControladorJuego has not been created yet. The search with FindObjectOfType is performed to find any object in the scene that is an instance of ControladorJuego and assign that instance to the instance variable.

Here's how it works:

- At the beginning of the game, the instance variable is set to null.

- When `ControladorJuego.Instance` is called for the first time, it checks if instance is null. Since it is initially null, it triggers the search in the scene using FindObjectOfType.

- `FindObjectOfType` searches the current scene, and if it finds an object of type ControladorJuego, it assigns that object to instance. This creates an instance if there isn't one in the scene.

- From that point onward, instance is no longer null, and the same instance is returned every time you access `ControladorJuego.Instance`.

So, even though instance is null initially, the call to FindObjectOfType is precisely to find or create an instance, and once found or created, that instance is stored in instance for subsequent access. This ensures that, from that point on, the same instance of ControladorJuego will always be returned wherever you access ControladorJuego.Instance.

  </details>
  <br>

</details>
<br>
<br>
<br>
<br>

<div align="center">

### 🤓 Feel free to download or forking this repo and explore the files and undertstand how I made this project.

</div>
