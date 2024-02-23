# :video_game: FitFactory-7

## :file_folder: Overview:
FitFactory-7 is a virtual reality fitness game that aims to make exercising fun and interactive for players in a seven minute session. The game features a combination of cardio, boxing, dance and HIIT (High-Intensity Interval Training) all while immersed in a virtual world. FitFactory-7 is designed for players of all fitness levels, providing a gamified approach to fitness that encourages players to exercise regularly.

## :cook: Technologies:
* `Unity Engine` 
* `Microsoft Visual Studio`
* `Oculus SDK` 
* `Unity XR Plugin Framework`
* `Unity XR Interaction Toolkit`
* `.NET Framework`
* `C# Language`
* `Blender`
* `Git`

## :joystick: Features
Here is what you can do with FitFactory-7: 

- **User-Player Interactables**
  - **Hand Physics**
     - Hand presence
       - Activate Grab Ray
       - Animate Hand on Input
     - Grab Interactable Two Attach
     - Pistol
       - Fire Bullet on Activate
       - Rotate
       - Velocity Estimator
  - **Full body Physic**
       - Head
         - Animation
         - Continuous turn    
- **Diegetic UI and Countdown Visual**
   - Boxes Missed
   - Total Boxes Missed 
   - Boxes Hit 
   - Timer 
   - Timer Countdown 
   - Cube Spawner
   - Punch 
   - Generate Haptic Feedback
   - Cube movement 
- **Enemy**
   - Enemy
     - AI (Distance from user player)
     - Death behavior
     - Attack behavior
   - Pistol
     - Fire Bullet on Activate
     - Rotate
     - Velocity Estimator
   - Bottle
     - Grabbable
     - Increase the speed velocity when thrown
- **Power-Ups**
   - Freeze time
   - Teleport back to initial position
   - Switch from three to six degrees of freedom

## :eyeglasses: Visuals:
FitFactory-7 showcases a minimalistic visual with a plain white color that will immerse players in the workout. The virtual environments intents to reduce the distractions to its most basic an essential component, allowing your body and mind to be fully focus on your body moments.

## :headphones: Audio:
The game will be only featuring an upbeat music that corresponds to the workout. The music is carefully selected to match the tempo and rhythm of the exercises, providing the player with an immersive and engaging experience. In this case, we will use the song Unity by “The Fat Rat.” 

- **To calculate the tempo or beats per minute (BPM):**
- Identify a repeating rhythm, such as the bass drum or a snare hit.
- Count the number of beats that occur in 15 seconds using a stopwatch or timer.
- Multiply the number of beats counted in 15 seconds by 4. This will give you the number of beats in one minute.Round the result to the nearest whole number. This is the song's BPM.

In this specific scenario, the song is 105 beats/minute so if you want to calculate how many seconds between beats you must divide the 60/105 and you will obtain the seconds between beats.  
The game also features sound effects that provide players with feedback on their performance, such as the sound of a punch landing or an avoiding being hit by an intruder.

## :books: What I learned: 

## Unity for VR

- **Physics Implementation**: Inspired by games like Boneworks/Bonelab, incorporating realistic hand physics and full-body physics to enhance user interaction and immersion within the VR environment.
- **Animation Control**: Utilizing Unity's Animator Controller to create and manage hand movements, demonstrating a deep understanding of animation layers, parameters, and transitions for dynamic character interactions.
- **Scripting for Interactivity**: Developing scripts to control hand and body physics, locomotion, and interactive objects, through C# scripting.

## External Libraries with Unity

- **XR Interaction Toolkit**: Used for managing VR-specific interactions, given the focus on hand controllers, physics interactions, and locomotion.
- **Universal Render Pipeline (URP)**: Indicated by the reference to a forward renderer, emphasis on optimizing visual fidelity and performance in the VR environment.

## Functions Implemented 

- **PhysicsRig Script**: Manages the physical representation of the player's avatar, ensuring realistic interactions with the environment, like kneeling and collision detection. I spent a lot of time learning how are changes done before the frames are updated. Useful for drawing fuctions that will alter the dynamic of the virtual environmnet. 
- **ContinuousMovementPhysics Script**: Enables physics-based locomotion, allowing for natural movement within the VR space, addressing climbing and grounding checks. Extremely useful when whiteboxing. 
- **Hand Controller Scripts**: Facilitate hand interactions, such as gripping and manipulating objects, demonstrating the implementation of complex VR hand physics. Through C# scripting, I was able to understand better the event listener when your hand montion is activated through different actions.

# Overall Growth 

- **Physics and Interactivity**: Gained a robust understanding of implementing and fine-tuning physics for VR, ensuring realistic interactions between the player's avatar and the game environment.
- **Animation and Control**: Learned to control animations based on player inputs, enhancing the immersive experience of VR.
- **Performance Optimization**: Through the use of URP and careful scene setup, developed skills in optimizing VR applications for better performance without compromising visual quality.

# Areas for Improvement

- **Collider and Physics Optimization**: Ensuring that hand colliders interact more precisely with objects could improve the sense of immersion. Exploring advanced physics settings and collider configurations might yield better results.
- **Animation Smoothing**: While significant strides were made in animation control, further refinement in transitions and responses could enhance realism.
- **Environmental Interaction**: Expanding the range and depth of interactable objects and environmental effects could significantly enhance user engagement and immersion.
 
## :vertical_traffic_light: Running the project
- **Clone repository in your local machine.**
  - Open terminal or command prompt.
  - Navigate to the directory where you want to clone the repository.
  - Run the clone command:
    ```bash
    git clone https://github.com/yourusername/yourrepositoryname.git
    ```
  - Change into the project directory:
    ```bash
    cd yourrepositoryname
    ```

- **Install Dependencies**
  - Using Unity
    - You might not need to install dependencies manually.

- **Running the Project**
  - Open Unity Hub.
  - Click "Add" and navigate to the cloned project folder.
  - Select the project to add it to the Hub.



## :video_camera: Video
[![Watch the video](https://img.youtube.com/vi/GtpaSzc2XyE/0.jpg)](https://youtu.be/GtpaSzc2XyE)


